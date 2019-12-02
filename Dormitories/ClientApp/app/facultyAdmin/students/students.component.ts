import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RequestService } from '../../../shared/request.service';
import { Student } from '../../student/Student';

@Component({
    templateUrl: './students.component.html'
})
export class StudentsForFacultyAdministratorComponent {
    private students: Student[];

    constructor(private router: Router, private activateRoute: ActivatedRoute, private rs: RequestService) {
        this.rs.get('students')
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