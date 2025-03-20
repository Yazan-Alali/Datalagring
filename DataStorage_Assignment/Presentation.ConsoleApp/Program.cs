using Business.Services;
using Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Presentation.ConsoleApp;

var services = new ServiceCollection();
.AdddbContext<DataContext>(x => x.UseSqlServer())
    .AddScoped<CustomerRepository>()
    .AddScoped<ProjectRepository>()
    .AddScoped<CustomerService>()
    .AddScoped<ProjectService>()
    .AddScoped<MenuDialogs>()
    .BuildServiceProvider();

var menuDialogs = services.GetRequiredService<MenuDialogs>();
await menuDialogs.MenuOptions();

