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
import { StudentCategory } from '../../../studentCategory/StudentCategory';
var StudentCategoryAddForAdministratorComponent = /** @class */ (function () {
    function StudentCategoryAddForAdministratorComponent(router, activateRoute, rs) {
        this.router = router;
        this.activateRoute = activateRoute;
        this.rs = rs;
        this.studentCategory = new StudentCategory();
    }
    StudentCategoryAddForAdministratorComponent.prototype.Add = function () {
        var _this = this;
        this.rs.post('studentCategories', this.studentCategory)
            .subscribe(function (data) {
            _this.router.navigate(['../studentCategories'], { relativeTo: _this.activateRoute });
        }, function (error) {
            console.log(error);
        });
    };
    StudentCategoryAddForAdministratorComponent = __decorate([
        Component({
            templateUrl: './studentCategoryAdd.component.html'
        }),
        __metadata("design:paramtypes", [Router, ActivatedRoute, RequestService])
    ], StudentCategoryAddForAdministratorComponent);
    return StudentCategoryAddForAdministratorComponent;
}());
export { StudentCategoryAddForAdministratorComponent };
//# sourceMappingURL=studentCategoryAdd.component.js.map