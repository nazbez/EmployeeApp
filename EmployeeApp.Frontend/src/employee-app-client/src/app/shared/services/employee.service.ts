import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { PaginatedEmployeeListResponseModel } from "../models/paginated-employee-list-response.model";
import { environment } from "../../../environments/environment";
import { EmployeeUpsertDataResponseModel } from "../models/employee-upsert-data-response.model";
import { EmployeeUpsertRequestModel } from "../models/employee-upsert-request.model";

@Injectable({
    providedIn: 'root'
})
export class EmployeeService {
    private url = `${environment.apiUrl}/api/v1/Employee`

    constructor(private readonly httpClient: HttpClient) {}

    public getAll(pageNumber: number, pageSize: number): Observable<PaginatedEmployeeListResponseModel> {
        return this.httpClient.get<PaginatedEmployeeListResponseModel>(this.url, {params: { pageNumber, pageSize }});
    }

    public getUpsertData(): Observable<EmployeeUpsertDataResponseModel> {
        return this.httpClient.get<EmployeeUpsertDataResponseModel>(`${this.url}/upsert-data`);
    }
    
    public create(requestModel: EmployeeUpsertRequestModel): Observable<object> {
        return this.httpClient.post(this.url, requestModel);
    }

    public update(id: number, requestModel: EmployeeUpsertRequestModel): Observable<object> {
        return this.httpClient.put(`${this.url}/${id}`, requestModel);
    }

    public delete(id: number): Observable<object> {
        return this.httpClient.delete(`${this.url}/${id}`);
    }
}