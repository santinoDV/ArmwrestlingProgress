using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Repo.Persistence
{
    public interface INoteRepo
    {
        public Task<bool> SaveNote(Note addnote);
    }
}
