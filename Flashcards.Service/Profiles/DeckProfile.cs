using AutoMapper;
using Flashcards.Domain.Models.Entities;
using Flashcards.Service.Dtos;

namespace Flashcards.Service.Profiles
{
    public class DeckProfile : Profile
    {
        public DeckProfile()
        {
            CreateMap<DeckUser, DeckUserDto>().ReverseMap();
            CreateMap<Flashcard, FlashcardDto>().ReverseMap();
            CreateMap<DeckFolder, DeckFolderDto>().ReverseMap();
            CreateMap<Deck, DeckDto>()
                .ForMember(dest => dest.Flashcards, opt => opt.MapFrom(src => src.Flashcards)).ReverseMap(); ;
        }
    }
}
