using gPRCContracts;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using ProtoBuf.Grpc.Client;
using WebApp2.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

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

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
