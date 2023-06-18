using AutoMapper;
using WebUj.DTO;
using WebUj.Models;

namespace WebUj.Helper
{
    public class MappingProfiles : Profile
    {
        // Adatbázis tábla modellek és DTO-k közötti adattovábbítást definiálja
        public MappingProfiles() 
        {
            CreateMap<Component, ComponentDto>();
            CreateMap<ComponentDto, Component>();

            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();

            CreateMap<Progress, ProgressDto>();
            CreateMap<ProgressDto, Progress>();

            CreateMap<Project, ProjectDto>();
            CreateMap<ProjectDto, Project>();

            CreateMap<Storage, StorageDto>();
            CreateMap<StorageDto, Storage>();

            CreateMap<ComponentsToProject, ComponentsToProjectDto>();
            CreateMap<ComponentsToProjectDto, ComponentsToProject>();
        }
    }
}
