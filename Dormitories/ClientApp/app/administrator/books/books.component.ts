import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RequestService } from '../../../shared/request.service';
import { Book } from '../../book/Book';

@Component({
    templateUrl: './books.component.html'
})
export class BooksForAdministratorComponent {
    private books: Book[];

constructor(private router: Router, private activateRoute: ActivatedRoute, private rs: RequestService) {
    this.rs.get('books')
        .subscribe(
            (data: any) => {
                this.books = data;
            },
            error => {
                console.log(error);
            }
        );
    }
}
