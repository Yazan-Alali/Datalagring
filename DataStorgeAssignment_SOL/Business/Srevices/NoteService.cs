

using Business.Models;
using DataStorgeAssignment.Entities;
using DataStorgeAssignment.Repositories;

namespace Business.Srevices;

public class NoteService(NoteRepository noteRepository)
{
    private readonly NoteRepository _noteRepository = noteRepository;


    public async Task<bool> CreateNoteAsync(NoteModel note) 
    {
        
        try{
            var NoteEntity = new NoteEntity
            {
                Id = note.Id,
                Title = note.Title,
                Description = note.Description,
                Status = note.Status,
            };

            await _noteRepository.AddAsync(NoteEntity);

            return true;
        }
        catch (Exception ex) {
            Console.WriteLine(ex);
            return false;
        }

    }


    public async Task<IEnumerable<NoteEntity>?> GetNotesAsync() {

        var noteEntities = await _noteRepository.GetAsync();

        if(noteEntities.Count() == 0)
        {
            return null;
        }

        var notes = new List<NoteEntity>();
        foreach (var noteEntity in noteEntities)
        {
            notes.Add(new NoteEntity
            {
                Id = noteEntity.Id,
                Title = noteEntity.Title,  
                Description = noteEntity.Description,
                Status = noteEntity.Status,
            });
        }

        return notes;
    }


    public async Task<bool> UpdateNoteAsync(int id, NoteModel note) {

        try
        {
            var noteEntity = await _noteRepository.GetAsync(x => x.Id == note.Id);

            if (noteEntity == null) { return false; }

            noteEntity.Title = note.Title;
            noteEntity.Description = note.Description;
            noteEntity.Status = note.Status;

            await _noteRepository.UpdateAsync(noteEntity);

            return true;
        }
        catch (Exception ex) {
            Console.WriteLine(ex);
            return false;
        }


        

    }

    public async Task<bool> DeleteNoteAsync(int id) {

        try
        {
            var noteEntity = await _noteRepository.GetAsync(x => x.Id == id);

            if (noteEntity == null) { return false; }

            await _noteRepository.RemoveAsync(noteEntity);

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }

    }


}
