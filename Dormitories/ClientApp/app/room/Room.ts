import { Faculty } from '../faculty/Faculty';
import { Floor } from '../floor/Floor';
import { Block } from '../block/Block';
import { Student } from '../student/Student';

export class Room {
    id: number;
    name: string;
    totalPlaces: number;
    freePlaces: number;
    faculty: Faculty;
    floor: Floor;
    block: Block;
    students: Student[];
}