import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json',
    'Authorization': 'my-auth-token'
  })
};

@Injectable()
export class FeedService {
  private baseUrl: string;
  constructor(private router: Router,
    public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
   }

   GetFeeds(): Observable<any> {
    return this.http.get<any>(this.baseUrl  + 'api/Feed/GetFeeds/', httpOptions);
   }
   GetTopWordFromTopic(): Observable<any> {
    return this.http.get<any>(this.baseUrl  + 'api/Feed/GetTopWordFromTopic/', httpOptions);
   }

}

