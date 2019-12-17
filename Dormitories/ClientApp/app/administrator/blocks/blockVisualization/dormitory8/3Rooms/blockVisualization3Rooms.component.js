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
import { RequestService } from '../../../../../../shared/request.service';
var BlockVisualization3RoomsForAdministratorComponent = /** @class */ (function () {
    function BlockVisualization3RoomsForAdministratorComponent(router, activateRoute, rs) {
        var _this = this;
        this.router = router;
        this.activateRoute = activateRoute;
        this.rs = rs;
        this.id = activateRoute.snapshot.params['id'];
        this.rs.get('blocks/' + this.id)
            .subscribe(function (data) {
            _this.block = data;
        }, function (error) {
            console.log(error);
        });
    }
    BlockVisualization3RoomsForAdministratorComponent.prototype.openRoom = function (id) {
        this.router.navigate(['../../roomDetails', id], { relativeTo: this.activateRoute });
    };
    BlockVisualization3RoomsForAdministratorComponent.prototype.alertInfo = function (text) {
        alert(text);
    };
    var _a, _b;
    BlockVisualization3RoomsForAdministratorComponent = __decorate([
        Component({
            templateUrl: './blockVisualization3Rooms.component.html'
        }),
        __metadata("design:paramtypes", [typeof (_a = typeof Router !== "undefined" && Router) === "function" ? _a : Object, typeof (_b = typeof ActivatedRoute !== "undefined" && ActivatedRoute) === "function" ? _b : Object, RequestService])
    ], BlockVisualization3RoomsForAdministratorComponent);
    return BlockVisualization3RoomsForAdministratorComponent;
}());
export { BlockVisualization3RoomsForAdministratorComponent };
//# sourceMappingURL=blockVisualization3Rooms.component.js.map