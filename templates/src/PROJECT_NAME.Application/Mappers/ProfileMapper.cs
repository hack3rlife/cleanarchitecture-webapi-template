using AutoMapper;
using PROJECT_NAME.Application.Dtos;
using PROJECT_NAME.Domain.Entities;

namespace PROJECT_NAME.Application.Mappers
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            CreateMap<Status, StatusResponse>();
        }
    }
}
