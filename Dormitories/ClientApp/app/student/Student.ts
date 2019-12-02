import { User } from '../user/User';
import { Faculty } from '../faculty/Faculty';
import { Group } from '../group/Group';
import { Room } from '../room/Room';
import { StudentCategory } from '../studentCategory/StudentCategory';

export class Student {
    id: number;
    fullName: string;
    faculty: Faculty;
    email: string;
    phoneNumber: string;
    studentCardId: string;
    group: Group;
    room: Room;
    studyYear: number;
    studentCategory: StudentCategory;
    user: User;
}