import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Log } from '../app/log/Log';

@Injectable()
export class RequestService {
    private _baseUrl = 'api/';

    constructor(private http: HttpClient) {
    }

    get(url: String) {
        const myHeaders = new HttpHeaders().set('Authorization', 'Bearer '+ sessionStorage.getItem('token'));
        let options = { headers: myHeaders };

        return this.http.get(this._baseUrl + url,options);
    }

    post(url: String, obj: any) {
        this.logActionWithObject("POST", this._baseUrl + url, obj);

        const myHeaders = new HttpHeaders().set('Authorization', 'Bearer ' + sessionStorage.getItem('token'));
        let options = { headers: myHeaders };

        return this.http.post(this._baseUrl + url, obj, options);
    }

    put(url: String, obj: any) {
        this.logActionWithObject("PUT", this._baseUrl + url, obj);

        const myHeaders = new HttpHeaders().set('Authorization', 'Bearer ' + sessionStorage.getItem('token'));
        let options = { headers: myHeaders };

        return this.http.put(this._baseUrl + url, obj, options);
    }

    delete(url: String) {
        this.logActionWithoutObject("DELETE",this._baseUrl + url);

        const myHeaders = new HttpHeaders().set('Authorization', 'Bearer ' + sessionStorage.getItem('token'));
        let options = { headers: myHeaders };

        return this.http.delete(this._baseUrl + url, options);
    }

    private logActionWithObject(type: string, url: String, object: any) {
        var log = new Log();
        log.type = type;
        log.url = url;
        log.username = sessionStorage.getItem("username");
        log.object = JSON.stringify(object);
        const myHeaders = new HttpHeaders().set('Authorization', 'Bearer ' + sessionStorage.getItem('token'));
        let options = { headers: myHeaders };

        this.http.post(this._baseUrl + 'logs/object', log, options)
            .subscribe(() => { },
                error => {
                    console.log(error);
                });
    }

    private logActionWithoutObject(type: string, url: String) {
        var log = new Log();
        log.type = type;
        log.url = url;
        log.username = sessionStorage.getItem("username");
        const myHeaders = new HttpHeaders().set('Authorization', 'Bearer ' + sessionStorage.getItem('token'));
        let options = { headers: myHeaders };

        this.http.post(this._baseUrl + 'logs/notobject', log, options)
            .subscribe(() => {},
                error => {
                    console.log(error);
                });
    }
}