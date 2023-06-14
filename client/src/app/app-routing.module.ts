import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AreaComponent } from './area/area.component';
import { SystemComponent } from './system/system.component';
import { PersonComponent } from './person/person.component';
import { ProccessComponent } from './proccess/proccess.component';
import { ProccessTreeComponent } from './proccess/proccess-tree/proccess-tree.component';
import { MapTreeComponent } from './proccess/map-tree/map-tree.component';

const routes: Routes = [
  {path: 'areas', component: AreaComponent},
  {path: 'systems', component: SystemComponent},
  {path: 'person', component: PersonComponent},
  {path: 'proccess', component: ProccessComponent},
  {path: 'proccess-map', component: ProccessTreeComponent},
  {path: 'map', component: MapTreeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
