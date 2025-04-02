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
        public async Task<OperationResult<NoteResponseDTO>> CreateNoteAsync(CreateNoteDTO createNoteDTO, string userId)
        {
            int.TryParse(userId, out var usId);

            var ExerciseRelated = await _exercise.FindExerciseAsync(usId, createNoteDTO.NameExercise);

            if (ExerciseRelated == null) return OperationResult<NoteResponseDTO>.Fail("error finding exercise"); 

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

            var retNote = await _noterepo.SaveNote(addnote);

            NoteResponseDTO noteResponseDTO = new NoteResponseDTO
            {
                Sets = retNote?.Sets,
                Reps = retNote?.Reps,
                Type = retNote?.Type,
                DateOnly = retNote?.DateOnly,
                Duration = retNote?.Duration,
            };


            return OperationResult<NoteResponseDTO>.Ok(noteResponseDTO);

            
        }
    
        /// <summary>
        /// Deleting note operation method
        /// </summary>
        /// <param name="deleteNoteDTO"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<OperationResult<NoteResponseDTO>> DeleteNoteAsync(DeleteNoteDTO deleteNoteDTO, string userId)
        {
            int.TryParse(userId, out var usId);
            var exercise = await _exercise.FindExerciseAsync(usId, deleteNoteDTO.NameExercise);
            if (exercise == null) return OperationResult<NoteResponseDTO>.Fail("failed finding Exercise");

            
            var note = await _noterepo.GetNoteDB(deleteNoteDTO.DateOnly);
            if (note == null) return OperationResult<NoteResponseDTO>.Fail("Note not Found");

            var ret = _noterepo.DeleteNoteDB(note);

            return OperationResult<NoteResponseDTO>.Ok(ret);


        }
    }
}
