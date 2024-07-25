using Core.Base.Dto;
using Core.Base.Repository;
using Core.Constants;
using Core.DataTypes;
using Core.Extension;
using Model;
using System;
using System.Threading.Tasks;

namespace Core.Base.Validator
{
    public class BaseValidator<Model, Repository, Create, Detail, Update>(Repository repository)
        : BaseValidator<Model, Repository, Create>(repository),
            IBaseValidatorCreate<Model, Repository, Create>
        where Model : TableModel
        where Repository : IBaseRepository<Model>
        where Create : CreateDto
        where Update : UpdateDto
        where Detail : DetailDto
    {
        /// <summary>
        /// check is object valid
        /// </summary>
        /// <param name="update"></param>
        /// <returns></returns>
        public virtual async Task<Result<Detail>> IsValid(Update update)
        {
            return await Task.FromResult(new Result<Detail>());
        }
    }

    public class BaseValidator<Model, Repository, Create>(Repository repository)
        : BaseValidator<Model, Repository>(repository),
            IBaseValidatorCreate<Model, Repository, Create>
        where Model : TableModel
        where Repository : IBaseRepository<Model>
        where Create : CreateDto

    {
        /// <summary>
        /// check is object valid
        /// </summary>
        /// <param name="create"></param>
        /// <returns></returns>
        public virtual async Task<Result> IsValid(Create create)
        {
            return await Task.FromResult(new Result());
        }
    }

    public class BaseValidatorUpdate<Model, Repository, Update, Detail>(Repository repository)
        : BaseValidator<Model, Repository>(repository),
            IBaseValidatorUpdate<Model, Repository, Update, Detail>
        where Model : TableModel
        where Repository : IBaseRepository<Model>
        where Update : UpdateDto
        where Detail : DetailDto
    {
        /// <summary>
        /// check is object valid
        /// </summary>
        /// <param name="create"></param>
        /// <returns></returns>
        public virtual async Task<Result<Detail>> IsValid(Update update)
        {
            return await Task.FromResult(new Result<Detail>());
        }
    }

    public class BaseValidator()
    {
        /// <summary>
        /// is valid string
        /// </summary>
        /// <param name="text"></param>
        /// <param name="result"></param>
        /// <param name="category"></param>
        /// <param name="item"></param>
        public void IsValidString(string text, Result result, string category, string item)
        {
            if (text.IsNullOrEmptyWithTrim())
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, category, item));
            }
        }
    }

    public class BaseValidator<Model, Repository>(Repository repository) : BaseValidator, IBaseValidator<Model, Repository>
        where Model : TableModel
        where Repository : IBaseRepository<Model>
    {
        protected Repository _repository = repository;



        /// <summary>
        /// check is valid email
        /// </summary>
        /// <param name="email"></param>
        /// <param name="result"></param>
        /// <param name="category"></param>
        /// <param name="item"></param>

        public void IsValidEmail(string email, Result result, string category, string item)
        {
            if (!email.IsNullOrEmptyWithTrim())
            {
                if (!email.IsValidEmail())
                {
                    result.AddResultStatus(new ValidationMessage(MessageType.ERROR, category, item, email));
                }
            }
        }

        /// <summary>
        /// check is valid URL
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="result"></param>
        /// <param name="category"></param>
        /// <param name="item"></param>
        public void IsValidUri(string uri, Result result, string category, string item)
        {
            if (!uri.IsNullOrEmptyWithTrim())
            {
                if (!uri.IsValidUri())
                {
                    result.AddResultStatus(new ValidationMessage(MessageType.ERROR, category, item, uri));
                }
            }
        }

        /// <summary>
        /// check is valid phone number
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="result"></param>
        /// <param name="category"></param>
        /// <param name="item"></param>
        public void IsValidPhoneNumber(string phoneNumber, Result result, string category, string item)
        {
            if (!phoneNumber.IsNullOrEmptyWithTrim())
            {
                if (!phoneNumber.IsValidPhoneNumber())
                {
                    result.AddResultStatus(new ValidationMessage(MessageType.ERROR, category, item, phoneNumber));
                }
            }
        }

        /// <summary>
        /// check is valid string
        /// </summary>
        /// <param name="text"></param>
        /// <param name="result"></param>
        /// <param name="category"></param>
        /// <param name="item"></param>
        /// <param name="required"></param>
        public void IsValidString(string text, Result result, string category, string item, bool required)
        {
            if (text.IsNullOrEmptyWithTrim() && required)
            {
                IsValidString(text, result, category, item);
            }
        }

        /// <summary>
        /// check is positive number
        /// </summary>
        /// <param name="number"></param>
        /// <param name="result"></param>
        /// <param name="category"></param>
        /// <param name="item"></param>
        public void IsValidPostiveNumber(int number, Result result, string category, string item)
        {
            if (number < 0)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, category, item, number.ToString()));
            }
        }

        /// <summary>
        /// check is positive number
        /// </summary>
        /// <param name="number"></param>
        /// <param name="result"></param>
        /// <param name="category"></param>
        /// <param name="item"></param>

        public void IsValidPostiveNumber(double number, Result result, string category, string item)
        {
            if (number < 0)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, category, item, number.ToString()));
            }
        }

        /// <summary>
        /// check is item exist
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="result"></param>
        /// <param name="category"></param>
        /// <param name="item"></param>
        /// <param name="value"></param>
        protected virtual async Task IsExist(
            System.Linq.Expressions.Expression<Func<Model, bool>> predicate,
            Result result,
            string category,
            string item,
            string value = ""
        )
        {
            if ((await _repository.GetEntity(false, predicate)) != null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, category, item, value));
            }
            if ((await _repository.GetEntity(true, predicate)) != null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, category, item, value));
            }
        }

        /// <summary>
        /// check is code book value exist
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="codeBookData"></param>
        /// <param name="predicate"></param>
        /// <param name="result"></param>
        /// <param name="category"></param>
        /// <param name="item"></param>
        /// <param name="value"></param>
        protected virtual async Task CodeBookValueExist<T>(
            IBaseRepository<T> codeBookData,
            System.Linq.Expressions.Expression<Func<T, bool>> predicate,
            Result result,
            string category,
            string item,
            string value = ""
        )
            where T : TableModel
        {
            T codeBook = await codeBookData.GetEntity(false, predicate);
            if (codeBook == null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, category, item, value));
            }
            else if (codeBook.SystemIdentificator == CodebookValue.CODEBOOK_SELECT_VALUE)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, category, item, value));
            }


        }
    }
}
