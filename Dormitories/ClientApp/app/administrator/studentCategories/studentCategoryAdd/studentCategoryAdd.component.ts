import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RequestService } from '../../../../shared/request.service';
import { StudentCategory } from '../../../studentCategory/StudentCategory';

@Component({
    templateUrl: './studentCategoryAdd.component.html',
    styleUrls: ['./studentCategoryAdd.component.css']
})
export class StudentCategoryAddForAdministratorComponent {
    private studentCategory: StudentCategory;

    constructor(private router: Router, private activateRoute: ActivatedRoute, private rs: RequestService) {
        this.studentCategory = new StudentCategory();
    }

    private Add() {
        this.rs.post('studentCategories', this.studentCategory)
            .subscribe(
                (data: any) => {
                    this.router.navigate(['../studentCategories'], { relativeTo: this.activateRoute });
                },
                error => {
                    console.log(error);
                }
            );
    }
}