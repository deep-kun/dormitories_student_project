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
import { RegisterAdministrator } from '../user/RegisetAdministrator';
import { HttpClient } from '@angular/common/http';
import { AppComponent } from '../app.component';
import { Router } from '@angular/router';
var RegisterComponent = /** @class */ (function () {
    function RegisterComponent(http, app, router) {
        this.http = http;
        this.app = app;
        this.router = router;
        this.user = new RegisterAdministrator();
        this.wrongCredentials = false;
    }
    RegisterComponent.prototype.Login = function () {
        var _this = this;
        this.http.post('api/account/register', this.user)
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
    var _a, _b;
    RegisterComponent = __decorate([
        Component({
            selector: 'app',
            templateUrl: './register.component.html',
            providers: [HttpClient]
        }),
        __metadata("design:paramtypes", [typeof (_a = typeof HttpClient !== "undefined" && HttpClient) === "function" ? _a : Object, AppComponent, typeof (_b = typeof Router !== "undefined" && Router) === "function" ? _b : Object])
    ], RegisterComponent);
    return RegisterComponent;
}());
export { RegisterComponent };
//# sourceMappingURL=register.component.js.map