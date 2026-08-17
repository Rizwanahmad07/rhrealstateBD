using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate.Domain.Interfaces
{
    public interface IAmentiesRepository
    {
        Task<Amenties> GetByIdAsync(int id);

        Task<IEnumerable<Amenties>> GetAllAsync();

        Task AddAsync(Amenties entity);

        void Update(Amenties entity);

        void Delete(Amenties entity);

        Task SaveChangesAsync();
    }
}