using AutoMapper;
using API.Models;
using API.Dtos;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<LeaveRequest,RequestsForListDto>();
            CreateMap<User,UserForListDto>();

        }
        
    }
}