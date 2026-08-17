using AutoMapper;
using RealEstate.Application.DTOs;
using RealEstate.Application.Interfaces;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repository;
        private readonly IMapper _mapper;

        public ProjectService(IProjectRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProjectDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProjectDto>>(entities);
        }

        public async Task<ProjectDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<ProjectDto>(entity);
        }

        public async Task<ProjectDto> CreateAsync(CreateProjectDto createDto)
        {
            var entity = _mapper.Map<Project>(createDto);
            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
            return _mapper.Map<ProjectDto>(entity);
        }

        public async Task UpdateAsync(int id, UpdateProjectDto updateDto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return;

            _mapper.Map(updateDto, entity);
            _repository.Update(entity);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return;

            _repository.Delete(entity);
            await _repository.SaveChangesAsync();
        }
    }
}
