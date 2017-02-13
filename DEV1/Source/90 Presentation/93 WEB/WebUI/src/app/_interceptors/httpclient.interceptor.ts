import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';

@Injectable()
export class HttpClient {
  
    constructor(private http: Http, private apiUrl: string) {
        this.apiUrl = 'http://promanagerapi.leadersoft.gr/';
    }

    createAuthorizationHeader(headers: Headers) {
        headers.append('Authorization', 'Basic ' +
            btoa('username:password'));
        headers.append('Content-Type','application/x-www-form-urlencoded');
    }

    get(url) {
        let headers = new Headers();
        this.createAuthorizationHeader(headers);
        url = this.apiUrl + url;
        return this.http.get(url, {
            headers: headers
        });
    }

    post(url, data) {
        let headers = new Headers();
        this.createAuthorizationHeader(headers);
        url = this.apiUrl + url;
        return this.http.post(url, data, {
            headers: headers
        });
    }

    put(url, data)
    {
        let headers = new Headers();
        this.createAuthorizationHeader(headers);
        url = this.apiUrl + url;
        return this.http.put(url, data, {
                headers: headers
         });            
    } 

    delete(url, data)
    {
        let headers = new Headers();
        this.createAuthorizationHeader(headers);
        url = this.apiUrl + url;
        return this.http.delete(url, { headers: headers }); 
    }
 
}