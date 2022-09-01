using Flashcards.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Service.Dtos
{
    public class DeckDto
    {
        public Guid DeckId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public VisibilityType VisibilityType { get; set; }
    }
}
