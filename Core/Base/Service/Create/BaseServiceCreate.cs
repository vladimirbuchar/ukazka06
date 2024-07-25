using Core.Base.Convertor;
using Core.Base.Dto;
using Core.Base.Repository;
using Core.Base.Validator;
using Core.DataTypes;
using Model;
using System;
using System.Threading.Tasks;

namespace Core.Base.Service.Create
{
    public abstract class BaseServiceCreate<Model, Repository, Create, Convertor, Validator> : BaseServiceNew, IBaseServiceCreate<Model, Create>
        where Create : CreateDto
        where Model : TableModel
        where Convertor : IBaseConvertorCreate<Model, Create>
        where Validator : IBaseValidatorCreate<Model, Repository, Create>
        where Repository : IBaseRepository<Model>
    {
        protected readonly Repository _repository;
        protected readonly Validator _validator;
        protected readonly Convertor _convertor;
        public BaseServiceCreate(Repository repository, Convertor convertor, Validator validator)
        {
            _repository = repository;
            _validator = validator;
            _convertor = convertor;

        }
        public virtual async Task<Result> Execute(Create addObject, Guid userId, string culture)
        {
            Result result = await _validator.IsValid(addObject);
            if (result.IsOk)
            {
                Model entity = await _convertor.ConvertToBussinessEntity(addObject, culture);
                _ = await _repository.CreateEntity(entity, userId);
            }
            return result;
        }
    }


}
