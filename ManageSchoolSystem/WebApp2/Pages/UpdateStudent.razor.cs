using gPRCContracts;
using Microsoft.AspNetCore.Components;
using Share.EditModel;
using Share.Model;
using Share.ViewModel;

namespace WebApp2.Pages
{
    public partial class UpdateStudent
    {
        [Parameter]
        public UserViewModel userViewModel { get; set; }

        [Parameter]
        public EventCallback OnStudentUpdated { get; set; }

        public List<Classs> Classs = new List<Classs>();

        UserEditModel newUserEditModel = new UserEditModel();

        protected override async Task OnInitializedAsync()
        {
            GetClassResponse getClassResponse = await UserService.GetClassAsync(new GetClassRequest { Message = 1 });
            Classs = getClassResponse.AllClasss;
        }

        public async Task updateUser()
        {
            await UserService.EditStudentAsync(new EditUserRequest { id = userViewModel.UserID, UserInfor = _mapper.Map<UserEditModel>(userViewModel) });
            await OnStudentUpdated.InvokeAsync();
        }

    }
}
