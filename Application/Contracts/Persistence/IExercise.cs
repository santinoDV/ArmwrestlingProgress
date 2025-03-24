using System;
using Application.DTOs.Exercise;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface IExercise
    {
        Task<List<ResponseExerciseDTO>> GetAllExercisesAsync(int? userId);
        Task<CreateExResponseDTO> CreateExerciseAsync(CreateExerciseDTO createExerciseDTO, int? userId);
    }
}
