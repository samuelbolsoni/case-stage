import {FlatTreeControl} from '@angular/cdk/tree';
import {Component, OnInit} from '@angular/core';
import {MatTreeFlatDataSource, MatTreeFlattener, MatTreeModule} from '@angular/material/tree';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import { ProccessService } from 'src/app/services/proccess.service';
import { ProccessTree } from '../model/proccess-tree';

/**
 * Food data with nested structure.
 * Each node has a name and an optional list of children.
 */
interface FoodNode {
  name: string;
  children?: FoodNode[];
}

/** Flat node with expandable and level information */
interface ExampleFlatNode {
  expandable: boolean;
  name: string;
  level: number;
}

@Component({
  selector: 'app-map-tree',
  templateUrl: './map-tree.component.html',
  styleUrls: ['./map-tree.component.css'],
  template: `
        <button (click)="collapseAll()">Collapse All</button><button (click)="expandAll()">Expand All</button>
        <p></p>
        <db-angular-tree-grid #angularGrid [data]="data" [configs]="configs"></db-angular-tree-grid>
      `
})



export class MapTreeComponent {

  tree: FoodNode[] = [];
  getTree: ProccessTree[] = [];
  finalObj = {};
  
  proccessTree =  this._proccessService.GetProccessTree().subscribe(x => {
    x.forEach(p => {
      this.tree.push({name: p.description, children: p.childrens});
    })

    this.tree.forEach((element: any, index: any) => {
      Object.assign(this.finalObj, this.getTree[index]);
    });

  });

  //this.tree.push(getTree);

  TREE_DATA: FoodNode[] = this.tree;
  
  /*
  TREE_DATA: FoodNode[] = [
    {
      name: 'Fruits',
      children: [{name: 'Apple'}, {name: 'Banana'}, {name: 'Fruit loops'}],
    },
    {
      name: 'Vegetables',
      children: [
        {
          name: 'Green',
          children: [{name: 'Broccoli'}, {name: 'Brussels sprouts'}],
        },
        {
          name: 'Orange',
          children: [{name: 'Pumpkins'}, {name: 'Carrots'}],
        },
      ],
    },
  ];
*/
  private _transformer = (node: FoodNode, level: number) => {
    return {
      expandable: !!node.children && node.children.length > 0,
      name: node.name,
      level: level,
    };
  };

  ngOnInit() {
    
    let finalObj = {};

    this._proccessService.GetProccessTree().subscribe(x => {
      x.forEach(p => {
        //this.tree.push({name: p.description, children: p.childrens});
        this.getTree.push(p);
      })

      console.log(this.getTree.length);

      this.getTree.forEach((element: any, index: any) => {
        Object.assign(finalObj, this.getTree[index]);
      });

      console.log(finalObj);

    });

    console.log(this.TREE_DATA);

    //console.log(finalObj);
    //console.log(this.TREE_DATA);
  }

  treeControl = new FlatTreeControl<ExampleFlatNode>(
    node => node.level,
    node => node.expandable,
  );

  treeFlattener = new MatTreeFlattener(
    this._transformer,
    node => node.level,
    node => node.expandable,
    node => node.children,
  );

  dataSource = new MatTreeFlatDataSource(this.treeControl, this.treeFlattener);

  constructor(private _proccessService: ProccessService) {
    this.dataSource.data = this.TREE_DATA;
  }

  hasChild = (_: number, node: ExampleFlatNode) => node.expandable;
}
