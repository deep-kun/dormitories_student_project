import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RequestService } from '../../../../shared/request.service';
import { Room } from '../../../room/Room';

@Component({
    templateUrl: './roomDetails.component.html',
    styleUrls: ['./roomDetails.component.css']
})
export class RoomDetailsForAdministratorComponent {
    private room: Room;
    private id: number;

    constructor(private router: Router, private activateRoute: ActivatedRoute, private rs: RequestService) {
        this.id = activateRoute.snapshot.params['id'];
        this.getRoom();
    }

    private Eviction(studentId: number, roomId: number) {
        this.rs.get('students/eviction/' + studentId + '/' + roomId)
            .subscribe(
                () => {
                    alert("Eviction");
                    this.getRoom();
                },
                error => {
                    console.log(error);
                }
            );
    }

    private getRoom() {
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