import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AreaCreateComponent } from './area-create/area-create.component';
import { AreaService } from '../services/area.service';

import {MatPaginator, MatPaginatorModule} from '@angular/material/paginator';
import {MatSort, MatSortModule} from '@angular/material/sort';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import { Area } from './model/area';
import { CoreService } from '../core/core.service';

@Component({
  selector: 'app-area',
  templateUrl: './area.component.html',
  styleUrls: ['./area.component.css']
})
export class AreaComponent implements OnInit {

  displayedColumns: string[] = ['id', 'name', 'active', 'actions'];
  dataSource!: MatTableDataSource<any>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  
  constructor(
    private _dialog: MatDialog, 
    private _areaService: AreaService,
    private _coreService: CoreService
  
    ) {}

  ngOnInit(): void {
    this.getAreaList();
  }
  openAddEditAreaForm() {
    const dialogRef = this._dialog.open(AreaCreateComponent);
    dialogRef.afterClosed().subscribe({
      next: (val) => {
        if (val) {
          this.getAreaList();
        }
      }
    })
  }

  openEditAreaForm(data:any) {
    const dialogRef = this._dialog.open(AreaCreateComponent, {
      data,
    });

    dialogRef.afterClosed().subscribe({
      next: (val) => {
        if (val) {
          this.getAreaList();
        }
      }
    })
    
  }

  getAreaList() {
    this._areaService.GetAreas().subscribe({
      next: (res) => {
        this.dataSource = new MatTableDataSource(res);
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
      },
      error: console.log,
    })
  }

  deleteArea(id: number) {
    this._areaService.deleteArea(id).subscribe({
      next: (res) => {
        this._coreService.openSnackBar('Area deletada com sucesso', 'done')
        this.getAreaList();
      },
      error: console.error,
    })
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
}
