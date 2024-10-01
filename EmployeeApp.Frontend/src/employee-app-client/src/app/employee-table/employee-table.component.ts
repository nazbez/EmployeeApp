import { Component, OnInit, ViewChild } from '@angular/core';
import { EmployeeModel } from '../shared/models/employee.model';
import { EmployeeService } from '../shared/services/employee.service';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { catchError, map, Observable, of, startWith, switchMap } from 'rxjs';
import { CommonModule } from '@angular/common';
import { ColumnNamePipe } from '../shared/pipes/column-name.pipe';
import { PaginatedEmployeeListResponseModel } from '../shared/models/paginated-employee-list-response.model';

@Component({
  selector: 'app-employee-table',
  standalone: true,
  imports: [
    MatTableModule,
    MatPaginatorModule,
    MatPaginatorModule,
    MatProgressBarModule,
    CommonModule,
    ColumnNamePipe],
  templateUrl: './employee-table.component.html',
  styleUrl: './employee-table.component.css'
})
export class EmployeeTableComponent implements OnInit {
  displayedColumns: string[] = [
    'name',
    'surname',
    'departmentName',
    'managerName',
    'salary',
  ];

  pageSizes = [10, 25, 50];
  dataSource = new MatTableDataSource<EmployeeModel>();
  isLoading = false;
  pagedEmployeeList!: PaginatedEmployeeListResponseModel;
  totalData!: number;
  employees!: EmployeeModel[];

  @ViewChild('paginator') paginator!: MatPaginator;

  constructor(private readonly employeeService: EmployeeService) {}

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
}

