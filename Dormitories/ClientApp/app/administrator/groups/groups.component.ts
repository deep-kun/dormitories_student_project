import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RequestService } from '../../../shared/request.service';
import { Group } from '../../group/Group';

@Component({
    templateUrl: './groups.component.html'
})
export class GroupsForAdministratorComponent {
    private groups: Group[];

    constructor(private router: Router, private activateRoute: ActivatedRoute, private rs: RequestService) {
        this.rs.get('groups')
            .subscribe(
                (data: any) => {
                    this.groups = data;
                },
                error => {
                    console.log(error);
                }
            );
    }
}