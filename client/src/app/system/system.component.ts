import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { SystemCreateComponent } from './system-create/system-create.component';
import { SystemService } from '../services/system.service';

import {MatPaginator, MatPaginatorModule} from '@angular/material/paginator';
import {MatSort, MatSortModule} from '@angular/material/sort';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import { System } from './model/system';
import { CoreService } from '../core/core.service';

@Component({
  selector: 'app-system',
  templateUrl: './system.component.html',
  styleUrls: ['./system.component.css']
})
export class SystemComponent implements OnInit {

  displayedColumns: string[] = ['id', 'name', 'active', 'actions'];
  dataSource!: MatTableDataSource<any>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  
  constructor(
    private _dialog: MatDialog, 
    private systemService: SystemService,
    private _coreService: CoreService

  ) {}

  ngOnInit(): void {
    this.getSystemList();
  }
  openAddEditSystemForm() {
    const dialogRef = this._dialog.open(SystemCreateComponent);
    dialogRef.afterClosed().subscribe({
      next: (val) => {
        if (val) {
          this.getSystemList();
        }
      }
    })
  }

  openEditSystemForm(data:any) {
    const dialogRef = this._dialog.open(SystemCreateComponent, {
      data,
    });

    dialogRef.afterClosed().subscribe({
      next: (val) => {
        if (val) {
          this.getSystemList();
        }
      }
    })
    
  }

  getSystemList() {
    this.systemService.GetSystems().subscribe({
      next: (res) => {
        this.dataSource = new MatTableDataSource(res);
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
      },
      error: console.log,
    })
  }

  deleteSystem(id: number) {
    this.systemService.deleteSystem(id).subscribe({
      next: (res) => {
        this._coreService.openSnackBar('Sistema deletado com sucesso', 'done')
        this.getSystemList();
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
