export class ApiMockUrl {
    constructor(public api: string, public mock: string) {
    }
}

export const WebApiConstants = {
    GetAllProjects: new ApiMockUrl('',''),
    SaveProject: new ApiMockUrl('',''),
    GetAllUsers: new ApiMockUrl('Users/GetAllUsers',''),
    AddNewUser: new ApiMockUrl('Users/AddNewUser','')

}
