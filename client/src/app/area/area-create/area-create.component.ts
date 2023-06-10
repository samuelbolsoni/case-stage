import { Component, Inject, OnInit } from '@angular/core';
import { inject } from '@angular/core/testing';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CoreService } from 'src/app/core/core.service';
import { AreaService } from 'src/app/services/area.service';

@Component({
  selector: 'app-area-create',
  templateUrl: './area-create.component.html',
  styleUrls: ['./area-create.component.css']
})
export class AreaCreateComponent implements OnInit {
  areaForm: FormGroup;

  constructor(
    private _fb: FormBuilder, 
    private areaService: AreaService, 
    private _dialogRef: MatDialogRef<AreaCreateComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private _coreService: CoreService

    ) {
    this.areaForm = this._fb.group({
      name: ''
    })
  }

  ngOnInit(): void {
    this.areaForm.patchValue(this.data);
  }

  onFormSubmit(){
    if (this.areaForm.valid) {

      if (this.data) {
        this.areaService.updateArea(this.data.id, this.areaForm.value).subscribe({
          next: (val: any) => {
            this._coreService.openSnackBar('Area atualizada com sucesso')
            this._dialogRef.close(true);
          },
          error: (err: any) => {
            console.error(err);
          }
        })
      } else {
        this.areaService.createArea(this.areaForm.value).subscribe({
          next: (val: any) => {
            this._coreService.openSnackBar('Area criada com sucesso', 'done')
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
