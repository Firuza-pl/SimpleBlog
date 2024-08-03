
using AutoMapper;
using Blog.Client.Pages.Project;
using Blog.Shared.DTOs;

namespace Blog.Application.Automapper.MappingProfiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, ProjectDTO>();
        }
    }
}
