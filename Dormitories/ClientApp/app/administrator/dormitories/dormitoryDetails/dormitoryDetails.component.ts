import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RequestService } from '../../../../shared/request.service';
import { Dormitory } from '../../../dormitory/Dormitory';

@Component({
    templateUrl: './dormitoryDetails.component.html',
    styleUrls: ['./dormitoryDetails.component.css']
})
export class DormitoryDetailsForAdministratorComponent {
    private dormitory: Dormitory;
    private id: number;

    constructor(private router: Router, private activateRoute: ActivatedRoute, private rs: RequestService) {
        this.id = activateRoute.snapshot.params['id'];

        this.rs.get('dormitories/' + this.id)
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