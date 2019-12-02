import { User } from '../user/User';
import { Faculty } from '../faculty/Faculty';

export class Administrator {
    Id: number;
    FullName: string;
    Faculty: Faculty;
    Email: string;
    PhoneNumber: string;
    User: User;
}