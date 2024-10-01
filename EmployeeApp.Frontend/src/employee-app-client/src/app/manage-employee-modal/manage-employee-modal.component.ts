import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../shared/services/employee.service';
import { ManagerModel } from '../shared/models/manager.model';
import { DepartmentModel } from '../shared/models/department.model';
import { MatDialogClose, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatOptionModule } from '@angular/material/core';
import { MatSelectModule } from '@angular/material/select';
import { CreateEmployeeButtonComponent } from '../create-employee-button/create-employee-button.component';
import { MatIconModule } from '@angular/material/icon';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-manage-employee-modal',
  standalone: true,
  imports: [
    MatOptionModule, 
    MatSelectModule, 
    ReactiveFormsModule ,
    MatIconModule,
    CommonModule,
    MatDialogModule,
    CreateEmployeeButtonComponent],
  templateUrl: './manage-employee-modal.component.html',
  styleUrl: './manage-employee-modal.component.css'
})
export class ManageEmployeeModalComponent implements OnInit {
  managers!: ManagerModel[];
  departments!: DepartmentModel[];
  employeeFormGroup!: FormGroup;
  errorMessage: string = '';
  showError!: boolean;
  isUpdating = false;

  constructor(
    private readonly employeeService: EmployeeService,
    ) { }

  ngOnInit(): void {
    this.employeeService.getUpsertData()
      .subscribe(result => {
        this.managers = result.managers;
        this.departments = result.departments;
      });

    this.employeeFormGroup = new FormGroup({
      name: new FormControl('', [Validators.required]),
      surname: new FormControl('', [Validators.required]),
      salary: new FormControl('', [Validators.required, Validators.min(0)]),
      manager: new FormControl('', [Validators.required, Validators.min(1)]),
      department: new FormControl('', [Validators.required]),
    });
  }

  validateControl = (controlName: string) => {
    return this.employeeFormGroup.get(controlName)!.invalid && this.employeeFormGroup.get(controlName)!.touched;
  }

  hasError = (controlName: string, errorName: string) => {
    return this.employeeFormGroup.get(controlName)!.hasError(errorName);
  }

  save(value: any) {
    console.log(value);
    this.showError = false;
  }
}
