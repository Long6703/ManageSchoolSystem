using ProtoBuf.Grpc;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Share.gPRCContracts
{
    [DataContract]
    public class GetClassRequest
    {
        [DataMember(Order = 1)]
        public int ClassId { get; set; }
    }

    [DataContract]
    public class GetClassResponse
    {
        [DataMember(Order = 1)]
        public ClassInfo ClassInfo { get; set; }
    }

    [DataContract]
    public class ClassInfo
    {
        [DataMember(Order = 1)]
        public int ClassId { get; set; }

        [DataMember(Order = 2)]
        public string ClassName { get; set; }
    }

    [ServiceContract]
    public interface ITestService
    {
        [OperationContract]
        Task<GetClassResponse> GetClassAsync(GetClassRequest request,
            CallContext context = default);
    }
}

