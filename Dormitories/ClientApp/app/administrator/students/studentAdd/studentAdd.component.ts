import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RequestService } from '../../../../shared/request.service';
import { Student } from '../../../student/Student';
import { Group } from '../../../group/Group';
import { Faculty } from '../../../faculty/Faculty';
import { StudentCategory } from '../../../studentCategory/StudentCategory';
import { forkJoin } from "rxjs/observable/forkJoin";

@Component({
    templateUrl: './studentAdd.component.html',
    styleUrls: ['./studentAdd.component.css']
})

export class StudentAddForAdministratorComponent {
    private student: Student;
    private groups: Group[];
    private faculties: Faculty[];
    private studentCategories: StudentCategory[];

    constructor(private router: Router, private activateRoute: ActivatedRoute, private rs: RequestService) {
        this.student = new Student();
        this.student.faculty = new Faculty();
        this.student.group = new Group();
        this.student.studentCategory = new StudentCategory();
        let requestForGettingGroups = this.rs.get('groups');
        let requestForGettingFaculties = this.rs.get('faculties');
        let requestForGettingStudentCategories = this.rs.get('studentCategories');

        forkJoin([requestForGettingFaculties, requestForGettingGroups,requestForGettingStudentCategories])
            .subscribe(
                (data: any) => {
                    this.faculties = data[0];
                    this.groups = data[1];
                    this.studentCategories = data[2];
                    console.log(data);
                },
                error => {
                    console.log(error);
                }
            );

    }

    private Add() {
        this.rs.post('students', this.student)
            .subscribe(
                (data: any) => {
                    this.router.navigate(['../students'], { relativeTo: this.activateRoute });
                },
                error => {
                    console.log(error);
                }
            );
    }
}