import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RequestService } from '../../../../shared/request.service';
import { Floor } from '../../../floor/Floor';
import { Dormitory } from '../../../dormitory/Dormitory';

@Component({
    templateUrl: './floorAdd.component.html',
    styleUrls: ['./floorAdd.component.css']
})

export class FloorAddForAdministratorComponent {
    private floor: Floor;
    private dormitoryId: number;

    constructor(private router: Router, private activateRoute: ActivatedRoute, private rs: RequestService) {
        this.floor = new Floor();
        this.floor.dormitory = new Dormitory();
        this.floor.dormitory.id = activateRoute.snapshot.params['dormitoryId'];
    }

    private Add() {
        this.rs.post('floors', this.floor)
            .subscribe(
                (data: any) => {
                    this.router.navigate(['../../dormitoryDetails',this.floor.dormitory.id], { relativeTo: this.activateRoute });
                },
                error => {
                    console.log(error);
                }
            );
    }
}