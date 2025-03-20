using Business.Models;
using Business.Srevices;
using DataStorgeAssignment.Contexts;
using DataStorgeAssignment.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Presentaion.ConsoleApp;

var servieces = new ServiceCollection()
    .AddDbContext<DataContext>(x => x.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\yzn2\\OneDrive\\Documents\\DataStorgeAssignment_SOL (6)\\DataStorgeAssignment_SOL\\DataStorgeAssignment_SOL\\DataStorgeAssignment\\DataBases\\Local_database.mdf\";Integrated Security=True;Connect Timeout=30"))
    .AddScoped<NoteRepository>()
    .AddScoped<ProjectRepository>()
    .AddScoped<NoteService>()
    .AddScoped<ProjectService>()
    .AddScoped<MenuDialogs>()
    .BuildServiceProvider();


var menuDialogs = servieces.GetRequiredService<MenuDialogs>();

await menuDialogs.MenuOptions();

