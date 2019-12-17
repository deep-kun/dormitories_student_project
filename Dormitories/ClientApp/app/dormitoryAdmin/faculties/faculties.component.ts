import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RequestService } from '../../../shared/request.service';
import { Faculty } from '../../faculty/Faculty';

@Component({
    templateUrl: './faculties.component.html',
    styleUrls: ['./faculties.component.css']
})
export class FacultiesForDormitoryAdminComponent {
    private faculties: Faculty[];

    constructor(private router: Router, private activateRoute: ActivatedRoute, private rs: RequestService) {
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
}