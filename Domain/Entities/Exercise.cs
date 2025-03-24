using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Exercise
    {
            public int Id { get; set; }
            public string? NameExercise { get; set; }
            public string? Description { get; set; }
            public ApplicationUser? User { get; set; }// para relacionar user
            public int UserId { get; set; }


            public List<Note> Notes { get; set; } = new();
    }
}
