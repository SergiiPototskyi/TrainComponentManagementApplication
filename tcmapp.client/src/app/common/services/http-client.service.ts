import { HttpClient, HttpErrorResponse, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NotificationService } from './notification.service';
import { catchError, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpClientService {
  constructor(private http: HttpClient, private notificationService: NotificationService) {}

  public get<T>(url: string, params?: HttpParams): Observable<T> {    
    return this.http.get<T>(url, { params })
    .pipe(catchError(error => this.handleError(error)));
  }

  public post<T>(url: string, body: any): Observable<T> {
    return this.http.post<T>(url, body)
    .pipe(catchError(error => this.handleError(error)));
  }

  public put<T>(url: string, body: any): Observable<T> {
    return this.http.put<T>(url, body)
    .pipe(catchError(error => this.handleError(error)));
  }

  public delete<T>(url: string): Observable<T> {
    return this.http.delete<T>(url)
      .pipe(catchError(error => this.handleError(error)));
  }

  public handleError(error: HttpErrorResponse) {
    console.error('HTTP Error:', error);

    let errorMessage = 'An unknown error occurred!';
    if (error.error instanceof ErrorEvent) {
      errorMessage = `Client error: ${error.error.message}`;
    } else {
      errorMessage = `Server error ${error.status}: ${error.error}`;
    }
    this.notificationService.showError(errorMessage);

    return throwError(() => new Error(errorMessage));
  }
}
