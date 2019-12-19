import { Author } from '../author/Author';

export class Book
{
    id: number;
    name: string;
    language: string;
    year: number;
    available: boolean;
    author: Author;
}

