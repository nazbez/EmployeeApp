import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageEmployeeModalComponent } from './manage-employee-modal.component';
import { MatOptionModule } from '@angular/material/core';

describe('ManageEmployeeModalComponent', () => {
  let component: ManageEmployeeModalComponent;
  let fixture: ComponentFixture<ManageEmployeeModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        ManageEmployeeModalComponent, 
        MatOptionModule]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ManageEmployeeModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
