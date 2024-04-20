using Microsoft.AspNetCore.Components;
using Share.EditModel;
using GrpcService.gPRCContracts;

namespace Webapp.Components.Pages
{
    public partial class CreatStudent
    {
        [Parameter]
        public bool pressButton { get; set; } = false;

        [Parameter]
        public EventCallback OnStudentCreated { get; set; }

        UserEditModel newUserEditModel = new UserEditModel();

        public void PressButton()
        {
            pressButton = true;
        }

        public void Cancel()
        {
            pressButton = false;
        }

        public async Task CreateUser()
        {
            pressButton = false;
            await Task.Delay(1000);
            CreateUserResponse reply =  await UserService.CreateStudentAsync(new CreateUserRequest { useredit = newUserEditModel });
            await OnStudentCreated.InvokeAsync();
        }
    }
}

