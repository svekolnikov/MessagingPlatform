using System.Reflection;
using Autofac.Extensions.DependencyInjection;
using MessagingPlatform.DAL.Context;
using MessagingPlatform.DAL.Repositories;
using MessagingPlatform.Interfaces;
using MessagingPlatform.Interfaces.Repositories;
using MessagingPlatform.Interfaces.SMTP;
using MessagingPlatform.Services;
using MessagingPlatform.Services.SMTP;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// Add services to the container.
var services = builder.Services;
services.AddControllersWithViews();
services.AddDbContext<DataDbContext>(options => options
    .UseSqlServer(builder.Configuration.GetConnectionString("default")));
services.AddScoped(typeof(IRepository<>), typeof(DbRepository<>));
services.AddScoped<IUsersManager, UsersManager>();
services.AddAutoMapper(Assembly.GetEntryAssembly());

//SMTP
services.AddSingleton<IEmailConfiguration>(builder
    .Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>());
services.AddTransient<IEmailService, EmailService>();

//Razor View to string
services.AddScoped<IRazorViewToStringRenderer, RazorViewToStringRenderer>();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern:"{controller=Home}/{action=Index}/{id?}");

app.Run();
