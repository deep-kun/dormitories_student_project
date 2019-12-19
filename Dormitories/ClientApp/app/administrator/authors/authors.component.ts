import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RequestService } from '../../../shared/request.service';
import { Author } from '../../author/author';

@Component({
    templateUrl: './authors.component.html'
})
export class AuthorsForAdministratorComponent {
    private authors: Author[];

constructor(private router: Router, private activateRoute: ActivatedRoute, private rs: RequestService) {
    this.rs.get('authors')
        .subscribe(
            (data: any) => {
                this.authors = data;
            },
            error => {
                console.log(error);
            }
        );
    }
}
