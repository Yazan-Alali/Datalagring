using Business.Srevices;
using DataStorgeAssignment.Contexts;
using DataStorgeAssignment.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Presentaion.ConsoleApp;

var servieces = new ServiceCollection()
    .AddDbContext<DataContext>(x => x.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\1\\source\\repos\\DataStorgeAssignment_SOL\\DataStorgeAssignment\\DataBases\\Local_database.mdf;Integrated Security=True;Connect Timeout=30"))
    .AddScoped<NoteRepository>()
    .AddScoped<NoteService>()
    .AddScoped<menuDialogs>()
    .BuildServiceProvider();


var menuDialogs = servieces.GetRequiredService<menuDialogs>();

await menuDialogs.MenuOptions();