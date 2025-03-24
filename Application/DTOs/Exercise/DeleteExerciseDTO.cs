using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Exercise
{
    public class DeleteExerciseDTO
    {
        [Required]
        public string? NameExercise { get; set; }
    }
}
