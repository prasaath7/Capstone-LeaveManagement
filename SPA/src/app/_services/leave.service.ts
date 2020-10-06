import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Requests } from '../_models/requests';
import { User } from '../_models/user';
import { Leaves } from '../_models/leaves';

const httpOptions = {
  headers: new HttpHeaders({
    // tslint:disable-next-line: object-literal-key-quotes
    'Authorization': 'Bearer ' + localStorage.getItem('token')
  })
};


@Injectable({
  providedIn: 'root'
})
export class LeaveService {
  baseUrl = environment.apiUrl;
  TotalDays: number;

constructor(private http: HttpClient) { }

submitRequest(model: any) {
  return this.http.post(this.baseUrl + 'request/requests' , model , httpOptions);
}

getRequests(): Observable<Requests[]> {

  return this.http.get<Requests[]> (this.baseUrl + 'leaveaction', httpOptions );
}

sendResponse(model: any) {
  return this.http.post(this.baseUrl + 'leaveaction/response' , model , httpOptions);
}

getDays(): Observable<number> {
  return this.http.get<number> (this.baseUrl + 'leaveaction/getdays', httpOptions);
}

setDays(days: any) {
  let params = new HttpParams();
  params = params.append('TotalDays', days);
  const headers = new HttpHeaders({
    Authorization: 'Bearer ' + localStorage.getItem('token')
  });
  return this.http.post(this.baseUrl + 'leaveaction/setdays', null , {headers, params});
}

getLeaves(id): Observable<Leaves> {
  return this.http.get<Leaves> (this.baseUrl + 'request/' + id , httpOptions );
}

}
