import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RequestService } from '../../../../shared/request.service';
import { Room } from '../../../room/Room';
import { Faculty } from '../../../faculty/Faculty';
import { Block } from '../../../block/Block';

@Component({
    templateUrl: './roomAdd.component.html',
    styleUrls: ['./roomAdd.component.css']
})

export class RoomAddForBlockAdministratorComponent {
    private room: Room;
    private faculties: Faculty[];

    constructor(private router: Router, private activateRoute: ActivatedRoute, private rs: RequestService) {
        this.room = new Room();
        this.room.faculty = new Faculty();
        this.room.block = new Block();
        this.room.block.id = activateRoute.snapshot.params['blockId'];

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
                    this.router.navigate(['../../../blockDetails', this.room.block.id], { relativeTo: this.activateRoute });
                },
                error => {
                    console.log(error);
                }
            );
    }
}