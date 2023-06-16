import { FlatTreeControl } from '@angular/cdk/tree';
import { Component } from '@angular/core';
import { MatTreeFlatDataSource, MatTreeFlattener } from '@angular/material/tree';
import { ProccessService } from 'src/app/services/proccess.service';
import { MapProccessViewDetailsComponent } from '../map-proccess-view-details/map-proccess-view-details.component';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';

interface IProccessNode {
  parentDescription: undefined;
  id: number,
  idParent: number,
  description: string;
  childrens: IProccessNode[];
}

class ProccessNode  {
  constructor(public id: number, public description:string, public childrens:ProccessNode[]) {}
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

  displayedColumns: string[] = ['description'];

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSourceTable.filter = filterValue.trim().toLowerCase();
  }
  
  listProccess!: IProccessNode[];
  
  nodesToRemove!: any[];

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
  dataSourceTable!: any;

  returnSource!: any;
  constructor(private _proccessService: ProccessService, private _dialog: MatDialog ) 
  {
  }

  ngOnInit() {
    this.fetchProccessMap();
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
              this.fetchProccessMap();
            }
          }
        })
      },
      error: console.log,
    });
  }

  fetchProccessMap(){
    this._proccessService.GetProccessTree().subscribe(data => {
      
      this.listProccess = data;
      
      this.dataSource = new MatTreeFlatDataSource(this.treeControl, this.treeFlattener);
      this.dataSourceTable = new MatTableDataSource(this.listProccess);
      this.dataSource.data = this.listProccess;
    })
  }

  hasChild = (_: number, node: ExampleFlatNode) => node.expandable;

}
