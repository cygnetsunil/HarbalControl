import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpCallService {
  baseUrl: string = environment.baseUrl;
  windurl: string = environment.OpenWeatherUrl;
  constructor(private http: HttpClient) { }
  public GetWindDetails<T>(): Observable<T> {
    return this.http.get<T>(this.windurl).pipe(catchError(this.handleError));
  }
  public get<T>(url: string): Observable<T> {
    return this.http.get<T>(this.baseUrl + url).pipe(catchError(this.handleError));
  }
  public delete<T>(url: string): Observable<T> {
    return this.http.delete<T>(this.baseUrl + url).pipe(catchError(this.handleError));
  }
  public post<T>(url: string, model: any): Observable<T> {
    return this.http.post<T>(this.baseUrl + url, model).pipe(catchError(this.handleError));
  }
  public put<T>(url: string, model: any): Observable<T> {
    return this.http.put<T>(this.baseUrl + url, model).pipe(catchError(this.handleError));
  }
  public handleError(error: HttpErrorResponse) {
    return throwError(error);
  }
}
