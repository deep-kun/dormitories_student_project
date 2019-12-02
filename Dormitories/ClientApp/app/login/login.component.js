var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component } from '@angular/core';
import { User } from '../user/User';
import { HttpClient } from '@angular/common/http';
import { AppComponent } from '../app.component';
import { Router } from '@angular/router';
var LoginComponent = /** @class */ (function () {
    function LoginComponent(http, app, router) {
        this.http = http;
        this.app = app;
        this.router = router;
        this.user = new User();
        this.wrongCredentials = false;
    }
    LoginComponent.prototype.Login = function () {
        var _this = this;
        this.http.post('api/account/token', this.user)
            .subscribe(function (data) {
            sessionStorage.setItem("token", data.access_token);
            sessionStorage.setItem("username", data.username);
            sessionStorage.setItem("role", data.role);
            _this.app.role = data.role;
            _this.app.isLogged = true;
            _this.wrongCredentials = false;
            //this.router.navigate(['/test']);
            if (_this.app.role === 'Administrator') {
                _this.router.navigate(['administrator-home']);
            }
            else if (_this.app.role === 'Student') {
                _this.router.navigate(['student-home']);
            }
            else if (_this.app.role === 'DormitoryAdmin') {
                _this.router.navigate(['dormitory-admin-home']);
            }
            else if (_this.app.role === 'FacultyAdmin') {
                _this.router.navigate(['faculty-admin-home']);
            }
        }, function (error) {
            _this.wrongCredentials = true;
            console.log(error);
        });
    };
    LoginComponent = __decorate([
        Component({
            selector: 'app',
            templateUrl: './login.component.html',
            providers: [HttpClient]
        }),
        __metadata("design:paramtypes", [HttpClient, AppComponent, Router])
    ], LoginComponent);
    return LoginComponent;
}());
export { LoginComponent };
//# sourceMappingURL=login.component.js.map