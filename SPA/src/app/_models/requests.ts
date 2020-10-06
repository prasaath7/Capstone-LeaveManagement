import { User } from './user';
export interface Requests {
    id: number;
    leaveType: string;
    startDate: Date;
    endDate: Date;
    reason: string;
    userId: number;
    user: User;
}
