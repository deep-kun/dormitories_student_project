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
import { RequestService } from '../../../shared/request.service';
var StudentInfoComponent = /** @class */ (function () {
    function StudentInfoComponent(rs) {
        var _this = this;
        this.rs = rs;
        var currentId = sessionStorage.getItem("username");
        this.rs.get('students/' + currentId)
            .subscribe(function (data) {
            _this.student = data;
        }, function (error) {
            console.log(error);
        });
    }
    StudentInfoComponent = __decorate([
        Component({
            templateUrl: './studentInfo.component.html'
        }),
        __metadata("design:paramtypes", [RequestService])
    ], StudentInfoComponent);
    return StudentInfoComponent;
}());
export { StudentInfoComponent };
//# sourceMappingURL=studentInfo.component.js.map