import { FlatTreeControl } from '@angular/cdk/tree';
import { Component } from '@angular/core';
import { MatTreeFlatDataSource, MatTreeFlattener } from '@angular/material/tree';
import { ProccessService } from 'src/app/services/proccess.service';
import { MapProccessViewDetailsComponent } from '../map-proccess-view-details/map-proccess-view-details.component';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';

interface IProccessNode {
  parentDescription: undefined;
  id: number,
  idParent: number,
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
  newTree!: IProccessNode[];
  
  tree!: ProccessNode[];
  nodes!: any[];
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
      
      const nodesToRemove = Array();

      this.listProccess = data;

      //Busca todos os filhos do array
      const allChildrens = this.listProccess.filter((obj) => {
        return obj.idParent != null;
      });

      //Varre os filhos encontrados
      allChildrens.forEach(children => {

        //Busca o pai do filho
        const parentFind = this.listProccess.filter((obj) => {
          return obj.id == children.idParent;
        });

        if (parentFind != null) {
          const parent = parentFind[0]; //Recebe o pai

          //Busca o pai no array original
          const insertChildOnParent = this.listProccess.filter((obj) => {
            return obj.id == parent.id;
          });

          console.log(insertChildOnParent[0].childrens);
          insertChildOnParent[0].childrens.push(children);
          
          const childToRemove = this.listProccess.filter((obj) => {
            return obj.id == children.id;
          });

          nodesToRemove.push(childToRemove[0]);
        }
      });

      //Remover os filhos duplicados
      this.listProccess.forEach(element => {
        const childrensOnArray = Array();
        element.childrens.forEach((childrenDuplicated, index) => {
          if (childrenDuplicated.hasOwnProperty('parentDescription')) {
            element.childrens.splice(index,1);
          }
          
        });
        console.log(childrensOnArray);
      });

      //Remove do array os filhos
      this.listProccess.forEach((element, index)=> {

        const findNodeToDeleteOnOriginalArray = this.listProccess.filter((obj) => {
          return obj.id == element.id;
        });

        const findNodeToDelete = nodesToRemove.filter((obj) => {
          return obj.id == element.id;
        });

        if (findNodeToDelete.length > 0  && findNodeToDeleteOnOriginalArray.length > 0 ) {

          if (findNodeToDelete[0].id == findNodeToDeleteOnOriginalArray[0].id) {
            this.listProccess.splice(index,1);
          }
        }
      });

      this.dataSource = new MatTreeFlatDataSource(this.treeControl, this.treeFlattener);
      this.dataSource.data = this.listProccess;
    })
  }

  hasChild = (_: number, node: ExampleFlatNode) => node.expandable;

}
