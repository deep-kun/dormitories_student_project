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
import { forkJoin } from "rxjs/observable/forkJoin";
var RoomSettlingComponentForAdministrator = /** @class */ (function () {
    function RoomSettlingComponentForAdministrator(router, activateRoute, rs) {
        var _this = this;
        this.router = router;
        this.activateRoute = activateRoute;
        this.rs = rs;
        this.id = activateRoute.snapshot.params['id'];
        var requestForGettingRoom = this.rs.get('rooms/' + this.id);
        var requestForGettingStudents = this.rs.get('students/notSettle');
        forkJoin([requestForGettingRoom, requestForGettingStudents]).subscribe(function (data) {
            _this.room = data[0];
            _this.students = data[1];
        });
    }
    RoomSettlingComponentForAdministrator.prototype.Settle = function (studentId, roomId) {
        var _this = this;
        this.rs.get('students/settle/' + studentId + '/' + roomId)
            .subscribe(function () {
            _this.router.navigate(['../../../administrator-home/roomDetails', _this.room.id], { relativeTo: _this.activateRoute });
        }, function (error) {
            console.log(error);
        });
    };
    RoomSettlingComponentForAdministrator.prototype.Search = function (studentName) {
        var _this = this;
        if (studentName === "") {
            this.rs.get('students/notSettle')
                .subscribe(function (data) {
                _this.students = data;
            }, function (error) {
                console.log(error);
            });
        }
        else {
            this.rs.get('students/search/' + studentName)
                .subscribe(function (data) {
                _this.students = data;
            }, function (error) {
                console.log(error);
            });
        }
    };
    RoomSettlingComponentForAdministrator = __decorate([
        Component({
            templateUrl: './roomSettling.component.html'
        }),
        __metadata("design:paramtypes", [Router, ActivatedRoute, RequestService])
    ], RoomSettlingComponentForAdministrator);
    return RoomSettlingComponentForAdministrator;
}());
export { RoomSettlingComponentForAdministrator };
//# sourceMappingURL=roomSettling.component.js.map