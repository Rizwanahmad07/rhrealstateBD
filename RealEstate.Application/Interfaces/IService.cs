using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate.Application.Interfaces
{
    public interface IService<TEntity, TDto, TCreateDto, TUpdateDto> where TEntity : class
    {
        Task<TDto> GetByIdAsync(int id);
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto> CreateAsync(TCreateDto createDto);
        Task UpdateAsync(int id, TUpdateDto updateDto);
        Task DeleteAsync(int id);
    }
}
