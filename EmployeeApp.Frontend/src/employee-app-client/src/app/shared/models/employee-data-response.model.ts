import { DepartmentModel } from "./department.model";
import { ManagerModel } from "./manager.model";

export interface EmployeeDataResponseModel {
    id: number,
    name: string,
    surname: string,
    salary: number,
    manager: ManagerModel,
    department: DepartmentModel
}