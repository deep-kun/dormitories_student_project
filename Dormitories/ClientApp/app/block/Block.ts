import { Floor } from '../floor/Floor';
import { Room } from '../room/Room';

export class Block {
    id: number;
    name: string;
    floor: Floor;
    rooms: Room[];
}