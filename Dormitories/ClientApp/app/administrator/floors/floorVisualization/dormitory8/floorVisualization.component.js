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
import { RequestService } from '../../../../../shared/request.service';
var FloorVisualizationDormitory8ForAdministratorComponent = /** @class */ (function () {
    function FloorVisualizationDormitory8ForAdministratorComponent(router, activateRoute, rs) {
        var _this = this;
        this.router = router;
        this.activateRoute = activateRoute;
        this.rs = rs;
        this.id = activateRoute.snapshot.params['id'];
        this.rs.get('floors/' + this.id)
            .subscribe(function (data) {
            _this.floor = data;
        }, function (error) {
            console.log(error);
        });
    }
    FloorVisualizationDormitory8ForAdministratorComponent.prototype.openBlock = function (name) {
        var _this = this;
        var names = name.split("-");
        var blockName = this.floor.number.toString() + names[0] + "-" + this.floor.number.toString() + names[1];
        this.rs.get('blocks/name/' + blockName)
            .subscribe(function (data) {
            if (data.rooms.length == 2) {
                _this.router.navigate(['../../blockVisualization2Rooms-dormitory8', data.id], { relativeTo: _this.activateRoute });
            }
            else if (data.rooms.length == 3) {
                _this.router.navigate(['../../blockVisualization3Rooms-dormitory8', data.id], { relativeTo: _this.activateRoute });
            }
        }, function (error) {
            console.log(error);
        });
    };
    FloorVisualizationDormitory8ForAdministratorComponent.prototype.alertInfo = function (text) {
        alert(text);
    };
    var _a, _b;
    FloorVisualizationDormitory8ForAdministratorComponent = __decorate([
        Component({
            templateUrl: './floorVisualization.component.html'
        }),
        __metadata("design:paramtypes", [typeof (_a = typeof Router !== "undefined" && Router) === "function" ? _a : Object, typeof (_b = typeof ActivatedRoute !== "undefined" && ActivatedRoute) === "function" ? _b : Object, RequestService])
    ], FloorVisualizationDormitory8ForAdministratorComponent);
    return FloorVisualizationDormitory8ForAdministratorComponent;
}());
export { FloorVisualizationDormitory8ForAdministratorComponent };
//# sourceMappingURL=floorVisualization.component.js.map