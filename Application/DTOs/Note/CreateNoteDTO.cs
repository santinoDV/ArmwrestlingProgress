using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Enums;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Note
{
    public class CreateNoteDTO
    {
        [Required]
        public int Sets { get; set; }
        public int Reps { get; set; }
        [Required]
        public TypeExercise TypeExercise { get; set; }
        [Required]
        public DateOnly DateOnly { get; set; }
        public TimeSpan Duration {  get; set; }

        [Required]
        public string? NameExercise { get; set; }

    }
}
