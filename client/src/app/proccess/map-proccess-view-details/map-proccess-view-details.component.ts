import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Observable } from 'rxjs';
import { Area } from 'src/app/area/model/area';
import { Person } from 'src/app/person/model/person';
import { System } from 'src/app/system/model/system';
import { Proccess } from '../model/proccess';
import { ProccessService } from 'src/app/services/proccess.service';
import { AreaService } from 'src/app/services/area.service';
import { PersonService } from 'src/app/services/person.service';
import { SystemService } from 'src/app/services/system.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CoreService } from 'src/app/core/core.service';

@Component({
  selector: 'app-map-proccess-view-details',
  templateUrl: './map-proccess-view-details.component.html',
  styleUrls: ['./map-proccess-view-details.component.css']
})
export class MapProccessViewDetailsComponent implements OnInit {

  proccessViewForm!: FormGroup;
  areasFormControl = new FormControl();
  personsFormControl = new FormControl();
  parentsFormControl = new FormControl();
  systemAppsFormControl = new FormControl();
  descriptionFormControl = new FormControl();

  areasList!: Observable<Area[]>;
  personsList!: Observable<Person[]>;
  systemsList!: Observable<System[]>;
  proccessList!: Observable<Proccess[]>;

  areaSelected: any;
  parentSelected: any;
  personsSelected: any[] = [];
  systemsSelected: any[] = [];

  isDisabled = false;

  constructor(private _fb: FormBuilder, 
    private _proccessService: ProccessService, 
    private _areaService: AreaService,
    private _personService: PersonService,
    private _systemService: SystemService,
    private _dialogRef: MatDialogRef<MapProccessViewDetailsComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private _coreService: CoreService
    ) {
      this.proccessViewForm = this._fb.group({
        areas: '',
        parents: '',
        description: '',
        documentation: '',
        active: true,
        persons: [],
        systemsApps: []
      })
    }

  ngOnInit(): void {
    console.log(this.data);
    this.areasList = this._areaService.GetAreas();
    this.personsList = this._personService.GetPersons();
    this.systemsList = this._systemService.GetSystems();
    this.proccessList = this._proccessService.GetProccess();

    this.areaSelected = this.data.areaId;
    this.parentSelected = this.data.idParent;
    this.personsSelected = this.data.persons;
    this.systemsSelected = this.data.systems;

    this.loadDataToSelectFields();

    this.proccessViewForm.patchValue(this.data);
  }

  onFormSubmit(){
    if (this.proccessViewForm.valid) {
      
      var formSubmited = this.proccessViewForm.value;
      
      //Parse select fields
      formSubmited.areaId = this.areasFormControl.value;
      formSubmited.persons = this.personsFormControl.value;
      formSubmited.systemApps = this.systemAppsFormControl.value;
      formSubmited.idParent = this.parentsFormControl.value;

      if (this.data) {
        this._proccessService.updateProccess(this.data.id, formSubmited).subscribe({
          next: (val: any) => {
            this._coreService.openSnackBar('Processo atualizado com sucesso')
            this._dialogRef.close(true);
          },
          error: (err: any) => {
            console.error(err);
          }
        })
      } else {
        this._proccessService.createProccess(formSubmited).subscribe({
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

  loadDataToSelectFields() {

    //Area
    const selectedArea: any = this.areaSelected;
    const selectedParent: any = this.parentSelected;
    const selectedPersons: any[] = this.personsSelected;
    const selectedSystems: any[] = this.systemsSelected;

    const loadPersonsToSelect: any[] = [];
    const loadSystemsToSelect: any[] = [];

    selectedPersons.forEach((name, index, array) => {
      loadPersonsToSelect.push(array[index].personId);
    });

    selectedSystems.forEach((name, index, array) => {
      loadSystemsToSelect.push(array[index].systemId);
    });

    this.areasFormControl.setValue(selectedArea);
    this.parentsFormControl.setValue(selectedParent);
    this.personsFormControl.setValue(loadPersonsToSelect);
    this.systemAppsFormControl.setValue(loadSystemsToSelect);
    
    this.areasFormControl.disable();
    this.personsFormControl.disable();
    this.systemAppsFormControl.disable();
    this.parentsFormControl.disable();
    this.descriptionFormControl.disable();
  }
}
