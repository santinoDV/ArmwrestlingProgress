using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Note;

namespace Application.DTOs.Exercise
{
    public class ResponseExerciseDTO()
    {
        public string? NameExercise { get; set; }
        public string? DescriptionExercise { get; set; }

        public List<NoteResponseDTO> Notes { get; set; } = new List<NoteResponseDTO>();
    }
}
