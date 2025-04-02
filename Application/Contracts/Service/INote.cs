using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common;
using Application.DTOs.Note;
using Domain.Entities;

namespace Application.Contracts.Service
{
    public interface INote
    {
        Task<OperationResult<Exercise>>CreateNoteAsync(CreateNoteDTO createNoteDTO, string userId);
        Task<OperationResult<Note>> DeleteNoteAsync(DeleteNoteDTO deleteNoteDTO, string userId);
    }
}
