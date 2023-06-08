import { Component } from '@angular/core';
import { Area } from './models/area';
import { AreaService } from './services/area.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'CaseStage.UI';
  areas: Area[] = [];
  areaToEdit?: Area;

  constructor(private areaService: AreaService) {}

  ngOnInit() : void {
    this.areaService
        .GetAreas()
        .subscribe((result: Area[]) => (this.areas = result));
  }

  updateAreaList(areas: Area[]) {
    this.areas = areas;
  }
  
  initNewArea() {
    this.areaToEdit = new Area();
  }

  editArea(area: Area) {
    this.areaToEdit = area;
  }
}
