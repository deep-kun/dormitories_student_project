import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RequestService } from '../../../shared/request.service';
import { StudentCategory } from '../../studentCategory/StudentCategory';

@Component({
    templateUrl: '/studentCategories.component.html',
    styleUrls: ['/studentCategories.component.css']
})
export class StudentCategoriesForFacultyAdministratorComponent {
    private studentCategories: StudentCategory[];

    constructor(private router: Router, private activateRoute: ActivatedRoute, private rs: RequestService) {
        this.rs.get('studentCategories')
            .subscribe(
                (data: any) => {
                    this.studentCategories = data;
                },
                error => {
                    console.log(error);
                }
            );
    }
}