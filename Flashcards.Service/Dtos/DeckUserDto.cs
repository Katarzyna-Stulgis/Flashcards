using Flashcards.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Service.Dtos
{
    public class DeckUserDto
    {
        public bool IsEditable { get; set; }
        public Guid DeckId { get; set; }
        public Guid UserId { get; set; }
    }
}
