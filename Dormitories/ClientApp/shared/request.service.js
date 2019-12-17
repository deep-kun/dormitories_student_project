var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Log } from '../app/log/Log';
var RequestService = /** @class */ (function () {
    function RequestService(http) {
        this.http = http;
        this._baseUrl = 'api/';
    }
    RequestService.prototype.get = function (url) {
        var myHeaders = new HttpHeaders().set('Authorization', 'Bearer ' + sessionStorage.getItem('token'));
        var options = { headers: myHeaders };
        return this.http.get(this._baseUrl + url, options);
    };
    RequestService.prototype.post = function (url, obj) {
        this.logActionWithObject("POST", this._baseUrl + url, obj);
        var myHeaders = new HttpHeaders().set('Authorization', 'Bearer ' + sessionStorage.getItem('token'));
        var options = { headers: myHeaders };
        return this.http.post(this._baseUrl + url, obj, options);
    };
    RequestService.prototype.put = function (url, obj) {
        this.logActionWithObject("PUT", this._baseUrl + url, obj);
        var myHeaders = new HttpHeaders().set('Authorization', 'Bearer ' + sessionStorage.getItem('token'));
        var options = { headers: myHeaders };
        return this.http.put(this._baseUrl + url, obj, options);
    };
    RequestService.prototype.delete = function (url) {
        this.logActionWithoutObject("DELETE", this._baseUrl + url);
        var myHeaders = new HttpHeaders().set('Authorization', 'Bearer ' + sessionStorage.getItem('token'));
        var options = { headers: myHeaders };
        return this.http.delete(this._baseUrl + url, options);
    };
    RequestService.prototype.logActionWithObject = function (type, url, object) {
        var log = new Log();
        log.type = type;
        log.url = url;
        log.username = sessionStorage.getItem("username");
        log.object = JSON.stringify(object);
        var myHeaders = new HttpHeaders().set('Authorization', 'Bearer ' + sessionStorage.getItem('token'));
        var options = { headers: myHeaders };
        this.http.post(this._baseUrl + 'logs/object', log, options)
            .subscribe(function () { }, function (error) {
            console.log(error);
        });
    };
    RequestService.prototype.logActionWithoutObject = function (type, url) {
        var log = new Log();
        log.type = type;
        log.url = url;
        log.username = sessionStorage.getItem("username");
        var myHeaders = new HttpHeaders().set('Authorization', 'Bearer ' + sessionStorage.getItem('token'));
        var options = { headers: myHeaders };
        this.http.post(this._baseUrl + 'logs/notobject', log, options)
            .subscribe(function () { }, function (error) {
            console.log(error);
        });
    };
    var _a;
    RequestService = __decorate([
        Injectable(),
        __metadata("design:paramtypes", [typeof (_a = typeof HttpClient !== "undefined" && HttpClient) === "function" ? _a : Object])
    ], RequestService);
    return RequestService;
}());
export { RequestService };
//# sourceMappingURL=request.service.js.map