import { Component } from '@angular/core';
import { CreateEmployeeButtonComponent } from '../create-employee-button/create-employee-button.component';
import { EmployeeTableComponent } from '../employee-table/employee-table.component';

@Component({
  selector: 'app-employee',
  standalone: true,
  imports: [
    CreateEmployeeButtonComponent,
    EmployeeTableComponent
  ],
  templateUrl: './employee.component.html',
  styleUrl: './employee.component.css'
})
export class EmployeeComponent {

}
