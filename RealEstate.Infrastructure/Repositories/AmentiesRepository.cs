using Amazon.DynamoDBv2.DataModel;
using RealEstate.Domain.Interfaces;
using RealEstate.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate.Infrastructure.Repositories
{
    public class AmentiesRepository : IAmentiesRepository
    {
        protected readonly IDynamoDBContext _dynamoDbContext;
        protected readonly IDynamoDbIdGenerator _idGenerator;

        public AmentiesRepository(IDynamoDBContext dynamoDbContext, IDynamoDbIdGenerator idGenerator)
        {
            _dynamoDbContext = dynamoDbContext;
            _idGenerator = idGenerator;
        }

        public async Task<Amenties> GetByIdAsync(int id)
        {
            return await _dynamoDbContext.LoadAsync<Amenties>(id);
        }

        public async Task<IEnumerable<Amenties>> GetAllAsync()
        {
            return await _dynamoDbContext.ScanAsync<Amenties>(new List<ScanCondition>()).GetRemainingAsync();
        }

        public async Task AddAsync(Amenties entity)
        {
            entity.Id = await _idGenerator.GetNextIdAsync("Amenties");
            await _dynamoDbContext.SaveAsync(entity);
        }

        public void Update(Amenties entity)
        {
            _dynamoDbContext.SaveAsync(entity).Wait();
        }

        public void Delete(Amenties entity)
        {
            _dynamoDbContext.DeleteAsync(entity).Wait();
        }

        public async Task SaveChangesAsync()
        {
            await Task.CompletedTask;
        }
    }
    }