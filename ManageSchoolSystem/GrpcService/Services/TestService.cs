using ProtoBuf.Grpc;
using Repository.IRepo;
using Repository.RepoImplement;
using Share.gPRCContracts;

namespace GrpcService.Services
{
    public class TestService : ITestService
    {
        public Task<GetClassResponse> GetClassAsync(GetClassRequest request, CallContext context = default)
        {
            ITestRepo testRepo = new TestRepoImplement();
            var classes = testRepo.GetClassById(request.ClassId);
            return Task.FromResult(new GetClassResponse
            {
                ClassInfo = new ClassInfo
                {
                    ClassId = classes.ClassId,
                    ClassName = classes.ClassName
                }
            });
        }
    }
}
