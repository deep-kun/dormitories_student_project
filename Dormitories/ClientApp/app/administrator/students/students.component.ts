import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RequestService } from '../../../shared/request.service';
import { Student } from '../../student/Student';

@Component({
    templateUrl: './students.component.html',
    styleUrls: ['./students.component.css']
})
export class StudentsForAdministratorComponent {
    private students: Student[];

    constructor(private router: Router, private activateRoute: ActivatedRoute, private rs: RequestService) {
        this.rs.get('students')
            .subscribe(
                (data: any) => {
                    this.students = data;
                    console.log(this.students);
                },
                error => {
                    console.log(error);
                }
            );
    }
}