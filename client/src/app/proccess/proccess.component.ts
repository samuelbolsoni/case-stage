import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';

import {MatPaginator, MatPaginatorModule} from '@angular/material/paginator';
import {MatSort, MatSortModule} from '@angular/material/sort';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import { CoreService } from '../core/core.service';
import { ProccessService } from '../services/proccess.service';
import { ProccessCreateComponent } from './proccess-create/proccess-create.component';

@Component({
  selector: 'proccess-area',
  templateUrl: './proccess.component.html',
  styleUrls: ['./proccess.component.css']
})
export class ProccessComponent implements OnInit {

  displayedColumns: string[] = ['id', 'area', 'description', 'active', 'actions'];
  dataSource!: MatTableDataSource<any>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  
  constructor(
    private _dialog: MatDialog, 
    private _proccessService: ProccessService,
    private _coreService: CoreService
  ) {}

  ngOnInit(): void {
    this.getProccessList();
  }
  openAddEditProccessForm() {
    const dialogRef = this._dialog.open(ProccessCreateComponent);
    dialogRef.afterClosed().subscribe({
      next: (val) => {
        if (val) {
          this.getProccessList();
        }
      }
    })
  }

  openEditProccessForm(data:any) {
    const dialogRef = this._dialog.open(ProccessCreateComponent, {
      data,
    });

    dialogRef.afterClosed().subscribe({
      next: (val) => {
        if (val) {
          this.getProccessList();
        }
      }
    })
    
  }

  getProccessList() {
    this._proccessService.GetProccess().subscribe({
      next: (res) => {
        this.dataSource = new MatTableDataSource(res);
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
      },
      error: console.log,
    })
  }

  deleteProccess(id: number) {
    this._proccessService.deleteProccess(id).subscribe({
      next: (res) => {
        this._coreService.openSnackBar('Processo deletada com sucesso', 'done')
        this.getProccessList();
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
