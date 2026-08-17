using AutoMapper;
using RealEstate.Domain.Entities;
using RealEstate.Application.DTOs;

namespace RealEstate.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {            CreateMap<Project, ProjectDto>().ReverseMap();
            CreateMap<CreateProjectDto, Project>();
            CreateMap<UpdateProjectDto, Project>();            CreateMap<Feature, FeatureDto>().ReverseMap();
            CreateMap<CreateFeatureDto, Feature>();
            CreateMap<UpdateFeatureDto, Feature>();            CreateMap<Plans, PlansDto>().ReverseMap();
            CreateMap<CreatePlansDto, Plans>();
            CreateMap<UpdatePlansDto, Plans>();            CreateMap<Amenties, AmentiesDto>().ReverseMap();
            CreateMap<CreateAmentiesDto, Amenties>();
            CreateMap<UpdateAmentiesDto, Amenties>();
#if false
            CreateMap<Specification, SpecificationDto>().ReverseMap();
            CreateMap<CreateSpecificationDto, Specification>();
            CreateMap<UpdateSpecificationDto, Specification>();            CreateMap<SubSpecification, SubSpecificationDto>().ReverseMap();
            CreateMap<CreateSubSpecificationDto, SubSpecification>();
            CreateMap<UpdateSubSpecificationDto, SubSpecification>();            CreateMap<LocationHighlight, LocationHighlightDto>().ReverseMap();
            CreateMap<CreateLocationHighlightDto, LocationHighlight>();
            CreateMap<UpdateLocationHighlightDto, LocationHighlight>();            CreateMap<SubLocationHighlight, SubLocationHighlightDto>().ReverseMap();
            CreateMap<CreateSubLocationHighlightDto, SubLocationHighlight>();
            CreateMap<UpdateSubLocationHighlightDto, SubLocationHighlight>();
#endif
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>();            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<CreateRoleDto, Role>();
            CreateMap<UpdateRoleDto, Role>();            CreateMap<UserRole, UserRoleDto>().ReverseMap();
            CreateMap<CreateUserRoleDto, UserRole>();
            CreateMap<UpdateUserRoleDto, UserRole>();        }
    }
}
