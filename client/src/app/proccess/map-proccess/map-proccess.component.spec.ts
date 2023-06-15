import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MapProccessComponent } from './map-proccess.component';

describe('MapProccessComponent', () => {
  let component: MapProccessComponent;
  let fixture: ComponentFixture<MapProccessComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MapProccessComponent]
    });
    fixture = TestBed.createComponent(MapProccessComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
