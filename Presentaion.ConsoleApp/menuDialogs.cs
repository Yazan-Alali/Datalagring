using Business.Models;
using Business.Srevices;
using DataStorgeAssignment.Entities;
using static System.Net.Mime.MediaTypeNames;


namespace Presentaion.ConsoleApp;

public class menuDialogs(NoteService noteService)
{
    private readonly NoteService _noteService = noteService;

    public async Task CreateNote()
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

        Console.WriteLine(response);


        if(response)
        {
            Console.WriteLine("Note has been created successfully :)");
        }else
        {
            Console.WriteLine("Culdn't create note, something went wrong!");
        }
    }
    public async Task UpdateNote()
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

    public async Task DeleteNote()
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

    public async Task ViewAllNotes()
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

    public void showMenuOpt() {

        Console.WriteLine("1. Create new note");
        Console.WriteLine("2. Update existing note");
        Console.WriteLine("3. Delete existing note");
        Console.WriteLine("4. View all notes\n");

    }

    public async Task MenuOptions()
    {
        string input;
        int userChoice;

        showMenuOpt();


        while (true) {

            Console.Write("Enter your choice >");

            input = Console.ReadLine();

            userChoice = int.Parse(input);


            switch (userChoice)
            {
                case 1:
                    Console.WriteLine("CREATE\n");

                    await CreateNote();

                    break;
                case 2:
                    Console.WriteLine("UPDATE\n");
                    await UpdateNote();
                    break;
                case 3:
                    Console.WriteLine("DELETE\n");
                    await DeleteNote();
                    break;
                case 4:
                    Console.WriteLine("VIEW\n");
                    await ViewAllNotes();
                    break;
                case 5:
                    Console.WriteLine("Show menu options again\n");
                    showMenuOpt();
                    break;
                case 9:
                    Console.WriteLine("Exit\n");
                    System.Environment.Exit(1);
                    break;
                default:
                    Console.WriteLine("TRY AGAIN\n");
                    break;
            }



        }

    }

}
