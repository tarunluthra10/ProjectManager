export class Task {
    TaskId: number;
    TaskName: string;
    IsParentTask: boolean;
    ProjectId: number;
    ProjectName: string;
    ManagerId: number;
    ManagerName: string;
    Priority: number;
    StartDate: Date;
    EndDate: Date;
    Completed: string;
    ParentTaskId: number;
    ParentTaskName: string;
}
