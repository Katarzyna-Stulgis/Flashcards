using Flashcards.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Dal.Repositories
{
    public class DeckUserRepository : EFCoreRepository<DeckUser, DbContext>
    {
        public DeckUserRepository(DbContext dbContext) : base(dbContext) { }
    }
}
