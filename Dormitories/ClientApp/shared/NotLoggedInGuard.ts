import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';

@Injectable()
export class NotLoggedInGuard implements CanActivate {

    constructor(private router: Router) {
    }

    canActivate() {
        if (sessionStorage.getItem('token') == null) {
            return true;
        } else {
            this.router.navigate(['/home']);
            return false;
        }
    }
}