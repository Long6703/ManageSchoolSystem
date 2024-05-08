using AntDesign;
using Grpc.Net.Client;
using gPRCContracts;
using Webapp.Components;
using ProtoBuf.Grpc.Client;

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
            builder.Services.AddScoped<IUserService>(services =>
            {
                return channel.CreateGrpcService<IUserService>();
            });
            builder.Services.AddAutoMapper(typeof(Program).Assembly);
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
