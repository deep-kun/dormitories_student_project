import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';

@Injectable()
export class LoggedInGuardFacultyAdmin implements CanActivate {
    constructor(private router: Router) {
    }

    canActivate() {
        if (sessionStorage.getItem('role') === 'FacultyAdmin') {

            return true;
        } else {
            this.router.navigate(['/info']);

            return false;
        }
    }
}