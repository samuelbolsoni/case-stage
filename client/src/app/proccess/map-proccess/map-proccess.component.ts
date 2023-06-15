import { FlatTreeControl } from '@angular/cdk/tree';
import { Component } from '@angular/core';
import { MatTreeFlatDataSource, MatTreeFlattener } from '@angular/material/tree';
import { ProccessService } from 'src/app/services/proccess.service';
import { MapProccessViewDetailsComponent } from '../map-proccess-view-details/map-proccess-view-details.component';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';

interface IProccessNode {
  id: number,
  description: string;
  childrens: IProccessNode[];
}

class ProccessNode  {
  constructor(public description:string, public childrens:ProccessNode[]) {}
}

/** Flat node with expandable and level information */
interface ExampleFlatNode {
  expandable: boolean;
  id: number,
  name: string;
  level: number;
}

@Component({
  selector: 'app-map-proccess',
  templateUrl: './map-proccess.component.html',
  styleUrls: ['./map-proccess.component.css']
})
export class MapProccessComponent {

  listProccess!: IProccessNode[];
  listProccessJson!: ProccessNode[];
  
  tree!: ProccessNode[];
  nodes!: any[];

  private _transformer = (node: IProccessNode, level: number) => {
    return {
      expandable: !!node.childrens && node.childrens.length > 0,
      id: node.id,
      name: node.description,
      level: level,
    };
  };

  treeControl = new FlatTreeControl<ExampleFlatNode>(
    node => node.level,
    node => node.expandable,
  );

  treeFlattener = new MatTreeFlattener(
    this._transformer,
    node => node.level,
    node => node.expandable,
    node => node.childrens,
  );

  dataSource!: any;
  returnSource!: any;
  constructor(private _proccessService: ProccessService, private _dialog: MatDialog ) 
  {
  }

  ngOnInit() {
    this.fetchProccess();
  }

  openViewProccessForm(data:any) {
    let viewProccess = this._proccessService.GetProccessById(data.id).subscribe({
      next: (res) => {
        data = res as MatDialogConfig<any>;

        const dialogRef = this._dialog.open(MapProccessViewDetailsComponent, {
          data,
        });
    
        dialogRef.afterClosed().subscribe({
          next: (val) => {
            if (val) {
              this.fetchProccess();
            }
          }
        })

      },
      error: console.log,
    });
    
  }

  fetchProccess(){
    this._proccessService.GetProccessTree().subscribe(data => {
      this.listProccess = data;
      this.dataSource = new MatTreeFlatDataSource(this.treeControl, this.treeFlattener);
      this.dataSource.data = this.listProccess;
    })
  }

  hasChild = (_: number, node: ExampleFlatNode) => node.expandable;

}
