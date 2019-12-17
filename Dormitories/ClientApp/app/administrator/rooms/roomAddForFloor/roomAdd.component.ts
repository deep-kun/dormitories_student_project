import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RequestService } from '../../../../shared/request.service';
import { Room } from '../../../room/Room';
import { Faculty } from '../../../faculty/Faculty';
import { Floor } from '../../../floor/Floor';

@Component({
    templateUrl: './roomAdd.component.html',
    styleUrls: ['./roomAdd.component.css']
})

export class RoomAddForFloorAdministratorComponent {
    private room: Room;
    private faculties: Faculty[];

    constructor(private router: Router, private activateRoute: ActivatedRoute, private rs: RequestService) {
        this.room = new Room();
        this.room.faculty = new Faculty();
        this.room.floor = new Floor();
        this.room.floor.id = activateRoute.snapshot.params['floorId'];

        this.rs.get('faculties')
            .subscribe(
                (data: any) => {
                    this.faculties = data;
                },
                error => {
                    console.log(error);
                }
            );
    }

    private Add() {
        this.rs.post('rooms', this.room)
            .subscribe(
                (data: any) => {
                    this.router.navigate(['../../../floorDetails',this.room.floor.id], { relativeTo: this.activateRoute });
                },
                error => {
                    console.log(error);
                }
            );
    }
}