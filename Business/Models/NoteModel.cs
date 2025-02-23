namespace Business.Models;
public class NoteModel
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public bool Status { get; set; }

}
