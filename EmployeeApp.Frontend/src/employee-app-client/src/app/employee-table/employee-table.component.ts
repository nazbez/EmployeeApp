import { Component, OnInit, ViewChild } from '@angular/core';
import { EmployeeModel } from '../shared/models/employee.model';
import { EmployeeService } from '../shared/services/employee.service';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { catchError, map, Observable, of, startWith, switchMap } from 'rxjs';
import { CommonModule } from '@angular/common';
import { PaginatedEmployeeListResponseModel } from '../shared/models/paginated-employee-list-response.model';
import { MatIconModule } from '@angular/material/icon';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmationModalComponent } from '../confirmation-modal/confirmation-modal.component';
import { ManageEmployeeModalComponent } from '../manage-employee-modal/manage-employee-modal.component';

@Component({
  selector: 'app-employee-table',
  standalone: true,
  imports: [
    MatTableModule,
    MatPaginatorModule,
    MatPaginatorModule,
    MatProgressBarModule,
    CommonModule,
    MatIconModule,
    ConfirmationModalComponent,
    ManageEmployeeModalComponent],
  templateUrl: './employee-table.component.html',
  styleUrl: './employee-table.component.css'
})
export class EmployeeTableComponent implements OnInit {
  displayedColumns: string[] = [
    'name', 
    'surname',
    'salary', 
    'managerName', 
    'departmentName',
    'update',
    'delete'
  ];

  pageSizes = [10, 25, 50];
  dataSource = new MatTableDataSource<EmployeeModel>();
  isLoading = false;
  pagedEmployeeList!: PaginatedEmployeeListResponseModel;
  totalData!: number;
  employees!: EmployeeModel[];

  @ViewChild('paginator') paginator!: MatPaginator;

  constructor(
    private readonly employeeService: EmployeeService,
    private readonly dialog: MatDialog) {}

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;

    this.paginator.page
      .pipe(
        startWith({}),
        switchMap(() => {
          this.isLoading = true;
          return this.getTableData$(
            this.paginator.pageIndex + 1,
            this.paginator.pageSize
          ).pipe(catchError(() => of(null)));
        }),
        map((empData) => {
          if (empData == null) return [];
          this.totalData = empData.totalCount;
          this.isLoading = false;
          return empData.items;
        })
      )
      .subscribe((empData) => {
        this.employees = empData;
        this.dataSource = new MatTableDataSource(this.employees);
      });
  }

  ngOnInit(): void { }

  getTableData$(pageNumber: number, pageSize: number): Observable<PaginatedEmployeeListResponseModel> {
    return this.employeeService.getAll(pageNumber, pageSize);
  }

  updateEmployee(id: number) {
    const dialogRef = this.dialog.open(ManageEmployeeModalComponent, {
      width: '600px',
      data: id
    });
}

deleteEmployee(id: number) {
  const dialogRef = this.dialog.open(ConfirmationModalComponent, {
    width: '400px',
    height: '200px',
    data: 'Delete employee'
  });
  
  dialogRef.afterClosed().subscribe(res => {
    if (res) {
        this.employeeService.delete(id)
            .subscribe(_ => {
                this.dataSource.data = this.dataSource.data.filter(x => x.id !== id);
            })
          }
        });
      }
}

