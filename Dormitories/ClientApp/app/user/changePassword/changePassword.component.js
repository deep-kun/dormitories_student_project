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
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { ChangePasswordModel } from './changePasswordModel';
var ChangePasswordComponent = /** @class */ (function () {
    function ChangePasswordComponent(http, router, activateRoute) {
        this.http = http;
        this.router = router;
        this.activateRoute = activateRoute;
        this.changePasswordModel = new ChangePasswordModel();
        this.changePasswordModel.username = activateRoute.snapshot.params['username'];
        this.errorMessage = "";
    }
    ChangePasswordComponent.prototype.ChangePassword = function () {
        var _this = this;
        this.http.post('api/account/changePassword', this.changePasswordModel)
            .subscribe(function (data) {
        }, function (error) {
            _this.errorMessage = error;
            console.log(error);
        });
    };
    ChangePasswordComponent = __decorate([
        Component({
            templateUrl: './changePassword.component.html',
            providers: [HttpClient]
        }),
        __metadata("design:paramtypes", [HttpClient, Router, ActivatedRoute])
    ], ChangePasswordComponent);
    return ChangePasswordComponent;
}());
export { ChangePasswordComponent };
//# sourceMappingURL=changePassword.component.js.map