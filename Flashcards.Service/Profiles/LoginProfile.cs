using AutoMapper;
using Flashcards.Domain.Models.Entities;
using Flashcards.Service.Dtos;

namespace Flashcards.Service.Profiles
{
    public class LoginProfile : Profile
    {
        public LoginProfile()
        {
            CreateMap<LoginDto, User>();
        }
    }
}
