using RealEstate.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate.Application.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectDto>> GetAllAsync();
        Task<ProjectDto> GetByIdAsync(int id);
        Task<ProjectDto> CreateAsync(CreateProjectDto createDto);
        Task UpdateAsync(int id, UpdateProjectDto updateDto);
        Task DeleteAsync(int id);
    }
}
