import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';

@Injectable()
export class LoggedInGuardDormitoryAdmin implements CanActivate {
    constructor(private router: Router) {
    }

    canActivate() {
        if (sessionStorage.getItem('role') === 'DormitoryAdmin') {

            return true;
        } else {
            this.router.navigate(['/info']);

            return false;
        }
    }
}