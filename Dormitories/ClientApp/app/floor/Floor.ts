import { Dormitory } from '../dormitory/Dormitory';
import { Room } from '../room/Room';
import { Block } from '../block/Block';

export class Floor {
    id: number;
    number: number;
    dormitory: Dormitory;
    rooms: Room[];
    blocks: Block[];
}