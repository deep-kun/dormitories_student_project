import { Component } from '@angular/core';
import { RequestService } from '../../shared/request.service';

@Component({
    selector: 'app',
    templateUrl: './test.html',
    providers: [RequestService]
})
export class TestComponent {
    role = '';

    constructor(private rs:RequestService) {
        this.rs.get('values/getrole').subscribe(
            (data: any) => {
                alert("constructor");
                this.role = data.toString();
                console.log("1" +data);
                console.log("2" + data.toString());
                console.log("3" + this.role);

            });
    }
}