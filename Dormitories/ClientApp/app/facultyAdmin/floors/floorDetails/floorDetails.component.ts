import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RequestService } from '../../../../shared/request.service';
import { Floor } from '../../../floor/Floor';

@Component({
    templateUrl: './floorDetails.component.html'
})
export class FloorDetailsForFacultyAdministratorComponent {
    private floor: Floor;
    private id: number;

    constructor(private router: Router, private activateRoute: ActivatedRoute, private rs: RequestService) {
        this.id = activateRoute.snapshot.params['id'];

        this.rs.get('floors/' + this.id)
            .subscribe(
                (data: any) => {
                    this.floor = data;
                },
                error => {
                    console.log(error);
                }
            );
    }
}