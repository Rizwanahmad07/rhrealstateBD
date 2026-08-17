using AutoMapper;
using RealEstate.Application.DTOs;
using RealEstate.Application.Interfaces;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate.Application.Services
{
    public class AmentiesService : IAmentiesService
    {
        private readonly IAmentiesRepository _repository;
        private readonly IMapper _mapper;

        public AmentiesService(IAmentiesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AmentiesDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<AmentiesDto>>(entities);
        }

        public async Task<AmentiesDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<AmentiesDto>(entity);
        }

        public async Task<AmentiesDto> CreateAsync(CreateAmentiesDto createDto)
        {
            var entity = _mapper.Map<Amenties>(createDto);
            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
            return _mapper.Map<AmentiesDto>(entity);
        }

        public async Task UpdateAsync(int id, UpdateAmentiesDto updateDto)
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