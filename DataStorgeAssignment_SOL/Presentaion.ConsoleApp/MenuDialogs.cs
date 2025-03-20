using Business.Models;
using Business.Srevices;
using DataStorgeAssignment.Entities;
using DataStorgeAssignment.Migrations;
using Microsoft.Extensions.Options;


namespace Presentaion.ConsoleApp;

public class MenuDialogs(NoteService noteService, ProjectService projectService)
{
    private readonly NoteService _noteService = noteService;

    private readonly ProjectService _projectService = projectService;

    public async Task CreateNote(ProjectEntity project)
    {
        string title = ""; 
        string description = ""; 

        string statusStr = "";
        bool status = false;
        

        Console.Write("Enter note title > ");
        title = Console.ReadLine();
        Console.Write("Enter note description > ");
        description = Console.ReadLine();
        Console.Write("Enter note status (0 OR 1) > ");
        statusStr = Console.ReadLine();
        
    
        if(int.Parse(statusStr) == 0)
        {
            status = false;  
        } else { 
            status = true;
        }

        NoteModel model = new NoteModel
        {
            Id = 0,
            Title = title,
            Description = description,
            Status = status
        };

        var response = await _noteService.CreateNoteAsync(model);


        if(response)
        {
            Console.WriteLine("Note has been created successfully :)");
        }else
        {
            Console.WriteLine("Culdn't create note, something went wrong!");
        }
    }
    public async Task UpdateNote(ProjectEntity project)
    {
        string noteIdStr = "";
        int noteId = 0;

        string newTitle = "";
        string newDescription = "";
        string newStatusStr = "";
        bool newStatus = false;


        Console.Write("Enter note ID that you wish to endit > ");
        noteIdStr = Console.ReadLine();

        noteId = int.Parse(noteIdStr);


        Console.Write("Enter note new title > ");
        newTitle = Console.ReadLine();
        Console.Write("Enter note new description > ");
        newDescription = Console.ReadLine();
        Console.Write("Enter note new status (0 OR 1) > ");
        newStatusStr = Console.ReadLine();

        if (int.Parse(newStatusStr) == 0)
        {
            newStatus = false;
        }
        else
        {
            newStatus = true;
        }

        NoteModel editedNote = new NoteModel
        {
            Id = noteId,
            Title = newTitle,
            Description = newDescription,
            Status = newStatus
        };


        var response = await _noteService.UpdateNoteAsync(noteId, editedNote);

    }

    public async Task DeleteNote(ProjectEntity project)
    {
        string noteIdStr = "";
        int noteId = 0;

        Console.Write("Enter note ID that you wish to delete > ");
        noteIdStr = Console.ReadLine();

        noteId = int.Parse(noteIdStr);


        var response = await _noteService.DeleteNoteAsync(noteId);

        if (response)
        {
            Console.WriteLine("Note has been deleted successfully :)");
        }
        else
        {
            Console.WriteLine("Culdn't delte the note, something went wrong!");
        }

    }

    public async Task ViewAllNotes(ProjectEntity project)
    {

        IEnumerable<NoteEntity> models = await _noteService.GetNotesAsync();

        if (models != null)
        {
            string cc = String.Format("|{0,5}|{1,5}|{2,5}|{3,5}|", "ID", "Title", "Description", "Status");
            Console.WriteLine(cc);

            foreach (NoteEntity noteEntity in models)
            {

                string gg = String.Format("|{0,5}|{1,5}|{2,5}|{3,5}|", noteEntity.Id, noteEntity.Title, noteEntity.Description, noteEntity.Status);
                Console.WriteLine(gg + "\n");

            }

        }
        else
        {
            Console.WriteLine("You dont have any notes to show! Make sure to create one.");
        }

    }

    public void showProjectOpt() {

        Console.WriteLine("1. Select a project");
        Console.WriteLine("2. Create new project");
        Console.WriteLine("3. Update existing project");
        Console.WriteLine("4. Delete project");
        Console.WriteLine("5. View all projects");
        Console.WriteLine("6. Show projects options again");
        Console.WriteLine("9. Exit\n");
        

    }
    public void showNoteOpt()
    {

        Console.WriteLine("1. Create new note");
        Console.WriteLine("2. Update existing note");
        Console.WriteLine("3. Delete note");
        Console.WriteLine("4. View all notes");
        Console.WriteLine("5. Show note options again");
        Console.WriteLine("6. Back to project menu");
        Console.WriteLine("9. Exit\n");

    }

    public async Task SelectProject()
    {
        string projectIdStr;
        int projectIdInt;

        Console.Write("Enter project ID>");
        projectIdStr = Console.ReadLine();

        projectIdInt = int.Parse(projectIdStr);

        ProjectEntity project = await _projectService.GetProjectByIdAsync(projectIdInt);

        if (project == null) {

            Console.WriteLine("PROJECT DOES NOT EXISTS\n");

        }
        else{
            string input;
            int userChoice;

            showNoteOpt();

            while (true)
            {

                Console.Write("Enter your choice >");
                input = Console.ReadLine();

                userChoice = int.Parse(input);

                if(userChoice == 6)
                {
                    Console.WriteLine("BACK TO PROJECT MENU\n");
                    break;
                }


                switch (userChoice)
                {
                    case 1:
                        Console.WriteLine("CREATE NOTE\n");
                        await CreateNote(project);
                        break;
                    case 2:
                        Console.WriteLine("UPDATE NOTE\n");
                        await UpdateNote(project);
                        break;
                    case 3:
                        Console.WriteLine("DELETE NOTE\n");
                        await DeleteNote(project);
                        break;
                    case 4:
                        Console.WriteLine("VIEW NOTE\n");
                        await ViewAllNotes(project);
                        break;
                    case 5:
                        Console.WriteLine("SHOW NOTE OPTIONS\n");
                        showNoteOpt();
                        break;
                    case 9:
                        Console.WriteLine("EXIT\n");
                        System.Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("TRY AGAIN\n");
                        break;
                }

            }
        }

        
    }

