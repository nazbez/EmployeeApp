import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
import { ManageEmployeeModalComponent } from '../manage-employee-modal/manage-employee-modal.component';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-create-employee-button',
  standalone: true,
  imports: [MatButtonModule],
  templateUrl: './create-employee-button.component.html',
  styleUrl: './create-employee-button.component.css'
})
export class CreateEmployeeButtonComponent {
  constructor(
    private readonly dialog: MatDialog,
    private readonly toastr: ToastrService) {}

  createNewEmployee(): void {
    const dialogRef = this.dialog.open(ManageEmployeeModalComponent, {
      width: '600px',
      data: undefined
    });
  }
}
