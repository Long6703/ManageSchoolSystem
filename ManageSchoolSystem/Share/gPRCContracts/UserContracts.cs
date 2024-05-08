using ProtoBuf.Grpc;
using Share.EditModel;
using Share.Model;
using Share.ViewModel;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace gPRCContracts
{
    [DataContract]
    public class GetUserRequestForConsoleApp
    {
        [DataMember(Order = 1)]
        public int Message { get; set; }
    }

    [DataContract]
    public class GetUserResponseForConsoleApp
    {
        [DataMember(Order = 1)]
        public List<User> UserInfo { get; set; }
    }


    [DataContract]
    public class CreateUserRequest
    {
        [DataMember(Order = 1)]
        public UserEditModel useredit { get; set; }
    }

    [DataContract]
    public class CreateUserResponse
    {
        [DataMember(Order = 1)]
        public string Message { get; set; }
    }

    [DataContract]
    public class EditUserRequest
    {
        [DataMember(Order = 1)]
        public UserEditModel UserInfor
        {
            get; set;
        }

        [DataMember(Order = 2)]
        public int id { get; set; }
    }

    [DataContract]
    public class EditUserResponse
    {
        [DataMember(Order = 1)]
        public string Message { get; set; }
    }

    [DataContract]
    public class GetStudentByIDRequest
    {
        [DataMember(Order = 1)]
        public int UserID { get; set; }
    }

    [DataContract]
    public class GetStudentByIDResponse
    {
        [DataMember(Order = 1)]
        public UserViewModel UserViewInfo { get; set; }
    }

    [DataContract]
    public class DeleteStudentRequest
    {
        [DataMember(Order = 1)]
        public int UserID { get; set; }
    }

    [DataContract]
    public class DeleteStudentResponse
    {
        [DataMember(Order = 1)]
        public string Message { get; set; }
    }

    [DataContract]
    public class GetUserRequestForWebApp
    {
        [DataMember(Order = 1)]
        public int offset { get; set; }

        [DataMember(Order = 2)]
        public int count { get; set; }

        [DataMember(Order = 3)]
        public string? searchString { get; set; }

        [DataMember(Order = 4)]
        public List<int> classID { get; set; }
    }

    [DataContract]
    public class GetUserResponseForWebApp
    {
        [DataMember(Order = 1)]
        public List<User> UserInfo { get; set; }

        [DataMember(Order = 2)]
        public int Total { get; set; }
    }

    [DataContract]
    public class GetClassRequest
    {
        [DataMember(Order = 1)]
        public int Message { get; set; }
    }

    [DataContract]
    public class GetClassResponse
    {
        [DataMember(Order = 1)]
        public List<Classs> AllClasss { get; set; }
    }

    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        Task<GetUserResponseForConsoleApp> GetAllStudentAsync(GetUserRequestForConsoleApp request, CallContext context = default);

        [OperationContract]
        Task<GetUserResponseForWebApp> GetAllStudentForPageAsync(GetUserRequestForWebApp request, CallContext context = default);

        [OperationContract]
        Task<CreateUserResponse> CreateStudentAsync(CreateUserRequest request, CallContext context = default);

        [OperationContract]
        Task<EditUserResponse> EditStudentAsync(EditUserRequest request, CallContext context = default);

        [OperationContract]
        Task<GetStudentByIDResponse> GetStudentByIDAsync(GetStudentByIDRequest request, CallContext context = default);

        [OperationContract]
        Task<DeleteStudentResponse> DeleteStudentAsync(DeleteStudentRequest request, CallContext context = default);

        [OperationContract]
        Task<GetClassResponse> GetClassAsync(GetClassRequest request, CallContext context = default);
    }
}
