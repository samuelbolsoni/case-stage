import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AreaCreateComponent } from './area-create.component';

describe('AreaCreateComponent', () => {
  let component: AreaCreateComponent;
  let fixture: ComponentFixture<AreaCreateComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AreaCreateComponent]
    });
    fixture = TestBed.createComponent(AreaCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
