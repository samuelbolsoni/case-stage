import { Component, Inject, OnInit } from '@angular/core';
import { inject } from '@angular/core/testing';
import { FormArray, FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CoreService } from 'src/app/core/core.service';
import { ProccessService } from 'src/app/services/proccess.service';
import { AreaService } from 'src/app/services/area.service';
import { PersonService } from 'src/app/services/person.service';
import { Observable } from 'rxjs';
import { Person } from 'src/app/person/model/person';
import { System } from 'src/app/system/model/system';
import { SystemService } from 'src/app/services/system.service';
import { Area } from 'src/app/area/model/area';

@Component({
  selector: 'app-proccess-create',
  templateUrl: './proccess-create.component.html',
  styleUrls: ['./proccess-create.component.css']
})
export class ProccessCreateComponent implements OnInit {
  proccessForm: FormGroup;
  areas!: Observable<Area[]>;
  personsList!: Observable<Person[]>;
  systemsList!: Observable<System[]>;
  
  persons = new FormControl();
  systemApps = new FormControl();
  
  constructor(
    private _fb: FormBuilder, 
    private proccessService: ProccessService, 
    private _areaService: AreaService,
    private _personService: PersonService,
    private _systemService: SystemService,
    private _dialogRef: MatDialogRef<ProccessCreateComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private _coreService: CoreService

    ) {
    this.proccessForm = this._fb.group({
      areas: '',
      description: '',
      documentation: '',
      active: true,
      persons: [],
      systemsApps: []
    })
  }

  ngOnInit(): void {
    this.areas = this._areaService.GetAreas();
    this.personsList = this._personService.GetPersons();
    this.systemsList = this._systemService.GetSystems();
    this.proccessForm.patchValue(this.data);
  }

  onFormSubmit(){
    if (this.proccessForm.valid) {
      
      var formSubmited = this.proccessForm.value;

      //Parse fields
      formSubmited.areaId = formSubmited.areas;
      formSubmited.persons = this.persons.value;
      formSubmited.systemApps = this.systemApps.value;

      if (this.data) {
        this.proccessService.updateProccess(this.data.id, formSubmited).subscribe({
          next: (val: any) => {
            this._coreService.openSnackBar('Processo atualizado com sucesso')
            this._dialogRef.close(true);
          },
          error: (err: any) => {
            console.error(err);
          }
        })
      } else {

        this.proccessService.createProccess(formSubmited).subscribe({
          next: () => {
            this._coreService.openSnackBar('Processo criado com sucesso', 'done')
            this._dialogRef.close(true);
          },
          error: (err: any) => {
            console.error(err);
          }
        })
        
      }
    }
  }
}
