using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Note;

namespace Application.Contracts.Service
{
    public interface INote
    {
        Task<CreateNoteResponseDTO> CreateNoteAsync(CreateNoteDTO createNoteDTO, string userId);
    }
}
