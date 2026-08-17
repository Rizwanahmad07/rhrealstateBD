using System.Collections.Generic;
using System.Threading.Tasks;
using RealEstate.Domain.Entities;

namespace RealEstate.Domain.Interfaces
{
    public interface IProjectRepository
    {
        Task<Project> GetByIdAsync(int id);

        Task<IEnumerable<Project>> GetAllAsync();

        Task AddAsync(Project entity);

        void Update(Project entity);

        void Delete(Project entity);

        Task SaveChangesAsync();
    }
}
