import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AreaComponent } from './area/area.component';
import { SystemComponent } from './system/system.component';
import { PersonComponent } from './person/person.component';
import { ProccessComponent } from './proccess/proccess.component';

const routes: Routes = [
  {path: 'areas', component: AreaComponent},
  {path: 'systems', component: SystemComponent},
  {path: 'person', component: PersonComponent},
  {path: 'proccess', component: ProccessComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
