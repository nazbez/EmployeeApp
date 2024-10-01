import { EmployeeModel } from "./employee.model";

export interface PaginatedEmployeeListResponseModel {
    items: EmployeeModel[],
    pageNumber: number,
    totalPages: number,
    totalCount: number,
    hasPreviousPage: boolean,
    hasNextPage: boolean
}