    public async Task CreateProject()
    {
        string title = "";
        string description = "";

        string statusStr = "";
        bool status = false;


        Console.Write("Enter project title > ");
        title = Console.ReadLine();
        Console.Write("Enter project description > ");
        description = Console.ReadLine();
        Console.Write("Enter project status (0 OR 1) > ");
        statusStr = Console.ReadLine();


        if (int.Parse(statusStr) == 0)
        {
            status = false;
        }
        else
        {
            status = true;
        }

        ProjectModel project = new ProjectModel
        {
            Id = 0,
            Title = title,
            Description = description,
            Status = status
        };

        var response = await _projectService.CreateProjectAsync(project);



        if (response)
        {
            Console.WriteLine("Project has been created successfully :)");
        }
        else
        {
            Console.WriteLine("Culdn't create project, something went wrong!");
        }
    }

    public async Task UpdateProject()
    {
        string projectIdStr = "";
        int projectId = 0;

        string newTitle = "";
        string newDescription = "";
        string newStatusStr = "";
        bool newStatus = false;


        Console.Write("Enter project ID that you wish to endit > ");
        projectIdStr = Console.ReadLine();

        projectId = int.Parse(projectIdStr);


        Console.Write("Enter note new title > ");
        newTitle = Console.ReadLine();
        Console.Write("Enter note new description > ");
        newDescription = Console.ReadLine();
        Console.Write("Enter note new status (0 OR 1) > ");
        newStatusStr = Console.ReadLine();

        if (int.Parse(newStatusStr) == 0)
        {
            newStatus = false;
        }
        else
        {
            newStatus = true;
        }

        ProjectModel editedProject = new ProjectModel
        {
            Id = projectId,
            Title = newTitle,
            Description = newDescription,
            Status = newStatus
        };


        var response = await _projectService.UpdateProjectAsync(projectId, editedProject);

        if (response)
        {
            Console.WriteLine("Project has been updated successfully :)");
        }
        else
        {
            Console.WriteLine("Culdn't update project, something went wrong!");
        }
    }

    public async Task DeleteProject()
    {
        string projectIdStr = "";
        int projectId = 0;

        Console.Write("Enter note ID that you wish to delete > ");
        projectIdStr = Console.ReadLine();

        projectId = int.Parse(projectIdStr);


        var response = await _projectService.DeleteProjectAsync(projectId);

        if (response)
        {
            Console.WriteLine("Project has been deleted successfully :)");
        }
        else
        {
            Console.WriteLine("Culdn't delte the project, something went wrong!");
        }
    }

    public async Task ViewAllProjects()
    {

        IEnumerable<ProjectEntity> projects = await _projectService.GetProjectsAsync();

        if (projects != null)
        {
            string cc = String.Format("|{0,5}|{1,5}|{2,5}|{3,5}|", "ID", "Title", "Description", "Status");
            Console.WriteLine(cc);

            foreach (ProjectEntity projectEntity in projects)
            {

                string gg = String.Format("|{0,5}|{1,5}|{2,5}|{3,5}|", projectEntity.Id, projectEntity.Title, projectEntity.Description, projectEntity.Status);
                Console.WriteLine(gg + "\n");

            }

        }
        else
        {
            Console.WriteLine("You dont have any projects to show! Make sure to create one.");
        }

    }


    public async Task MenuOptions()
    {
        /**/
        string input;
        int userChoice;

        showProjectOpt();


        while (true) {

            Console.Write("Enter your choice >");

            input = Console.ReadLine();

            userChoice = int.Parse(input);


            switch (userChoice)
            {
                case 1:
                    Console.WriteLine("SELECT PROJECT\n");
                    await SelectProject();
                    break;
                case 2:
                    Console.WriteLine("CREATE PROJECT\n");
                    await CreateProject();
                    break;
                case 3:
                    Console.WriteLine("UPDATE PROJECT\n");
                    await UpdateProject();
                    break;
                case 4:
                    Console.WriteLine("DELETE PROJECT\n");
                    await DeleteProject();
                    break;
                case 5:
                    Console.WriteLine("VIEW PROJECTS\n");
                    await ViewAllProjects();
                    break;
                case 6:
                    Console.WriteLine("SHOW PROJECT OPTIONS\n");
                    showProjectOpt();
                    break;
                case 9:
                    Console.WriteLine("EXIT\n");
                    System.Environment.Exit(1);
                    break;
                default:
                    Console.WriteLine("TRY AGAIN\n");
                    break;
            }



        }
            


    }

}
