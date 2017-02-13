import { Injectable } from '@angular/core';
import { Http, Headers, Response } from '@angular/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map'
import { HttpClient } from '../_interceptors/httpclient.interceptor';
import { LocalStorageService } from 'angular-2-local-storage';

@Injectable()
export class AuthenticationService {
    public token: string;   
    private apiUrl: string = 'http://promanagerapi.leadersoft.gr/';

    constructor(private http: Http) {
        // set token if saved in local storage
        var currentUser = JSON.parse(localStorage.getItem('currentUser'));
        this.token = currentUser && currentUser.token;       
    }

    login(email: string, password: string){
        let headers = new Headers();
        headers.append('Content-Type', 'application/x-www-form-urlencoded');
        return this.http.post(this.apiUrl + 'token', 'grant_type=password&username=' + email + '&password=' + password,{ headers })
            .map((response: Response) => {
                // login successful if there's a jwt token in the response                
                if (response.json() && response.json().access_token) {
                    let token = response.json().access_token;
                    // set token property
                    this.token = token;
                    // store username and jwt token in local storage to keep user logged in between page refreshes
                    localStorage.setItem('currentUser', JSON.stringify({ email: email, token: token }));
                    localStorage.setItem('auth_token', token);
                    // return true to indicate successful login
                    return true;
                }
                return false;
            });           
    }

    register(model): any {
        let m: any = {};
        m.Email = model.email;
        m.Password = model.password;
        m.ConfirmPassword = model.confirmPassword;
        m.IsTenant = true;
        m.TenantId = 'tenant id';
        m.TenantTitle =  'tenant title'; 
        m.TenantDescription = 'tenant description';

        let data: string = JSON.stringify(m);

        let headers = new Headers();
        headers.append('Content-Type', 'application/ json');
        headers.append('Data-Type', 'jsonp');
        return this.http.post(this.apiUrl + 'api/Account/Register',
            data,
            { headers }
        );
    }

    logout(): void {
        // clear token remove user from local storage to log user out
        this.token = null;
        localStorage.removeItem('currentUser');
        localStorage.removeItem('auth_token');
    }

    isLoggedIn(): boolean {
        return !!localStorage.getItem('auth_token');
    }
}