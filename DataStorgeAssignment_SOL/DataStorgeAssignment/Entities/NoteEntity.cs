using System.ComponentModel.DataAnnotations;

namespace DataStorgeAssignment.Entities;


public class NoteEntity
{
    [Key]
    public int Id { get; set; }

    public int ProjectId { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; }
    public bool Status { get; set; }

    public virtual ProjectEntity Project { get; set; } = null!;


}
