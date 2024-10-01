import { Component, Inject, OnInit } from '@angular/core';
import { EmployeeService } from '../shared/services/employee.service';
import { ManagerModel } from '../shared/models/manager.model';
import { DepartmentModel } from '../shared/models/department.model';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatOptionModule } from '@angular/material/core';
import { MatSelectModule } from '@angular/material/select';
import { CreateEmployeeButtonComponent } from '../create-employee-button/create-employee-button.component';
import { MatIconModule } from '@angular/material/icon';
import { CommonModule } from '@angular/common';
import { MatButtonModule, MatIconButton } from '@angular/material/button';
import { EmployeeDataResponseModel } from '../shared/models/employee-data-response.model';
import { EmployeeUpsertRequestModel } from '../shared/models/employee-upsert-request.model';
import { ToastrService } from 'ngx-toastr';

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
    MatButtonModule,
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
  data!: EmployeeDataResponseModel;

  constructor(
    private readonly employeeService: EmployeeService,
    private dialogRef: MatDialogRef<ManageEmployeeModalComponent>,
    private readonly toastr: ToastrService,
    @Inject(MAT_DIALOG_DATA) public employeeId: number) { }

  ngOnInit(): void {
    this.employeeService.getUpsertData()
      .subscribe(result => {
        this.managers = result.managers;
        this.departments = result.departments;
      });
    
    this.employeeFormGroup = new FormGroup({
      name: new FormControl('', [Validators.required]),
      surname: new FormControl('', [Validators.required]),
      salary: new FormControl('', [Validators.required, Validators.min(1)]),
      manager: new FormControl('', [Validators.required, Validators.min(1)]),
      department: new FormControl('', [Validators.required]),
    });

    if (this.employeeId) {
      this.isUpdating = true;
      this.employeeService.getById(this.employeeId)
      .subscribe(result => {
        this.data = result;
        this.employeeFormGroup = new FormGroup({
          name: new FormControl(this.data.name, [Validators.required]),
          surname: new FormControl(this.data.surname, [Validators.required]),
          salary: new FormControl(this.data.salary, [Validators.required, Validators.min(1)]),
          manager: new FormControl(this.data.manager.id, [Validators.required, Validators.min(1)]),
          department: new FormControl(this.data.department.id, [Validators.required]),
        });
    
      });
    }
  }

  validateControl = (controlName: string) => {
    return this.employeeFormGroup.get(controlName)!.invalid && this.employeeFormGroup.get(controlName)!.touched;
  }

  hasError = (controlName: string, errorName: string) => {
    return this.employeeFormGroup.get(controlName)!.hasError(errorName);
  }

  save(value: any) {
    this.showError = false;

    if (this.isUpdating) {
      this.updateEmployee(value)
    } else {
      this.createEmployee(value);
    }
  }

  private updateEmployee(value: any) {
    const createEmployee = {... value };
    const upsertRequest: EmployeeUpsertRequestModel = {
      name: createEmployee.name,
      surname: createEmployee.surname,
      salary: createEmployee.salary,
      managerId: createEmployee.manager,
      departmentId: createEmployee.department
    };

    this.employeeService.update(this.employeeId, upsertRequest)
      .subscribe(res => {
        this.toastr.success('Employee is added!', 'Success!');
        this.dialogRef.close(res);
      });
  }

  private createEmployee(value: any) {
    const createEmployee = {... value };
    const upsertRequest: EmployeeUpsertRequestModel = {
      name: createEmployee.name,
      surname: createEmployee.surname,
      salary: createEmployee.salary,
      managerId: createEmployee.manager,
      departmentId: createEmployee.department
    };

    this.employeeService.create(upsertRequest)
      .subscribe(res => {
        this.toastr.success('Employee is added!', 'Success!');
        this.dialogRef.close(res);
      });
  }
}
