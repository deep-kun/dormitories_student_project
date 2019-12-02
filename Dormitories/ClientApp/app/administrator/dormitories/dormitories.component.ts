import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RequestService } from '../../../shared/request.service';
import { Dormitory } from '../../dormitory/Dormitory';

@Component({
    templateUrl: './dormitories.component.html'
})
export class DormitoriesForAdministratorComponent {
    private dormitories: Dormitory[];

    constructor(private router: Router, private activateRoute: ActivatedRoute, private rs: RequestService) {
        this.rs.get('dormitories')
            .subscribe(
                (data: any) => {
                    this.dormitories = data;
                },
                error => {
                    console.log(error);
                }
            );
    }
}