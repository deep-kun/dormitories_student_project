import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RequestService } from '../../../../shared/request.service';
import { Block } from '../../../block/Block';
import { Floor } from '../../../floor/Floor';

@Component({
    templateUrl: './blockAdd.component.html',
    styleUrls: ['./blockAdd.component.css']
})

export class BlockAddForAdministratorComponent {
    private block: Block;
    private dormitoryId: number;

    constructor(private router: Router, private activateRoute: ActivatedRoute, private rs: RequestService) {
        this.block = new Block();
        this.block.floor = new Floor();
        this.block.floor.id = activateRoute.snapshot.params['floorId'];
    }

    private Add() {
        this.rs.post('blocks', this.block)
            .subscribe(
                (data: any) => {
                    this.router.navigate(['../../floorDetails', this.block.floor.id], { relativeTo: this.activateRoute });
                },
                error => {
                    console.log(error);
                }
            );
    }
}