using Application.DTOs.Exercise;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Application.Contracts.Persistence;

namespace ArmwrestlingProgressAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IExercise _exercise;
        private readonly IUser _user;
        private int? userId => GetUserId();
        public ExerciseController(IExercise exercise, IUser user) 
        {
            this._exercise = exercise;
            this._user = user;
        }

        private int? GetUserId() { // Obtener el userId directamente
            var usId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
           if (string.IsNullOrEmpty(usId)) return (int?)null;

           return int.Parse(usId);
        }


        [HttpGet("getexercises")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ResponseExerciseDTO>>> GetExercises()
        {
           if(userId == null) return Unauthorized();

            var exercises = await _exercise.GetAllExercisesAsync(userId);

            return Ok(exercises.ToList());

        }

        [HttpPost("newexercise")]
        [Authorize]
        public async Task<ActionResult<CreateExResponseDTO>> CreateExercise(CreateExerciseDTO createExerciseDTO)
        {
            if(userId == null) return Unauthorized();
            var ret = await _exercise.CreateExerciseAsync(createExerciseDTO, userId);
            return Ok(ret);
        }



    }
}
