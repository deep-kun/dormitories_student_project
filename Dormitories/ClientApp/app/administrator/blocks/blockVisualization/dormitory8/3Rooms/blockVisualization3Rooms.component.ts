import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RequestService } from '../../../../../../shared/request.service';
import { Block } from '../../../../../block/Block';

@Component({
    templateUrl: './blockVisualization3Rooms.component.html'
})
export class BlockVisualization3RoomsForAdministratorComponent {
    private block: Block;
    private id: number;

    constructor(private router: Router, private activateRoute: ActivatedRoute, private rs: RequestService) {
        this.id = activateRoute.snapshot.params['id'];

        this.rs.get('blocks/' + this.id)
            .subscribe(
                (data: any) => {
                    this.block = data;
                },
                error => {
                    console.log(error);
                }
            );
    }

    openRoom(id: number) {
        this.router.navigate(['../../roomDetails', id], { relativeTo: this.activateRoute });
    }

    alertInfo(text: string) {
        alert(text);
    }
}