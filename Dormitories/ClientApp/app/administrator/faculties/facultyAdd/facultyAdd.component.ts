import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RequestService } from '../../../../shared/request.service';
import { Faculty } from '../../../faculty/Faculty';

@Component({
    templateUrl: './facultyAdd.component.html'
})

export class FacultyAddForAdministratorComponent {
    private faculty: Faculty;

    constructor(private router: Router, private activateRoute: ActivatedRoute, private rs: RequestService) {
        this.faculty = new Faculty();
    }

    private Add() {
        this.rs.post('faculties', this.faculty)
            .subscribe(
                (data: any) => {
                    this.router.navigate(['../faculties'], { relativeTo: this.activateRoute });
                },
                error => {
                    console.log(error);
                }
            );
    }
}