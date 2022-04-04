using AutoMapper;
using Backend.Application.Brands.Models;
using Backend.Application.Users.Models;
using Backend.Data.EF;
using Backend.Data.Entities;

namespace Backend.Application.Common.Mapper
{
    public class BackendProfile : Profile
    {
        private readonly BackendDbContext _context;
        public BackendProfile(BackendDbContext context)
        {
            _context = context;
        }

        public BackendProfile()
        {
            CreateMap<CreateUserResource, User>();
            CreateMap<User, UserVm>();

            CreateMap<CreateBrandResource, Brand>();
        }
    }
}