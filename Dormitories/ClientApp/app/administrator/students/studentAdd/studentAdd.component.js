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
import { RequestService } from '../../../../shared/request.service';
import { Student } from '../../../student/Student';
import { Group } from '../../../group/Group';
import { Faculty } from '../../../faculty/Faculty';
import { StudentCategory } from '../../../studentCategory/StudentCategory';
import { forkJoin } from "rxjs/observable/forkJoin";
var StudentAddForAdministratorComponent = /** @class */ (function () {
    function StudentAddForAdministratorComponent(router, activateRoute, rs) {
        var _this = this;
        this.router = router;
        this.activateRoute = activateRoute;
        this.rs = rs;
        this.student = new Student();
        this.student.faculty = new Faculty();
        this.student.group = new Group();
        this.student.studentCategory = new StudentCategory();
        var requestForGettingGroups = this.rs.get('groups');
        var requestForGettingFaculties = this.rs.get('faculties');
        var requestForGettingStudentCategories = this.rs.get('studentCategories');
        forkJoin([requestForGettingFaculties, requestForGettingGroups, requestForGettingStudentCategories])
            .subscribe(function (data) {
            _this.faculties = data[0];
            _this.groups = data[1];
            _this.studentCategories = data[2];
            console.log(data);
        }, function (error) {
            console.log(error);
        });
    }
    StudentAddForAdministratorComponent.prototype.Add = function () {
        var _this = this;
        this.rs.post('students', this.student)
            .subscribe(function (data) {
            _this.router.navigate(['../students'], { relativeTo: _this.activateRoute });
        }, function (error) {
            console.log(error);
        });
    };
    var _a, _b;
    StudentAddForAdministratorComponent = __decorate([
        Component({
            templateUrl: './studentAdd.component.html'
        }),
        __metadata("design:paramtypes", [typeof (_a = typeof Router !== "undefined" && Router) === "function" ? _a : Object, typeof (_b = typeof ActivatedRoute !== "undefined" && ActivatedRoute) === "function" ? _b : Object, RequestService])
    ], StudentAddForAdministratorComponent);
    return StudentAddForAdministratorComponent;
}());
export { StudentAddForAdministratorComponent };
//# sourceMappingURL=studentAdd.component.js.map