import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RequestService } from '../../../../shared/request.service';
import { Room } from '../../../room/Room';
import { Student } from '../../../student/Student';
import { forkJoin } from "rxjs/observable/forkJoin";

@Component({
    templateUrl: './roomSettling.component.html',
    styleUrls: ['./roomSettling.component.css']
})
export class RoomSettlingComponentForAdministrator {
    private room: Room;
    private students: Student[];
    private id: number;

    constructor(private router: Router, private activateRoute: ActivatedRoute, private rs: RequestService) {
        this.id = activateRoute.snapshot.params['id'];
        let requestForGettingRoom = this.rs.get('rooms/' + this.id);
        let requestForGettingStudents = this.rs.get('students/notSettle');

        forkJoin([requestForGettingRoom, requestForGettingStudents]).subscribe((data: any) => {
            this.room = data[0];
            this.students = data[1];
        });
    }

    private Settle(studentId: number, roomId: number) {
        this.rs.get('students/settle/' + studentId + '/' + roomId)
            .subscribe(
                () => {
                    this.router.navigate(['../../../administrator-home/roomDetails', this.room.id], { relativeTo: this.activateRoute });
                },
                error => {
                    console.log(error);
                }
            );
    }

    private Search(studentName: string) {
        if (studentName === "") {
            this.rs.get('students/notSettle')
                .subscribe(
                (data:any) => {
                    this.students = data;
                },
                error => {
                    console.log(error);
                }
                );
        }
        else {
            this.rs.get('students/search/' + studentName)
                .subscribe(
                (data: any) => {
                    this.students = data;
                },
                error => {
                    console.log(error);
                }
                );
        }
    }
}