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
        private readonly IS3Service _s3Service;

        public ProjectService(IProjectRepository repository, IMapper mapper, IS3Service s3Service)
        {
            _repository = repository;
            _mapper = mapper;
            _s3Service = s3Service;
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
            createDto.Logo = await _s3Service.UploadBase64ImageAsync(createDto.Logo);
            createDto.BannerImage = await _s3Service.UploadBase64ImageAsync(createDto.BannerImage);
            createDto.OverviewImage = await _s3Service.UploadBase64ImageAsync(createDto.OverviewImage);

            var entity = _mapper.Map<Project>(createDto);
            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
            return _mapper.Map<ProjectDto>(entity);
        }

        public async Task UpdateAsync(int id, UpdateProjectDto updateDto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return;

            updateDto.Logo = await _s3Service.UploadBase64ImageAsync(updateDto.Logo);
            updateDto.BannerImage = await _s3Service.UploadBase64ImageAsync(updateDto.BannerImage);
            updateDto.OverviewImage = await _s3Service.UploadBase64ImageAsync(updateDto.OverviewImage);

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
