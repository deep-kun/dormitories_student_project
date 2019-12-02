import { Component } from '@angular/core';
import { RequestService } from '../../../shared/request.service';
import { Administrator } from '../../administrator/Administrator';

@Component({
    templateUrl: './administratorInfo.component.html'
})

export class AdministratorInfoComponent {
    public administrator: Administrator;

    constructor(private rs: RequestService) {
        let currentId = sessionStorage.getItem("username");

        this.rs.get('administrators/' + currentId)
            .subscribe(
                (data: any) => {
                    this.administrator = data;
                },
                error => {
                    console.log(error);
                }
            );
    }
}