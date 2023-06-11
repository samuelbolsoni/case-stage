import { Component, Inject, OnInit } from '@angular/core';
import { inject } from '@angular/core/testing';
import { FormBuilder, FormControl, FormGroup, FormGroupDirective, NgForm, Validators } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CoreService } from 'src/app/core/core.service';
import { PersonService } from 'src/app/services/person.service';

/*
/** Error when invalid control is dirty, touched, or submitted. */
/*
export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}
*/
@Component({
  selector: 'app-person-create',
  templateUrl: './person-create.component.html',
  styleUrls: ['./person-create.component.css']
})
export class PersonCreateComponent implements OnInit {
  personForm: FormGroup;

  constructor(
    private _fb: FormBuilder, 
    private personService: PersonService, 
    private _dialogRef: MatDialogRef<PersonCreateComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private _coreService: CoreService

    ) {
    this.personForm = this._fb.group({
      name: '',
      email: new FormControl('', Validators.email),
      active: true
    })
  }

  ngOnInit(): void {
    this.personForm.patchValue(this.data);
  }

  onFormSubmit(){
    if (this.personForm.valid) {

      if (this.data) {
        this.personService.updatePerson(this.data.id, this.personForm.value).subscribe({
          next: (val: any) => {
            this._coreService.openSnackBar('Pessoa atualizada com sucesso')
            this._dialogRef.close(true);
          },
          error: (err: any) => {
            console.error(err);
          }
        })
      } else {
        console.log(this.personForm.value);
        this.personService.createPerson(this.personForm.value).subscribe({
          next: (val: any) => {
            this._coreService.openSnackBar('Pessoa criada com sucesso', 'done')
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
