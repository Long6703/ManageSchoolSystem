using Share.Model;
using Share.ViewModel;
using Repository;
using System.ComponentModel;
using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;
using GrpcService.gPRCContracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository.IRepo;
using Repository.RepoImplement;
using Share.Validation;
namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello word");

            //using var channel = GrpcChannel.ForAddress("https://localhost:7173");
            //var client = channel.CreateGrpcService<ITestService>();

            //var reply = await client.GetClassAsync(
            //    new GetClassRequest { ClassId = 1 });

            //Console.WriteLine($"ClassID: {reply.ClassInfo.ClassId}");
            //Console.WriteLine($"ClassName: {reply.ClassInfo.ClassName}");
            //Console.WriteLine("Press any key to exit...");
            //Console.ReadKey();

            //IHost _host = Host.CreateDefaultBuilder().ConfigureServices(
            //    services =>
            //    {
            //        services.AddSingleton<ITestService>();
            //    }).Build();

            //var app = _host.Services.GetRequiredService<ITestService>();

            //using var channel = GrpcChannel.ForAddress("https://localhost:7173");
            //var client = channel.CreateGrpcService<ITestService>();

            //app.SayHelloAsyncInTest(new HelloRequest { Name = "Nguyen Khac Long Test" });
            //Console.ReadKey();

            //using (var session = NHibernateConfig.OpenSession())
            //{
            //    var classes = session.Get<Classes>(1);
            //    Console.WriteLine(classes.classId);
            //    Console.WriteLine(classes.className);

            //}

            //Classs classes = new Classs();
            //classes.ClassName = "SE6703";

            //using (var session = NHibernateConfig.OpenSession())
            //{
            //    using (var transaction = session.BeginTransaction())
            //    {
            //        session.Save(classes);
            //        transaction.Commit();
            //        Console.WriteLine("Done");
            //    }
            //}
            //int a = 0;
            //if(a == 1)
            //{
            //    using var channel = GrpcChannel.ForAddress("http://localhost:5211");
            //    var client = channel.CreateGrpcService<ITestService>();

            //    var reply = client.GetClassAsync(
            //                       new GetClassRequest { ClassId = 1 });

            //    Console.WriteLine($"ClassID: {reply.Result.ClassInfo.ClassId}");
            //    Console.WriteLine($"ClassName: {reply.Result.ClassInfo.ClassName}");
            //    Console.WriteLine("Press any key to exit...");
            //    Console.ReadKey();
            //}
            //else if(a == 2)
            //{
            //    using var channel = GrpcChannel.ForAddress("http://localhost:5211");
            //    var userServiceClient = channel.CreateGrpcService<IUserService>();
            //    var reply = userServiceClient.GetAllStudentAsync(new GetUserRequest { Message = 1 });
            //    Console.WriteLine("UserID\tDisplayName\tEmail\t\t\tClassName");
            //    foreach (var user in reply.Result.UserInfo)
            //    {
            //        Console.WriteLine($"{user.UserID}\t{user.DisplayName}\t{user.Email}\t{user.ClassName}");
            //    }
            //}

            //using var channel = GrpcChannel.ForAddress("http://localhost:5211");
            //var userServiceClient = channel.CreateGrpcService<IUserService>();
            //var reply = userServiceClient.GetAllStudentAsync(new GetUserRequest { Message = 1 });
            //Console.WriteLine("UserID\tDisplayName\tEmail\tClassName");
            //Console.WriteLine($"{reply.Result.UserInfo.UserID}\t{reply.Result.UserInfo.DisplayName}\t{reply.Result.UserInfo.Email}\t{reply.Result.UserInfo.ClassName}");

            //IUserRepo userRepo = new UserRepoImplement();
            //var users = userRepo.GetAllStudent();
            //foreach (var user in users)
            //{
            //    Console.WriteLine($"{user.UserID}\t{user.DisplayName}\t{user.Email}\t{user.Class.ClassName}");
            //}   
            while (true)
            {
                Manage.Menu();
                Console.Write("Please choose an option (enter the corresponding number): ");
                int input = Validation.checkInputChoice(6, 0);
                switch (input)
                {
                    case 1:
                        Manage.GetAllStudent(0);
                        break;
                    case 2:
                        Manage.CreateStudent();
                        break;
                    case 3:
                        Manage.EditStudent();
                        break;
                    case 4:
                        Manage.DeleteStudent();
                        break;
                    case 5:
                        Manage.GetAllStudent(1);
                        break;
                    case 6:
                        Manage.GetStudentByID();
                        break;
                    case 0:
                        Console.WriteLine("Exiting the program.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please choose again.");
                        break;
                }
                Console.WriteLine();
            }

        }
    }
}
