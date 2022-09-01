using AutoMapper;
using Flashcards.Domain.Models.Entities;
using Flashcards.Service.Dtos;

namespace Flashcards.Service.Profiles
{
    public class FolderProfile : Profile
    {
        public FolderProfile()
        {
            CreateMap<Deck, DeckDto>();
            CreateMap<Folder, FolderDto>().ReverseMap();
        }
    }
}
