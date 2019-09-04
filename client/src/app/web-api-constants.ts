export class ApiMockUrl {
    constructor(public api: string, public mock: string) {
    }
}

export const WebApiConstants = {
    GetAllProjects: new ApiMockUrl('Project/GetAllProjects',''),
    AddNewProject: new ApiMockUrl('Project/AddNewProject',''),
    UpdateProject: new ApiMockUrl('Project/UpdateProject',''),
    RemoveProject: new ApiMockUrl('Project/RemoveProject',''),
    GetAllUsers: new ApiMockUrl('Users/GetAllUsers',''),
    AddNewUser: new ApiMockUrl('Users/AddNewUser',''),
    UpdateUser: new ApiMockUrl('Users/UpdateUser',''),
    RemoveUser: new ApiMockUrl('Users/RemoveUser',''),
    GetAllTasks: new ApiMockUrl('Tasks/GetAllTasks',''),
    GetAllPriorityTasks: new ApiMockUrl('Tasks/GetAllPriorityTasks',''),
    AddNewTask: new ApiMockUrl('Tasks/AddNewTask',''),
    UpdateTask: new ApiMockUrl('Tasks/UpdateTask',''),
    RemoveTask: new ApiMockUrl('Tasks/RemoveTask',''),
    GetAlltaskForProject: new ApiMockUrl('Tasks/GetAllTaskForProject','')

}
