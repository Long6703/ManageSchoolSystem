using Microsoft.AspNetCore.Components;
using Share.EditModel;
using gPRCContracts;
using Share.Model;

namespace Webapp.Components.Pages
{
    public partial class CreatStudent
    {
        [Parameter]
        public bool pressButton { get; set; } = false;

        [Parameter]
        public EventCallback OnStudentCreated { get; set; }

        public List<Classs> Classs = new List<Classs>();

        UserEditModel newUserEditModel = new UserEditModel();

        protected override async Task OnInitializedAsync()
        {
            GetClassResponse getClassResponse = await UserService.GetClassAsync(new GetClassRequest { Message = 1 });
            Classs = getClassResponse.AllClasss;
        }

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

