using System.Reflection;
using Autofac.Extensions.DependencyInjection;
using MessagingPlatform.DAL.Context;
using MessagingPlatform.DAL.Repositories;
using MessagingPlatform.Interfaces;
using MessagingPlatform.Interfaces.Repositories;
using MessagingPlatform.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

var services = builder.Services;
services.AddControllersWithViews();
services.AddDbContext<DataDbContext>(options => options
    .UseSqlServer(builder.Configuration.GetConnectionString("default")));
services.AddScoped(typeof(IRepository<>), typeof(DbRepository<>));
services.AddScoped<IUsersManager, UsersManager>();
services.AddAutoMapper(Assembly.GetEntryAssembly());

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern:"{controller=Home}/{action=Index}/{id?}");

app.Run();
