import { Component } from '@angular/core';
import { RequestService } from '../../../shared/request.service';
import { Student } from '../Student';

@Component({
    templateUrl: './studentInfo.component.html'
})

export class StudentInfoComponent {
    public student: Student;

    constructor(private rs: RequestService) {
        let currentId = sessionStorage.getItem("username");

        this.rs.get('students/' + currentId)
            .subscribe(
                (data: any) => {
                    this.student = data;
                },
                error => {
                    console.log(error);
                }
            );
    }
}