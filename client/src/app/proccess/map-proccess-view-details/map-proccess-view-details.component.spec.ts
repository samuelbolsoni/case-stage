import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MapProccessViewDetailsComponent } from './map-proccess-view-details.component';

describe('MapProccessViewDetailsComponent', () => {
  let component: MapProccessViewDetailsComponent;
  let fixture: ComponentFixture<MapProccessViewDetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MapProccessViewDetailsComponent]
    });
    fixture = TestBed.createComponent(MapProccessViewDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
