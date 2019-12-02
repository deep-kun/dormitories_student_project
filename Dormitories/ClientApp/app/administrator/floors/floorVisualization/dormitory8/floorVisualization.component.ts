import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RequestService } from '../../../../../shared/request.service';
import { Floor } from '../../../../floor/Floor';

@Component({
    templateUrl: './floorVisualization.component.html'
})
export class FloorVisualizationDormitory8ForAdministratorComponent {
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

    openBlock(name: string) {
        var names = name.split("-");
        let blockName = this.floor.number.toString() + names[0] + "-" + this.floor.number.toString() + names[1];

        this.rs.get('blocks/name/' + blockName)
            .subscribe(
            (data: any) => {
                    if (data.rooms.length == 2) {
                        this.router.navigate(['../../blockVisualization2Rooms-dormitory8', data.id], { relativeTo: this.activateRoute });
                    } else if (data.rooms.length == 3) {
                        this.router.navigate(['../../blockVisualization3Rooms-dormitory8', data.id], { relativeTo: this.activateRoute });
                    }
                },
                error => {
                    console.log(error);
                }
            );
    }

    alertInfo(text: string) {
        alert(text);
    }
}