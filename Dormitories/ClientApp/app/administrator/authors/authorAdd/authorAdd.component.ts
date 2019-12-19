import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RequestService } from '../../../../shared/request.service';
import { Author } from '../../../author/Author';

@Component({
    templateUrl: './authorAdd.component.html'
})

export class AuthorAddForAdministratorComponent {
    private author: Author;

    constructor(private router: Router, private activateRoute: ActivatedRoute, private rs: RequestService) {
        this.author = new Author();
    }

    private Add() {
        this.rs.post('authors', this.author)
            .subscribe(
                (data: any) => {
                    this.router.navigate(['../authors'], { relativeTo: this.activateRoute });
                },
                error => {
                    console.log(error);
                }
            );
    }
}