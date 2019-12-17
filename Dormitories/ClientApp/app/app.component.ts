import { Component } from '@angular/core';
import { RequestService } from '../shared/request.service';
import { Router } from '@angular/router';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
    providers: [RequestService]
})

export class AppComponent {
    public role: string = 'None';
    public isLogged: boolean = false;

    constructor(private router: Router) {
        if (sessionStorage.getItem("token") !== null) {
            this.isLogged = true;
        }

        if (sessionStorage.getItem("role") !== null) {
            this.role = sessionStorage.getItem("role");
        }
    }

    Logout() {
        sessionStorage.clear();
        this.isLogged = false;
        this.role = 'None';
        this.router.navigate(['/login']);
    }
}