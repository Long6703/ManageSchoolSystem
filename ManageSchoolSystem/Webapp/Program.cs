using AntDesign;
using Grpc.Net.Client;
using GrpcService.Services;
using Repository.IRepo;
using Repository.RepoImplement;
using GrpcService.gPRCContracts;
using Webapp.Components;

namespace Webapp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            var channel = GrpcChannel.ForAddress("http://localhost:5211");
            builder.Services.AddSingleton(channel);
            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            builder.Services.AddSingleton<IUserService, UserService>();
            builder.Services.AddSingleton<IUserRepo, UserRepoImplement>();
            builder.Services.AddSingleton<AntDesign.IMessageService, AntDesign.MessageService>();
            builder.Services.AddAntDesign();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
