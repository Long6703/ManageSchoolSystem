
using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using Share.EditModel;
using Share.gPRCContracts;
using Share.Model;
using Share.ViewModel;
using System.Drawing.Printing;
namespace Webapp.Components.Pages
{
    public partial class ListStudent
    {
        [Inject]
        private NavigationManager NavigationManager { get; set; }
        List<UserViewModel> list = new List<UserViewModel>();
        List<Classs> listclass = new List<Classs>();
        private List<UserViewModel> originalDataList;
        private bool showConfirmation = false;
        private int actionToConfirm;
        UserViewModel userview = new UserViewModel();
        public Searching<UserViewModel> searchComponent;
        static int pageSize = 1000;
        static int pageIndex;
        static int totalstudent;
        int totalpage = 0;
        List<int> ints = new List<int>();
        protected override async void OnInitialized()
        {
            pageIndex = 1;
            GetUserResponse2 response = await UserService.GetAllStudentForPageAsync(new GetUserRequest2 { offset = (pageIndex - 1) * pageSize, count = pageSize, searchString = "", classID = ints });
            list = _mapper.Map<List<UserViewModel>>(response.UserInfo);
            totalstudent = response.Total;
            totalpage = (int)Math.Ceiling((double)totalstudent / pageSize);
            if(totalpage == 0)
            {
                totalpage = 1;
            }
            originalDataList = new List<UserViewModel>(list);
            GetClassResponse2 getClassResponse = await UserService.GetClassAsync(new GetClassRequest2 { Message = 1 });
            listclass = getClassResponse.AllClasss;
        }
        private async Task LoadData(int pageindex, string searchitem)
        {
            pageIndex = 1;
            GetUserResponse2 response = await UserService.GetAllStudentForPageAsync(new GetUserRequest2 { offset = (pageindex - 1) * pageSize, count = pageSize, searchString = searchitem, classID = ints });
            list = _mapper.Map<List<UserViewModel>>(response.UserInfo);
            totalstudent = response.Total;
            totalpage = (int)Math.Ceiling((double)totalstudent / pageSize);
            if (totalpage == 0)
            {
                totalpage = 1;
            }
            originalDataList = new List<UserViewModel>(list);
        }

        private void ShowConfirmation(int action, UserViewModel user)
        {
            actionToConfirm = action;
            showConfirmation = true;
            userview = user;
        }

        private async void CancelConfirmation()
        {
            showConfirmation = false;
        }

        private async Task ConfirmActionAsync()
        {
            switch (actionToConfirm)
            {
                case 1:
                    await UserService.DeleteStudentAsync(new DeleteStudentRequest { UserID = userview.UserID });
                    break;
                case 2:
                    await UserService.EditStudentAsync(new EditUserRequest { id = userview.UserID, UserInfor = _mapper.Map<UserEditModel>(userview) });
                    break;
            }
            await LoadData(1, searchComponent.searchTerm);
            showConfirmation = false;
            actionToConfirm = 0;
        }

        public async Task OnStudentCreated()
        {
            await LoadData(1, searchComponent.searchTerm);
        }

        protected async Task HandleSearchResults()
        {
            await LoadData(1, searchComponent.searchTerm);
            StateHasChanged();
        }

        private async Task HandleCheckboxChanged(Dictionary<int, bool> selectedClasses)
        {
            ints.Clear();
            foreach (var item in selectedClasses)
            {
                if(item.Value == true)
                {
                    ints.Add(item.Key);
                }
            }
            await LoadData(1, searchComponent.searchTerm);
            StateHasChanged();
        }

        private async Task ChangePage(int page)
        {
            if (page != pageIndex)
            {
                await LoadData(page, searchComponent.searchTerm);
                NavigationManager.NavigateTo($"/student-list?page={page}");
            }
        }

        private async Task PreviousPage()
        {
            if (pageIndex > 1)
            {
                await LoadData(pageIndex - 1, searchComponent.searchTerm);
                NavigationManager.NavigateTo($"/student-list?page={pageIndex - 1}");
            }
        }

        private async Task NextPage()
        {
            if (pageIndex < totalpage)
            {
                await LoadData(pageIndex + 1, searchComponent.searchTerm);
                NavigationManager.NavigateTo($"/student-list?page={pageIndex + 1}");
            }
        }
    }
}
