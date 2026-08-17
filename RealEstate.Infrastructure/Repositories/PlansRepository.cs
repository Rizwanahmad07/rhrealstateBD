using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Interfaces;
using RealEstate.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate.Infrastructure.Repositories
{
    public class PlansRepository : IPlansRepository
    {
        protected readonly ApplicationDbContext _context;

        public PlansRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Plans> GetByIdAsync(int id)
        {
            return await _context.Plans.FindAsync(id);
        }

        public async Task<IEnumerable<Plans>> GetAllAsync()
        {
            return await _context.Plans.ToListAsync();
        }

        public async Task AddAsync(Plans entity)
        {
            await _context.Plans.AddAsync(entity);
        }

        public void Update(Plans entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Plans entity)
        {
            _context.Plans.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
