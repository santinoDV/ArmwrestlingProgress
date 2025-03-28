using System;
using Application.DTOs.Exercise;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Contracts.Persistence
{
    public interface IExercise
    {
        // CRUD METHODS
        Task<List<ResponseExerciseDTO>> GetAllExercisesAsync(int? userId);
        Task<CreateExResponseDTO> CreateExerciseAsync(CreateExerciseDTO createExerciseDTO, int? userId);

        // QUERY METHODS
        Task<Exercise?> FindExerciseAsync(int? userId,string NameExercise);

    }
}
