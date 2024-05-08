using gPRCContracts;
using Microsoft.AspNetCore.Components;
using Share.EditModel;
using Share.Model;

namespace WebApp2.Pages
{
    public partial class CreatStudent
    {
        [Parameter]
        public EventCallback OnStudentCreated { get; set; }

        public List<Classs> Classs = new List<Classs>();

        UserEditModel newUserEditModel = new UserEditModel();

        [Parameter]
        public EventCallback<string> SendMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            GetClassResponse getClassResponse = await UserService.GetClassAsync(new GetClassRequest { Message = 1 });
            Classs = getClassResponse.AllClasss;
        }

        public async Task CreateUser()
        {
            CreateUserResponse reply = await UserService.CreateStudentAsync(new CreateUserRequest { useredit = newUserEditModel });
            await OnStudentCreated.InvokeAsync();
            await SendMessage.InvokeAsync(reply.Message);
        }
    }
}
