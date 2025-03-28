using System.Security.Claims;
using Application.Common;
using Application.Contracts.Service;
using Application.DTOs.Note;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArmwrestlingProgressAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INote _note;
        public NoteController(INote note) 
        {
            this._note = note;
        }
        [HttpPost("newnote")]
        [Authorize]
        public async Task<ActionResult<OperationResult<Exercise>>> CreateNote(CreateNoteDTO createNoteDTO)
        {
            var userId =  User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if(userId == null) return Unauthorized();

            return await _note.CreateNoteAsync(createNoteDTO,userId);
            // ahora necesito una forma que identifique el ejercicio correspondiente

        }

        [HttpDelete("deletenote")]
        [Authorize]

        public async Task<ActionResult<OperationResult<Note>>> DeleteNote(DeleteNoteDTO deleteNoteDTO)
        {
            // confirmar existencia de 
        }
    }
}
