using RealEstate.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate.Application.Interfaces
{
    public interface IAmentiesService
    {
        Task<IEnumerable<AmentiesDto>> GetAllAsync();
        Task<AmentiesDto> GetByIdAsync(int id);
        Task<AmentiesDto> CreateAsync(CreateAmentiesDto createDto);
        Task UpdateAsync(int id, UpdateAmentiesDto updateDto);
        Task DeleteAsync(int id);
    }
}
