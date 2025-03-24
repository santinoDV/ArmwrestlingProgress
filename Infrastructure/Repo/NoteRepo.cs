using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Note;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Repo
{
    public class NoteRepo
    {
        private readonly IConfiguration _DbContext;
        public NoteRepo(IConfiguration dbContext) 
        {
            this._DbContext = dbContext;
        }

        // CRUD METHODS

        public async Task<> SaveNote(CreateNoteDTO createNoteDTO)
        {
            
        }



        //  QUERY METHODS

        
    }
}
