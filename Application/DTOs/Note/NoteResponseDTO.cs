using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Application.DTOs.Note
{
    public class NoteResponseDTO
    {
        public int Sets {  get; set; }
        public int Reps {  get; set; }

        public TypeExercise Type { get; set; }
        public DateOnly DateOnly { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
