import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RequestService } from '../../../../shared/request.service';
import { Room } from '../../../room/Room';

@Component({
    templateUrl: './roomDetails.component.html'
})
export class RoomDetailsForFacultyAdministratorComponent {
    private room: Room;
    private id: number;

    constructor(private router: Router, private activateRoute: ActivatedRoute, private rs: RequestService) {
        this.id = activateRoute.snapshot.params['id'];

        this.rs.get('rooms/' + this.id)
            .subscribe(
                (data: any) => {
                    this.room = data;
                },
                error => {
                    console.log(error);
                }
            );
    }
}