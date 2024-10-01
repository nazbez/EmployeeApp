import { Component, Inject } from '@angular/core';
import { MatButton, MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-confirmation-modal',
  standalone: true,
  imports: [MatButtonModule],
  templateUrl: './confirmation-modal.component.html',
  styleUrl: './confirmation-modal.component.css'
})
export class ConfirmationModalComponent {
  constructor(
    @Inject(MAT_DIALOG_DATA) public title: string,
    private dialogRef: MatDialogRef<ConfirmationModalComponent>) {}
    
    reject() {
      this.dialogRef.close(false);
    }
    
    confirm() {
      this.dialogRef.close(true);
    }
}
