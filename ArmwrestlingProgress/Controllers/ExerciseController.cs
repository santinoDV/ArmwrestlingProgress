using Application.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArmwrestlingProgressAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IExcercise _exercise;
        public ExerciseController(IExcercise exercise) 
        {
            this._exercise = exercise;
        }

        [HttpGet]


    }
}
