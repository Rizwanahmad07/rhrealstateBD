using RealEstate.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate.Application.Interfaces
{
    public interface IPlansService
    {
        Task<IEnumerable<PlansDto>> GetAllAsync();
        Task<PlansDto> GetByIdAsync(int id);
        Task<PlansDto> CreateAsync(CreatePlansDto createDto);
        Task UpdateAsync(int id, UpdatePlansDto updateDto);
        Task DeleteAsync(int id);
    }
}
