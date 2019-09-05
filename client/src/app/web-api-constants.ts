export class ApiMockUrl {
    constructor(public api: string, public mock: string) {
    }
}

export const WebApiConstants = {
    GetAllProjects: new ApiMockUrl('Project/GetAllProjects','../mockData/GetAllProjects.json'),
    AddNewProject: new ApiMockUrl('Project/AddNewProject','../mockData/AddNewProject.json'),
    UpdateProject: new ApiMockUrl('Project/UpdateProject','../mockData/UpdateProject.json'),
    RemoveProject: new ApiMockUrl('Project/RemoveProject','../mockData/RemoveProject.json'),
    GetAllUsers: new ApiMockUrl('Users/GetAllUsers','../mockData/GetAllUsers.json'),
    AddNewUser: new ApiMockUrl('Users/AddNewUser','../mockData/AddNewUser.json'),
    UpdateUser: new ApiMockUrl('Users/UpdateUser','../mockData/UpdateUser.json'),
    RemoveUser: new ApiMockUrl('Users/RemoveUser','../mockData/RemoveUser.json'),
    GetAllTasks: new ApiMockUrl('Tasks/GetAllTasks','../mockData/GetAllTasks.json'),
    GetAllPriorityTasks: new ApiMockUrl('Tasks/GetAllParentTasks','../mockData/GetAllParentTasks.json'),
    AddNewTask: new ApiMockUrl('Tasks/AddNewTask','../mockData/AddNewTask.json'),
    UpdateTask: new ApiMockUrl('Tasks/UpdateTask','../mockData/UpdateTask.json'),
    RemoveTask: new ApiMockUrl('Tasks/RemoveTask','../mockData/RemoveTask.json'),
    GetAlltaskForProject: new ApiMockUrl('Tasks/GetAllTaskForProject','../mockData/GetAllTaskForProject.json')

}
