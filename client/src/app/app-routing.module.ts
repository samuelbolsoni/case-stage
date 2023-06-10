import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AreaComponent } from './area/area.component';

const routes: Routes = [
  {path: 'areas', component: AreaComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
