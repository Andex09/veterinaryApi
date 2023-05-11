using AutoMapper;
using back.DTO;
using back.Models;

namespace back.Profiles
{
    public class PetProfile : Profile
    {
        public PetProfile()
        {
            CreateMap<Pet, PetDTO>();
            CreateMap<PetDTO, Pet>();
        }
    }
}
