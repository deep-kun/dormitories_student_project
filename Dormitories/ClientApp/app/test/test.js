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
import { RequestService } from '../../shared/request.service';
var TestComponent = /** @class */ (function () {
    function TestComponent(rs) {
        var _this = this;
        this.rs = rs;
        this.role = '';
        this.rs.get('values/getrole').subscribe(function (data) {
            alert("constructor");
            _this.role = data.toString();
            console.log("1" + data);
            console.log("2" + data.toString());
            console.log("3" + _this.role);
        });
    }
    TestComponent = __decorate([
        Component({
            selector: 'app',
            templateUrl: './test.html',
            providers: [RequestService]
        }),
        __metadata("design:paramtypes", [RequestService])
    ], TestComponent);
    return TestComponent;
}());
export { TestComponent };
//# sourceMappingURL=test.js.map