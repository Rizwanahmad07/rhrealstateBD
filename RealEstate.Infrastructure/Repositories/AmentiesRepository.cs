using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Interfaces;
using RealEstate.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate.Infrastructure.Repositories
{
    public class AmentiesRepository : IAmentiesRepository
    {
        protected readonly ApplicationDbContext _context;

        public AmentiesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Amenties> GetByIdAsync(int id)
        {
            return await _context.Amenties.FindAsync(id);
        }

        public async Task<IEnumerable<Amenties>> GetAllAsync()
        {
            return await _context.Amenties.ToListAsync();
        }

        public async Task AddAsync(Amenties entity)
        {
            await _context.Amenties.AddAsync(entity);
        }

        public void Update(Amenties entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Amenties entity)
        {
            _context.Amenties.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
    }