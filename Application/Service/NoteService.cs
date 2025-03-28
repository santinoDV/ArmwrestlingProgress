using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Note;
using Application.Contracts.Persistence;
using Application.Contracts.Service;
using Infrastructure.Repo.Persistence;
using Application.Common;
using Domain.Entities;

namespace Application.Service
{
    public class NoteService: INote
    {
        private readonly IExercise _exercise;
        private readonly INoteRepo _noterepo;
        
        public NoteService (IExercise ex,INoteRepo reponote)
        {
            this._exercise = ex;
            this._noterepo = reponote;
           
        }


        /// <summary>
        ///  gets the Note Data to be added
        /// </summary>
        /// <param name="createNoteDTO">The Note data to be added.</param>
        /// <param name="userId">userId</param>
        /// <returns>Returns 200 OK with the created Exercise if successful, otherwise an error response.</returns>
        public async Task<OperationResult<Exercise>> CreateNoteAsync(CreateNoteDTO createNoteDTO, string userId)
        {
            int.TryParse(userId, out var usId);

            var ExerciseRelated = await _exercise.FindExerciseAsync(usId, createNoteDTO.NameExercise);

            if (ExerciseRelated == null) return OperationResult<Exercise>.Fail("error finding exercise"); ;

             Note addnote = new Note
            {
                Sets = createNoteDTO.Sets,
                Reps = createNoteDTO.Reps,
                Type = createNoteDTO.Type,
                DateOnly = createNoteDTO.DateOnly,
                Duration = createNoteDTO.Duration,
                Exercise = ExerciseRelated,
                ExerciseId = ExerciseRelated.Id,
            };

            var flagNote = await _noterepo.SaveNote(addnote);

            return OperationResult<Exercise>.Ok(ExerciseRelated);

            
        }
    }
}
