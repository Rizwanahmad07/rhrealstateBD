using Amazon.DynamoDBv2.DataModel;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Interfaces;
using RealEstate.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate.Infrastructure.Repositories
{
    public class FeatureRepository : IFeatureRepository
    {
        protected readonly IDynamoDBContext _dynamoDbContext;
        protected readonly IDynamoDbIdGenerator _idGenerator;

        public FeatureRepository(IDynamoDBContext dynamoDbContext, IDynamoDbIdGenerator idGenerator)
        {
            _dynamoDbContext = dynamoDbContext;
            _idGenerator = idGenerator;
        }

        public async Task<Feature> GetByIdAsync(int id)
        {
            return await _dynamoDbContext.LoadAsync<Feature>(id);
        }

        public async Task<IEnumerable<Feature>> GetAllAsync()
        {
            return await _dynamoDbContext.ScanAsync<Feature>(new List<ScanCondition>()).GetRemainingAsync();
        }

        public async Task AddAsync(Feature entity)
        {
            entity.Id = await _idGenerator.GetNextIdAsync("Feature");
            await _dynamoDbContext.SaveAsync(entity);
        }

        public void Update(Feature entity)
        {
            _dynamoDbContext.SaveAsync(entity).Wait();
        }

        public void Delete(Feature entity)
        {
            _dynamoDbContext.DeleteAsync(entity).Wait();
        }

        public async Task SaveChangesAsync()
        {
            await Task.CompletedTask;
        }
    }
}
