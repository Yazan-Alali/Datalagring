using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStorgeAssignment.Entities
{
    public class ProjectEntity
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<NoteEntity> Notes { get; set; } = [];




    }
}
