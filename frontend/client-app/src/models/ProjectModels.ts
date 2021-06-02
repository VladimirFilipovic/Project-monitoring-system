export interface Payment {
    id: string;
    date: Date;
    amount: number;
    currency: string;
    deleted: boolean;
    client?: any;
}

export interface Task {
    id: string;
    name: string;
    completed: boolean;
    description: string;
    deleted: boolean;
    employeeTasks?: any;
}

export interface Demo {
    id: string;
    name: string;
    dateCreated: Date;
    video: string;
    exe: string;
    comment: string;
    deleted: boolean;
}

export interface Documentation {
    id: string;
    name: string;
    version: string;
    dateCreated: Date;
    dateModified?: any;
    pdf: string;
    accepted: boolean;
    deleted: boolean;
    employee?: any;
}

export interface EmployeeProject {
    roleOnProject: string;
    employeeId: string;
    employee?: any;
    projectId: string;
    deleted: boolean;
}

export interface Request {
    id: any;
    name: string;
    requestDate: Date;
    accepted: boolean;
    deleted: boolean;
    specification: any;
    client?: any;
    project?: any;
}

export interface Project {
    id: any;
    name: string;
    isCompleted: boolean;
    deadline: Date;
    deleted: boolean;
    payments?: Payment[];
    tasks?: Task[];
    demos?: Demo[];
    documentation?: Documentation[];
    employeeProjects?: EmployeeProject[];
    request?: Request;
    accepted?: boolean
}