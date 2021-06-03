
export interface EmployeeTask {
    employeeId: string;
    taskId: string;
    task?: any;
    deleted: boolean;
}

export interface EmployeeProject {
    roleOnProject: string;
    employeeId: string;
    projectId: string;
    project?: any;
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
    project?: any;
}

export interface Employee {
    salary: number;
    startDateOfContract: Date;
    endDateOfContract: Date;
    numberOfActiveProjects: number;
    employeeTasks: EmployeeTask[];
    employeeProjects: EmployeeProject[];
    documentation: Documentation[];
    accountIsActive: boolean;
    deleted?: any;
    id: string;
    userName: string;
    normalizedUserName: string;
    email: string;
    normalizedEmail: string;
    emailConfirmed: boolean;
    passwordHash: string;
    securityStamp: string;
    concurrencyStamp: string;
    phoneNumber: string;
    phoneNumberConfirmed: boolean;
    twoFactorEnabled: boolean;
    lockoutEnd?: any;
    lockoutEnabled: boolean;
    accessFailedCount: number;
}



