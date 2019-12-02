import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RequestService } from '../../../../shared/request.service';
import { Dormitory } from '../../../dormitory/Dormitory';
import { Administrator } from '../../../administrator/Administrator';

@Component({
    templateUrl: './dormitoryAdd.component.html'
})

export class DormitoryAddForAdministratorComponent {
    private dormitory: Dormitory;
    private id: number;
    private administrators: Administrator[];

    constructor(private router: Router, private activateRoute: ActivatedRoute, private rs: RequestService) {
        this.dormitory = new Dormitory();
        this.dormitory.comendant = new Administrator();

        this.rs.get('administrators')
            .subscribe(
                (data: any) => {
                    this.administrators = data;
                },
                error => {
                    console.log(error);
                }
            );
    }

    private Add() {
        this.rs.post('dormitories', this.dormitory)
            .subscribe(
                (data: any) => {
                    this.router.navigate(['../dormitories'], { relativeTo: this.activateRoute });
                },
                error => {
                    console.log(error);
                }
            );
    }
}