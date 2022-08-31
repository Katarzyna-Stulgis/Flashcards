using AutoMapper;
using Flashcards.Domain.Models.Entities;
using Flashcards.Service.Dtos;

namespace Flashcards.Service.Profiles
{
    public class RegisterProfile : Profile
    {
        public RegisterProfile()
        {
            CreateMap<RegisterUserDto, User>();
        }
    }
}
