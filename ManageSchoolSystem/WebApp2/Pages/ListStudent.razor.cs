using AntDesign;
using gPRCContracts;
using Microsoft.AspNetCore.Components;
using Share.EditModel;
using Share.ViewModel;

namespace WebApp2.Pages
{

    public partial class ListStudent
    {
        List<UserViewModel> list = new List<UserViewModel>();
        List<UserViewModel> originalDataList = new List<UserViewModel>();
        UserViewModel userview = new UserViewModel();
        public Searching<UserViewModel> searchComponent;
        static int pageSize = 6;
        static int pageIndex = 1;
        static int totalstudent;
        List<int> listClassidSelected = new List<int>();
        bool visible = false;
        bool visibleCreate = false;

        void openCreate()
        {
            this.visibleCreate = true;
        }
        void open(UserViewModel userview2)
        {
            this.visible = true;
            userview = userview2;
        }
        protected override async Task OnInitializedAsync()
        {
            await LoadData(pageIndex, "", listClassidSelected);
        }
        private async Task LoadData(int pageindex, string searchitem, List<int> listselectedclass)
        {
            try
            {
                GetUserResponseForWebApp response = await UserService.GetAllStudentForPageAsync(new GetUserRequestForWebApp
                {
                    offset = (pageindex - 1) * pageSize,
                    count = pageSize,
                    searchString = searchitem,
                    classID = listselectedclass
                });
                list = _mapper.Map<List<UserViewModel>>(response.UserInfo);
                totalstudent = response.Total;
                pageIndex = pageindex;
                originalDataList = new List<UserViewModel>(list);
                StateHasChanged();
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
        }

        public async Task DeleteStudent(UserViewModel userview)
        {
            await UserService.DeleteStudentAsync(new DeleteStudentRequest { UserID = userview.UserID });
            await LoadData(pageIndex, searchComponent.searchTerm, listClassidSelected);
        }

        public async Task AfterStudentCreated()
        {
            await LoadData(1, searchComponent.searchTerm, listClassidSelected);
        }

        protected async Task HandleSearchResults()
        {
            await LoadData(1, searchComponent.searchTerm, listClassidSelected);
            StateHasChanged();
        }

        private async Task HandleCheckboxChanged(Dictionary<int, bool> selectedClasses)
        {
            listClassidSelected.Clear();
            foreach (var item in selectedClasses)
            {
                if (item.Value == true)
                {
                    listClassidSelected.Add(item.Key);
                }
            }
            await LoadData(1, searchComponent.searchTerm, listClassidSelected);
            StateHasChanged();
        }

        async Task GoToPageAsync(PaginationEventArgs e)
        {
            pageIndex = e.Page;
            await LoadData(pageIndex, searchComponent.searchTerm, listClassidSelected);
        }
    }
}
