using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WalletApp.BLL.Interfaces.Base;
using WalletApp.DAL.Base;
using WalletApp.DAL.Base.Interfaces;
using WalletApp.DTO.Dto.Requests;

namespace WalletApp.BLL.Services.Base
{
    public class BaseService<TDto, TModel, TKey> : ControllerBase, IBaseService<TDto, TKey>
        where TModel : class
    {
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork { get; set; }
        private readonly BaseRepository<TModel, TKey> _repository;
        public BaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository =
                    (_unitOfWork.GetType()
                    .GetProperties()
                    .Where(s => s.PropertyType.Equals(typeof(BaseRepository<TModel, TKey>)))
                    .First()
                    .GetValue(_unitOfWork)! as BaseRepository<TModel, TKey>)!;
        }

        //[Authorize]
        [HttpPost]
        [Route("[action]")]
        public virtual async Task Create(TDto dto)
        {
            await _repository.Create(_mapper.Map<TDto, TModel>(dto));
            await _unitOfWork.SaveAsync();
        }

        //[Authorize]
        [HttpPost]
        [Route("[action]")]
        public virtual List<TDto> GetAll(GetAllRequestDto request)
        {

            var models = _repository
                .GetAll(request.filter)
                .ToList();

            return _mapper.Map<List<TModel>, List<TDto>>(models);
        }

        //[Authorize]
        [HttpPost]
        [Route("[action]")]
        public virtual async Task<TDto> GetById(GetByIdRequestDto<TKey> request)
        {
            var model = await _repository.GetByIdAsync(request.Id, request.Filter);
            return _mapper.Map<TModel, TDto>(model);
        }
        
        //[Authorize]
        [HttpPut]
        [Route("[action]")]
        public async virtual Task Update(TDto dtoToUpdate)
        {
            _repository.Update(_mapper.Map<TDto, TModel>(dtoToUpdate));
            await _unitOfWork.SaveAsync();
        }

        //[Authorize]
        [HttpDelete]
        [Route("[action]")]
        public async Task DeleteAsync(TKey id)
        {
            await _repository.Delete(id);
            await _unitOfWork.SaveAsync();
        }
    }
}
