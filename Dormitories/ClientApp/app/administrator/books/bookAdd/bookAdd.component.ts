import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RequestService } from '../../../../shared/request.service';
import { Book } from '../../../book/Book';
import { Author } from '../../../author/Author';

@Component({
    templateUrl: './bookAdd.component.html'
})

export class BookAddForAdministratorComponent {
    private book: Book;
    private authors: Author[];

    constructor(private router: Router, private activateRoute: ActivatedRoute, private rs: RequestService) {
        this.book = new Book();
        this.book.author = new Author();

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

    private Add() {
        this.rs.post('books', this.book)
            .subscribe(
                (data: any) => {
                    this.router.navigate(['../books'], { relativeTo: this.activateRoute });
                },
                error => {
                    console.log(error);
                }
            );
    }
}