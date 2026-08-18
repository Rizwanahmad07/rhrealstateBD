using Amazon.DynamoDBv2.DataModel;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Interfaces;
using RealEstate.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        protected readonly IDynamoDBContext _dynamoDbContext;
        protected readonly IDynamoDbIdGenerator _idGenerator;

        public ProjectRepository(IDynamoDBContext dynamoDbContext, IDynamoDbIdGenerator idGenerator)
        {
            _dynamoDbContext = dynamoDbContext;
            _idGenerator = idGenerator;
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            return await _dynamoDbContext.LoadAsync<Project>(id);
        }

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            return await _dynamoDbContext.ScanAsync<Project>(new List<ScanCondition>()).GetRemainingAsync();
        }

        public async Task AddAsync(Project entity)
        {
            entity.Id = await _idGenerator.GetNextIdAsync("Projects");
            await _dynamoDbContext.SaveAsync(entity);
        }

        public void Update(Project entity)
        {
            // We'll save it immediately since DynamoDB doesn't track changes
            _dynamoDbContext.SaveAsync(entity).Wait();
        }

        public void Delete(Project entity)
        {
            _dynamoDbContext.DeleteAsync(entity).Wait();
        }

        public async Task SaveChangesAsync()
        {
            // DynamoDB operations are executed immediately, so this is a no-op
            await Task.CompletedTask;
        }
    }
}
