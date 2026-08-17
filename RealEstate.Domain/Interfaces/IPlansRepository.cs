using System.Collections.Generic;
using System.Threading.Tasks;
using RealEstate.Domain.Entities;

namespace RealEstate.Domain.Interfaces
{
    public interface IPlansRepository
    {
        Task<Plans> GetByIdAsync(int id);

        Task<IEnumerable<Plans>> GetAllAsync();

        Task AddAsync(Plans entity);

        void Update(Plans entity);

        void Delete(Plans entity);

        Task SaveChangesAsync();
    }
}
