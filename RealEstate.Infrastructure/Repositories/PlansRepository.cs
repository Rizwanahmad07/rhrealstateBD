using Amazon.DynamoDBv2.DataModel;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Interfaces;
using RealEstate.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate.Infrastructure.Repositories
{
    public class PlansRepository : IPlansRepository
    {
        protected readonly IDynamoDBContext _dynamoDbContext;
        protected readonly IDynamoDbIdGenerator _idGenerator;

        public PlansRepository(IDynamoDBContext dynamoDbContext, IDynamoDbIdGenerator idGenerator)
        {
            _dynamoDbContext = dynamoDbContext;
            _idGenerator = idGenerator;
        }

        public async Task<Plans> GetByIdAsync(int id)
        {
            return await _dynamoDbContext.LoadAsync<Plans>(id);
        }

        public async Task<IEnumerable<Plans>> GetAllAsync()
        {
            return await _dynamoDbContext.ScanAsync<Plans>(new List<ScanCondition>()).GetRemainingAsync();
        }

        public async Task AddAsync(Plans entity)
        {
            entity.Id = await _idGenerator.GetNextIdAsync("Plans");
            await _dynamoDbContext.SaveAsync(entity);
        }

        public void Update(Plans entity)
        {
            _dynamoDbContext.SaveAsync(entity).Wait();
        }

        public void Delete(Plans entity)
        {
            _dynamoDbContext.DeleteAsync(entity).Wait();
        }

        public async Task SaveChangesAsync()
        {
            await Task.CompletedTask;
        }
    }
}
