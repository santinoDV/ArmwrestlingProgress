using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
namespace Application.DTOs.Exercise
{
    public class CreateExerciseDTO
    {
        [Required]
        public string? NameExercise { get; set; }

        public string? Description { get; set; }

    }
}
