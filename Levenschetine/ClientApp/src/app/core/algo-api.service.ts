import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import {IForm} from '../core/interfaces/IForm'


import {  throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { Subject, BehaviorSubject } from 'rxjs';

interface Result {
  FirstInput :string,
  SecondInput :string,
  Distance :number,
  Matrix :number[][]
}

@Injectable({
  providedIn: 'root'
})
export class AlgoApiService {

  private Levenshtein_Distance_API = environment.api_url;
  
  destroy$: Subject<boolean> = new Subject<boolean>();

  constructor(private httpClient: HttpClient) { }

  apiData = new BehaviorSubject<any>("")
  apiDataObservable = this.apiData.asObservable();

  updateApiData(data: any){
      this.apiData.next(data);
  }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'secretKey': environment.secretKey,
    })
  };

  sendPostRequest(formInputsObj:IForm){
    return this.httpClient.post<Result>(this.Levenshtein_Distance_API, formInputsObj, this.httpOptions ).pipe(retry(3), catchError(this.handleError));
  }

  ngOnDestroy() {
    this.destroy$.next(true);
    // Unsubscribe from the subject
    this.destroy$.unsubscribe();
  }

  handleError(error: HttpErrorResponse) {
    let errorMessage = 'Unknown error!';
    if (error.error instanceof ErrorEvent) {
      // Client-side errors
      errorMessage = `Error: ${error.error.message}`;
    } else {
      // Server-side errors
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    window.alert(errorMessage);
    return throwError(errorMessage);
  }
}
