import { Administrator } from '../administrator/Administrator';
import { Floor } from '../floor/Floor';

export class Dormitory {
    id: number;
    description: string;
    address: string;
    number: number;
    comendant: Administrator;
    floors: Floor[];
}