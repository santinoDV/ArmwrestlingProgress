using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entities;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Note
{
    public class DeleteNoteDTO
    {   
        [Required]
        public int Id { get; set; }
        [Required]
        public string? NameExercise { get; set; }

        [Required]
        public DateOnly DateOnly { get; set; }
    }
}
