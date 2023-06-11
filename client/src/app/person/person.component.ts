import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';

import {MatPaginator, MatPaginatorModule} from '@angular/material/paginator';
import {MatSort, MatSortModule} from '@angular/material/sort';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import { CoreService } from '../core/core.service';
import { PersonCreateComponent } from './person-create/person-create.component';
import { PersonService } from '../services/person.service';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.css']
})
export class PersonComponent implements OnInit {

  displayedColumns: string[] = ['id', 'name', 'email', 'active', 'actions'];
  dataSource!: MatTableDataSource<any>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  
  constructor(
    private _dialog: MatDialog, 
    private _personService: PersonService,
    private _coreService: CoreService

  ) {}

  ngOnInit(): void {
    this.getPersonList();
  }
  openAddEditPersonForm() {
    const dialogRef = this._dialog.open(PersonCreateComponent);
    dialogRef.afterClosed().subscribe({
      next: (val) => {
        if (val) {
          this.getPersonList();
        }
      }
    })
  }

  openEditPersonForm(data:any) {
    const dialogRef = this._dialog.open(PersonCreateComponent, {
      data,
    });

    dialogRef.afterClosed().subscribe({
      next: (val) => {
        if (val) {
          this.getPersonList();
        }
      }
    })
    
  }

  getPersonList() {
    this._personService.GetPersons().subscribe({
      next: (res) => {
        this.dataSource = new MatTableDataSource(res);
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
      },
      error: console.log,
    })
  }

  deletePerson(id: number) {
    this._personService.deletePerson(id).subscribe({
      next: (res) => {
        this._coreService.openSnackBar('Pessoa deletada com sucesso', 'done')
        this.getPersonList();
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
