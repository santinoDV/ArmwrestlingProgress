using System.Security.Claims;
using Application.Contracts.Service;
using Application.DTOs.Note;
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
        public async Task<ActionResult<CreateNoteResponseDTO>> CreateNote(CreateNoteDTO createNoteDTO)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if(userId == null) return Unauthorized();

            var ret = _note.
            // ahora necesito una forma que identifique el ejercicio correspondiente

        }
    }
}
