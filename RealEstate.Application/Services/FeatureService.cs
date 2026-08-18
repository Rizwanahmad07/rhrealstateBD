using AutoMapper;
using RealEstate.Application.DTOs;
using RealEstate.Application.Interfaces;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate.Application.Services
{
    public class FeatureService : IService<Feature, FeatureDto, CreateFeatureDto, UpdateFeatureDto>
    {
        private readonly IFeatureRepository _repository;
        private readonly IMapper _mapper;

        public FeatureService(IFeatureRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FeatureDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<FeatureDto>>(entities);
        }

        public async Task<FeatureDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<FeatureDto>(entity);
        }

        public async Task<FeatureDto> CreateAsync(CreateFeatureDto createDto)
        {
            var entity = _mapper.Map<Feature>(createDto);
            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
            return _mapper.Map<FeatureDto>(entity);
        }

        public async Task UpdateAsync(int id, UpdateFeatureDto updateDto)
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
