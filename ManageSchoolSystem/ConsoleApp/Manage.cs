using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;
using Share.EditModel;
using Share.Validation;
using GrpcService.gPRCContracts;

namespace ConsoleApp
{
    public class Manage
    {
        public static readonly GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:5211");
        public static void Menu()
        {
            Console.WriteLine("MENU:");
            Console.WriteLine("1. View list of students");
            Console.WriteLine("2. Add new student");
            Console.WriteLine("3. Edit student information");
            Console.WriteLine("4. Delete student");
            Console.WriteLine("5. Sort student data by name");
            Console.WriteLine("6. Search for student by student ID");
            Console.WriteLine("0. Exit");
        }

        public static void CreateStudent()
        {
            Console.Write("Enter display name : ");
            string displayName = Validation.checkInputString();
            Console.Write("Enter email : ");
            string email = Validation.checkValidEmailInput();
            Console.Write("Enter phone number : ");
            string phoneNumber = Validation.IsValidPhoneNumberInput();
            Console.WriteLine("Enter class name : ");
            string className = Validation.checkInputString();
            UserEditModel userEditModel = new UserEditModel
            {
                DisplayName = displayName,
                Email = email,
                ClassName = className,
                PhoneNumber = phoneNumber
            };
            var userServiceClient = channel.CreateGrpcService<IUserService>();
            var reply = userServiceClient.CreateStudentAsync(new CreateUserRequest { useredit = userEditModel });
            Console.WriteLine(reply.Result.Message);
        }

        public static async void GetAllStudent(int sort)
        {
            Console.WriteLine("List of student : ");
            var userServiceClient = channel.CreateGrpcService<IUserService>();
            var reply = userServiceClient.GetAllStudentAsync(new GetUserRequestForConsoleApp { Message = 1 });
            Console.WriteLine("UserID\tDisplayName\t\t\tEmail\t\t\tClassName\t\t\t\tPhoneNumber");
            if(sort == 1)
            {
                reply.Result.UserInfo = reply.Result.UserInfo.OrderBy(x => x.DisplayName).ToList();
            }
            foreach (var user in reply.Result.UserInfo)
            {
                Console.WriteLine($"{user.UserID}\t{user.DisplayName}\t\t\t{user.Email}\t\t{user.Class.ClassName}\t\t\t\t{user.PhoneNumber}");
            }
        }

        public static void EditStudent()
        {
            Console.WriteLine("Enter the StudentID, you want to edit : ");
            int studentID = Validation.checkInputInt();
            var userServiceClient = channel.CreateGrpcService<IUserService>();
            var reply = userServiceClient.GetStudentByIDAsync(new GetStudentByIDRequest { UserID = studentID });
            Console.WriteLine("Student information");
            Console.WriteLine($"Name: {reply.Result.UserViewInfo.DisplayName}");
            Console.WriteLine($"Email: {reply.Result.UserViewInfo.Email}");
            Console.WriteLine($"Phone Number: {reply.Result.UserViewInfo.PhoneNumber}");
            Console.WriteLine($"Class: {reply.Result.UserViewInfo.ClassName}");
            Console.WriteLine("-------------------------------------------------");
            UserEditModel editModel = new UserEditModel();
            Console.Write("Enter new name: ");
            editModel.DisplayName = Validation.checkInputString();
            Console.Write("Enter new email:  ");
            editModel.Email = Validation.checkValidEmailInput();
            Console.Write("Enter new phone number: ");
            editModel.PhoneNumber = Validation.IsValidPhoneNumberInput();
            Console.WriteLine("Enter new class name : ");
            editModel.ClassName = Validation.checkInputString();
            var reply2 = userServiceClient.EditStudentAsync(new EditUserRequest { UserInfor = editModel, id = studentID });
            Console.WriteLine(reply2.Result.Message);

        }

        public static void DeleteStudent()
        {
            Console.WriteLine("Enter the StudentID, you want to delete : ");
            int studentID = Validation.checkInputInt();
            var userServiceClient = channel.CreateGrpcService<IUserService>();
            var reply = userServiceClient.DeleteStudentAsync(new DeleteStudentRequest { UserID = studentID });
            Console.WriteLine(reply.Result.Message);
        }

        public static async void GetStudentByID()
        {
            Console.WriteLine("Enter the StudentID, you want to search : ");
            int studentID = Validation.checkInputInt();
            var userServiceClient = channel.CreateGrpcService<IUserService>();
            var reply = userServiceClient.GetStudentByIDAsync(new GetStudentByIDRequest { UserID = studentID });
            if (reply.Result.UserViewInfo == null)
            {
                Console.WriteLine("Student not found");
            }
            else
            {
                Console.WriteLine("Student information");
                Console.WriteLine($"Name: {reply.Result.UserViewInfo.DisplayName}");
                Console.WriteLine($"Email: {reply.Result.UserViewInfo.Email}");
                Console.WriteLine($"Phone Number: {reply.Result.UserViewInfo.PhoneNumber}");
                Console.WriteLine($"Class: {reply.Result.UserViewInfo.ClassName}");
            }
        }
    }
}
