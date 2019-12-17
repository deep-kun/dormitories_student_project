import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { ChangePasswordModel } from './changePasswordModel';

@Component({
    templateUrl: './changePassword.component.html',
    styleUrls: ['./changePassword.component.css'],
    providers: [HttpClient]
})
export class ChangePasswordComponent {
    changePasswordModel: ChangePasswordModel;
    errorMessage: string;

    constructor(private http: HttpClient, private router: Router, private activateRoute: ActivatedRoute) {
        this.changePasswordModel = new ChangePasswordModel();
        this.changePasswordModel.username = activateRoute.snapshot.params['username'];
        this.errorMessage = "";
    }

    private ChangePassword() {
        this.http.post('api/account/changePassword', this.changePasswordModel)
            .subscribe(
                (data: any) => {
                },
                error => {
                    this.errorMessage = error;
                    console.log(error);
                }
            );
    }
}