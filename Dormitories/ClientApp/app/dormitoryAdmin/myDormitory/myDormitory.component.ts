import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RequestService } from '../../../shared/request.service';
import { Dormitory } from '../../dormitory/Dormitory';

@Component({
    templateUrl: './myDormitory.component.html',
    styleUrls: ['./myDormitory.component.css']
})
export class MyDormitoryComponent {
    private dormitory: Dormitory;
    private administratorUsername: string;

    constructor(private router: Router, private activateRoute: ActivatedRoute, private rs: RequestService) {
        this.administratorUsername = sessionStorage.getItem("username");

        this.rs.get('dormitories/dormitoryAdmin/' + this.administratorUsername)
            .subscribe(
                (data: any) => {
                    this.dormitory = data;
                },
                error => {
                    console.log(error);
                }
            );
    }
}