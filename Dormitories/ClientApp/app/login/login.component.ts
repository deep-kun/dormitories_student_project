﻿import { Component } from '@angular/core';
import { User } from '../user/User';
import { HttpClient } from '@angular/common/http';
import { AppComponent } from '../app.component';
import { Router } from '@angular/router';

@Component({
    selector: 'app',
    templateUrl: './login.component.html',
    providers: [HttpClient]
})
export class LoginComponent {
    user: User;
    wrongCredentials: boolean;

    constructor(private http: HttpClient, private app: AppComponent, private router: Router) {
        this.user = new User();
        this.wrongCredentials = false;
    }

    private Login() {
        this.http.post('api/account/token', this.user)
            .subscribe(
                (data: any) => {
                    sessionStorage.setItem("token", data.access_token);
                    sessionStorage.setItem("username", data.username);
                    sessionStorage.setItem("role", data.role);
                    this.app.role = data.role;
                    this.app.isLogged = true;
                    this.wrongCredentials = false;
                    //this.router.navigate(['/test']);
                    if (this.app.role === 'Administrator') {
                        this.router.navigate(['administrator-home']);
                    } else
                        if (this.app.role === 'Student') {
                        this.router.navigate(['student-home']);
                    } else
                            if (this.app.role === 'DormitoryAdmin') {
                        this.router.navigate(['dormitory-admin-home']);
                    } else
                                if (this.app.role === 'FacultyAdmin') {
                        this.router.navigate(['faculty-admin-home']);
                    }
                },
                error => {
                    this.wrongCredentials = true;
                    console.log(error);
                }
            );
    }
}