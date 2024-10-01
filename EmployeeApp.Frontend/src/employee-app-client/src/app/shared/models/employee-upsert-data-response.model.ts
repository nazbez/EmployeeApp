import { DepartmentModel } from "./department.model";
import { ManagerModel } from "./manager.model";

export interface EmployeeUpsertDataResponseModel {
    departments: DepartmentModel[];
    managers: ManagerModel[];
}