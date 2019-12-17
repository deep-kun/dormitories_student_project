import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RequestService } from '../../../../shared/request.service';
import { Group } from '../../../group/Group';
import { Faculty } from '../../../faculty/Faculty';

@Component({
    templateUrl: './groupAdd.component.html',
    styleUrls: ['./groupAdd.component.css']
})

export class GroupAddForAdministratorComponent {
    private group: Group;
    private faculties: Faculty[];

    constructor(private router: Router, private activateRoute: ActivatedRoute, private rs: RequestService) {
        this.group = new Group();
        this.group.faculty = new Faculty();

        this.rs.get('faculties')
            .subscribe(
                (data: any) => {
                    this.faculties = data;
                },
                error => {
                    console.log(error);
                }
            );
    }

    private Add() {
        this.rs.post('groups', this.group)
            .subscribe(
                (data: any) => {
                    this.router.navigate(['../groups'], { relativeTo: this.activateRoute });
                },
                error => {
                    console.log(error);
                }
            );
    }
}