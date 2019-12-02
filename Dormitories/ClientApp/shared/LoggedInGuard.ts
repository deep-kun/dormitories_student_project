import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';

@Injectable()
export class LoggedInGuard implements CanActivate {

    constructor(private router: Router) {
    }

    canActivate() {
        if (sessionStorage.getItem('token') != null) {
            return true;
        } else {
            this.router.navigate(['/login']);
            return false;
        }
    }
}