import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CoreService } from 'src/app/core/core.service';
import { SystemService } from 'src/app/services/system.service';

@Component({
  selector: 'app-system-create',
  templateUrl: './system-create.component.html',
  styleUrls: ['./system-create.component.css']
})
export class SystemCreateComponent implements OnInit {
  systemForm: FormGroup;

  constructor(
    private _fb: FormBuilder, 
    private systemService: SystemService, 
    private _dialogRef: MatDialogRef<SystemCreateComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private _coreService: CoreService

    ) {
    this.systemForm = this._fb.group({
      name: '',
      active: true
    })
  }

  ngOnInit(): void {
    this.systemForm.patchValue(this.data);
  }

  onFormSubmit(){
    if (this.systemForm.valid) {

      if (this.data) {
        this.systemService.updateSystem(this.data.id, this.systemForm.value).subscribe({
          next: (val: any) => {
            this._coreService.openSnackBar('Sistema atualizado com sucesso')
            this._dialogRef.close(true);
          },
          error: (err: any) => {
            console.error(err);
          }
        })
      } else {
        console.log(this.systemForm.value);
        this.systemService.createSystem(this.systemForm.value).subscribe({
          next: (val: any) => {
            this._coreService.openSnackBar('Sistema criado com sucesso', 'done')
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
