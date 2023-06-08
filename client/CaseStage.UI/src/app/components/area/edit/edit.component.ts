import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Area } from 'src/app/models/area';
import { AreaService } from 'src/app/services/area.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {

  @Input() area?: Area;
  @Output() areasUpdated = new EventEmitter<Area[]>();
  
  constructor(private areaService: AreaService) { }

  ngOnInit(): void {
  }

  updateArea(area:Area) {
    this.areaService
      .updateArea(area)
      .subscribe((areas: Area[]) => this.areasUpdated.emit(areas));
  }

  deleteArea(area:Area) {
    this.areaService
      .deleteArea(area)
      .subscribe((areas: Area[]) => this.areasUpdated.emit(areas));
  }

  createArea(area:Area) {
    this.areaService
      .createArea(area)
      .subscribe((areas: Area[]) => this.areasUpdated.emit(areas));
  }
}
