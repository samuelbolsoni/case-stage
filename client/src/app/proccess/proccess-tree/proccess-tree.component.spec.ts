import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProccessTreeComponent } from './proccess-tree.component';

describe('ProccessTreeComponent', () => {
  let component: ProccessTreeComponent;
  let fixture: ComponentFixture<ProccessTreeComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ProccessTreeComponent]
    });
    fixture = TestBed.createComponent(ProccessTreeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
