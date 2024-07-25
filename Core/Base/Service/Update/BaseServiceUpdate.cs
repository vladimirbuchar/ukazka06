using Core.Base.Convertor;
using Core.Base.Dto;
using Core.Base.Repository;
using Core.Base.Validator;
using Core.DataTypes;
using Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Base.Service.Update
{
    public abstract class BaseServiceUpdate<Model, Repository, Update, Detail, Convertor, Validator> : IBaseServiceUpdate<Model, Update, Detail>
       where Update : UpdateDto
       where Detail : DetailDto
       where Model : TableModel
       where Convertor : IBaseConvertorUpdate<Model, Update>
       where Validator : IBaseValidatorUpdate<Model, Repository, Update, Detail>
       where Repository : IBaseRepository<Model>
    {
        private readonly Repository _repository;
        private readonly Validator _validator;
        private readonly Convertor _convertor;
        public BaseServiceUpdate(Repository repository, Convertor convertor, Validator validator)
        {
            _repository = repository;
            _validator = validator;
            _convertor = convertor;

        }
        /// <summary>
        /// update object
        /// </summary>
        /// <param name="update"></param>
        /// <param name="userId"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public virtual async Task<Result<Detail>> Execute(Update update, Guid userId, string culture, Result<Detail> result = null)
        {
            Model oldEntity = await _repository.GetEntity(update.Id) ?? throw new KeyNotFoundException(update.Id.ToString());
            result ??= await _validator.IsValid(update);
            if (result.IsOk)
            {
                Model entity = await _convertor.ConvertToBussinessEntity(update, oldEntity, culture);
                if (IsChanged(await _repository.GetEntity(update.Id), update, culture))
                {
                    _ = await _repository.UpdateEntity(entity, userId);
                    result.DataChanged = true;
                }
            }
            return result;
        }

        /// <summary>
        /// test that is object change
        /// </summary>
        /// <param name="oldVersion"></param>
        /// <param name="newVersion"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        protected virtual bool IsChanged(Model oldVersion, Update newVersion, string culture)
        {
            return true;
        }
    }


}
