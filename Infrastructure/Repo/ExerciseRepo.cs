using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Exercise;
using Application.DTOs.Note;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Application.Contracts.Persistence;

namespace Infrastructure.Repo
{
    public class ExerciseRepo : IExercise
    { 
       private readonly AppDbContext _DbContext;

       public ExerciseRepo(AppDbContext appDbcontext)
        {
            this._DbContext = appDbcontext;
        }

        //CRUD METHODS

        public async Task<List<ResponseExerciseDTO>> GetAllExercisesAsync(int? userId)
        {
            List<Exercise> Exercises = await _DbContext.Exercises.Where(e => e.UserId == userId).ToListAsync();
            List<ResponseExerciseDTO> exercisesDTO = new List<ResponseExerciseDTO>();

            foreach (var exercise in Exercises)
            {
                var dto = new ResponseExerciseDTO
                {
                    NameExercise = exercise.NameExercise,
                    DescriptionExercise = exercise.Description,
                    Notes = exercise.Notes.Select(note => new NoteResponseDTO
                    {
                        Sets = note.Sets,
                        Reps = note.Reps,
                        Type = note.Type,
                        DateOnly = note.DateOnly,
                        Duration = note.Duration,
                    }).ToList()
                };

                exercisesDTO.Add(dto);
            }

            return exercisesDTO;
        }

        public async Task<CreateExResponseDTO> CreateExerciseAsync(CreateExerciseDTO createExerciseDTO, int? userId)
        {
            // get the new exercise and add it in my DB 
            
            var exercise =  new Exercise
            {
                NameExercise = createExerciseDTO.NameExercise,
                Description = createExerciseDTO.Description,
                Notes = new List<Note>(),
                UserId = userId ?? 0,
            };
            await _DbContext.AddAsync(exercise);

             await _DbContext.SaveChangesAsync();

            return new CreateExResponseDTO(true, "exercise Creation succesfull");
        }

        //QUERY METHODS

        
    }
}
