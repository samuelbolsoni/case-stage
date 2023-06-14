import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AreaComponent } from './area/area.component';

import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { AreaCreateComponent } from './area/area-create/area-create.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { TranslateBoolPipe } from './utils/pipes/translate-bool.pipe';
import { SystemComponent } from './system/system.component';
import { SystemCreateComponent } from './system/system-create/system-create.component';
import { PersonComponent } from './person/person.component';
import { PersonCreateComponent } from './person/person-create/person-create.component';
import { ProccessComponent } from './proccess/proccess.component';
import { ProccessCreateComponent } from './proccess/proccess-create/proccess-create.component';
import { MatSelectModule } from '@angular/material/select';
import { MatTreeModule } from '@angular/material/tree';
import { ProccessTreeComponent } from './proccess/proccess-tree/proccess-tree.component';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import { MapTreeComponent } from './proccess/map-tree/map-tree.component';
import {AngularTreeGridModule} from 'angular-tree-grid';
import {MatMenuModule} from '@angular/material/menu';

@NgModule({
  declarations: [
    AppComponent,
    AreaComponent,
    AreaCreateComponent,
    SystemComponent,
    SystemCreateComponent,
    PersonComponent,
    PersonCreateComponent,
    ProccessComponent,
    ProccessCreateComponent,
    ProccessTreeComponent,
    TranslateBoolPipe,
    MapTreeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatSnackBarModule,
    MatCheckboxModule,
    MatSelectModule,
    MatTreeModule,
    MatProgressBarModule,
    AngularTreeGridModule,
    MatMenuModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
