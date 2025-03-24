using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using


using Application.DTOs.Note;
using Application.Contracts.Persistence;
using Application.Contracts.Service;

namespace Application.Service
{
    public class NoteService: INote
    {
        private readonly IExercise _exercise;
        private readonly INoteRepo _note;
        public NoteService (IExercise ex, INoteRepo note)
        {
            this._exercise = ex;
            this._note = note
        }


        /// <summary>
        ///  gets the NoteData to be added
        /// </summary>
        /// <param name="CreateNoteDTO">The Note data to be added.</param>
        /// <param name="userId">userId</param>
        /// <returns>Returns 200 OK if successful, otherwise an error response.</returns>
        public async Task<CreateNoteResponseDTO> CreateNoteAsync(CreateNoteDTO createNoteDTO, string userId)
        {
            var usId = int.Parse(userId);
            var Exercises = await _exercise.GetAllExercisesAsync(usId);
            bool existsExercise = false
            foreach (var exercise in Exercises)
            {
                if (exercise.NameExercise == createNoteDTO.NameExercise)
                {
                    await _note
                    existsExercise = true; break;
                }
            }

            // necesito una funcion que me identifique el userId y dentro del mismo el ejercicio
        }
    }
}
