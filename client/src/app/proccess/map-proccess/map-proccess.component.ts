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
      
      const tree: ProccessNode[] = [];

      this.listProccess.forEach((node, index)=> {
         
        if (node.idParent == null) {

          //Verifica a recursividade
          for(let x=0; x<node.childrens.length; x++) {
            if (node.childrens.length > 0) {

              //Busca o registro no array original
              const insertChildOnParent = this.listProccess.filter((obj) => {
                return obj.idParent == node.childrens[x].id;
              });

              node.childrens[x].childrens = [];
              node.childrens[x].childrens.push(...insertChildOnParent);

              for(let y=0; y<node.childrens[x].childrens.length; y++) {
                const insertChildOnParent2 = this.listProccess.filter((obj) => {
                  return obj.idParent == node.childrens[x].childrens[y].id;
                });
  
                node.childrens[x].childrens[y].childrens = [];
                node.childrens[x].childrens[y].childrens.push(...insertChildOnParent2);

                for(let z=0; z<node.childrens[x].childrens[y].childrens.length; z++) {
                  const insertChildOnParent2 = this.listProccess.filter((obj) => {
                    return obj.idParent == node.childrens[x].childrens[y].childrens[z].id;
                  });
    
                  node.childrens[x].childrens[y].childrens[z].childrens= [];
                  node.childrens[x].childrens[y].childrens[z].childrens.push(...insertChildOnParent2);
                }
              }
            }
          }

          const nodes = new ProccessNode(node.id, node.description, node.childrens);

          tree.push(nodes)
        }
      });

      this.dataSource = new MatTreeFlatDataSource(this.treeControl, this.treeFlattener);
      this.dataSourceTable = new MatTableDataSource(this.listProccess);
      this.dataSource.data = tree;
    })
  }

  hasChild = (_: number, node: ExampleFlatNode) => node.expandable;

}
