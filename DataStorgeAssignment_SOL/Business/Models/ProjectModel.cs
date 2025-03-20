using DataStorgeAssignment.Entities;


namespace Business.Models;

public class ProjectModel
{

    public int Id { get; set; }
    public string Title { get; set; } = null!;

    public string Description { get; set; }
    public bool Status { get; set; }

    public virtual ICollection<NoteEntity> Notes { get; set; }= [];

}
