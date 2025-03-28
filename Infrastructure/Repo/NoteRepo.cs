using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts.Service;
using Application.DTOs.Note;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repo.Persistence;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Repo
{
    public class NoteRepo: INoteRepo
    {
        private readonly AppDbContext _DbContext;
        public NoteRepo(AppDbContext dbContext) 
        {
            this._DbContext = dbContext;
        }

        // CRUD METHODS

        public async Task<bool> SaveNote(Note addnote)
        {
              var ret = await _DbContext.Notes.AddAsync(addnote);
              if(ret == null) return false;
              return true;

        }
        //  QUERY METHODS


    }
}
