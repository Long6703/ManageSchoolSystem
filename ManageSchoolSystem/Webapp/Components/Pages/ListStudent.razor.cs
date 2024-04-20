
using Share.EditModel;
using GrpcService.gPRCContracts;
using Share.Model;
using Share.ViewModel;
namespace Webapp.Components.Pages
{
    public partial class ListStudent
    {
        List<UserViewModel> list = new List<UserViewModel>();
        List<Classs> listclass = new List<Classs>();
        List<UserViewModel> originalDataList = new List<UserViewModel>();
        private bool showConfirmation = false;
        private int actionToConfirm;
        UserViewModel userview = new UserViewModel();
        public Searching<UserViewModel> searchComponent;
        static int pageSize = 6;
        static int pageIndex = 1;
        static int totalstudent;
        int totalpage = 0;
        List<int> listClassidSelected = new List<int>();
        protected override async void OnInitialized()
        {
            GetClassResponse getClassResponse = await UserService.GetClassAsync(new GetClassRequest { Message = 1 });
            listclass = getClassResponse.AllClasss;
            await LoadData(pageIndex, "");
        }
        private async Task LoadData(int pageindex, string searchitem)
        {
            try
            {
                GetUserResponseForWebApp response = await UserService.GetAllStudentForPageAsync(new GetUserRequestForWebApp { offset = (pageindex - 1) * pageSize, count = pageSize, searchString = searchitem, classID = listClassidSelected });
                list = _mapper.Map<List<UserViewModel>>(response.UserInfo);
                totalstudent = response.Total;
                totalpage = (int)Math.Ceiling((double)totalstudent / pageSize);
                if (totalpage == 0)
                {
                    totalpage = 1;
                }
                pageIndex = pageindex;
                originalDataList = new List<UserViewModel>(list);
                StateHasChanged();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
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
            await LoadData(pageIndex, searchComponent.searchTerm);
            showConfirmation = false;
            actionToConfirm = 0;
        }

        public async Task AfterStudentCreated()
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
            foreach (var item in selectedClasses)
            {
                if(item.Value == true)
                {
                    listClassidSelected.Add(item.Key);
                }
            }
            await LoadData(1, searchComponent.searchTerm);
            listClassidSelected.Clear();
            StateHasChanged();
        }

        async Task GoToPreviousPageAsync()
        {
            if (pageIndex > 1)
            {
                pageIndex--;
            }
            await LoadData(pageIndex, searchComponent.searchTerm);
        }

        async Task GoToNextPageAsync()
        {
            if (pageIndex < totalpage)
            {
                pageIndex++;
            }
            await LoadData(pageIndex, searchComponent.searchTerm);
        }

        async Task GoToPageAsync(int page)
        {
            pageIndex = page;
            await LoadData(page, searchComponent.searchTerm);
        }
    }
}
