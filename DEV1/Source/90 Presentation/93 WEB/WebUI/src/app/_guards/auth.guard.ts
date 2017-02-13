import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { LocalStorageService } from 'angular-2-local-storage';

@Injectable()
export class AuthGuard implements CanActivate {

    constructor(private router: Router) { }

    canActivate() {

        if (this.checkIfLoggedIn() == true)
            return true;

        console.log("LoginGuard: The user is not logged in");
        // not logged in so redirect to login page
        this.router.navigate(['/session/signin']);
        return false;
    }

    private checkIfLoggedIn(): boolean {

        return !!localStorage.getItem('auth_token');
    }
}