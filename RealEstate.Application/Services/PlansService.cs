using AutoMapper;
using RealEstate.Application.DTOs;
using RealEstate.Application.Interfaces;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate.Application.Services
{
    public class PlansService : IPlansService
    {
        private readonly IPlansRepository _repository;
        private readonly IMapper _mapper;

        public PlansService(IPlansRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PlansDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<PlansDto>>(entities);
        }

        public async Task<PlansDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<PlansDto>(entity);
        }

        public async Task<PlansDto> CreateAsync(CreatePlansDto createDto)
        {
            var entity = _mapper.Map<Plans>(createDto);
            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
            return _mapper.Map<PlansDto>(entity);
        }

        public async Task UpdateAsync(int id, UpdatePlansDto updateDto)
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
