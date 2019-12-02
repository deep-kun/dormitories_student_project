import { Role } from '../roles/Role';

export class User {
    Id: number;
    Username: string;
    PasswordHash: string;
    Role: Role;
}