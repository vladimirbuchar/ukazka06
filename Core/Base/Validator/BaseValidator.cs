using System;
using Core.Base.Dto;
using Core.Base.Repository;
using Core.DataTypes;
using Core.Extension;
using Model;

namespace Core.Base.Validator
{
    public class BaseValidator<Model, Repository, Create, Detail, Update>(Repository repository)
        : BaseValidator<Model, Repository, Create, Detail>(repository),
            IBaseValidator<Model, Repository, Create, Detail>
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
        public virtual Result<Detail> IsValid(Update update)
        {
            return new Result<Detail>();
        }
    }

    public class BaseValidator<Model, Repository, Create, Detail>(Repository repository) : BaseValidator<Model, Repository>(repository), IBaseValidator<Model, Repository, Create, Detail>
        where Model : TableModel
        where Repository : IBaseRepository<Model>
        where Create : CreateDto
        where Detail : DetailDto
    {
        /// <summary>
        /// check is object valid
        /// </summary>
        /// <param name="create"></param>
        /// <returns></returns>
        public virtual Result<Detail> IsValid(Create create)
        {
            return new Result<Detail>();
        }
    }

    public class BaseValidator<Model, Repository>(Repository repository) : IBaseValidator<Model, Repository>
        where Model : TableModel
        where Repository : IBaseRepository<Model>
    {
        protected Repository _repository = repository;

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
        protected virtual void IsExist(System.Linq.Expressions.Expression<Func<Model, bool>> predicate, Result result, string category, string item, string value = "")
        {
            if (_repository.GetEntities(false, predicate)?.Count > 0)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, category, item, value));
            }
            if (_repository.GetEntities(true, predicate)?.Count > 0)
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
        protected virtual void CodeBookValueExist<T>(
            IBaseRepository<T> codeBookData,
            System.Linq.Expressions.Expression<Func<T, bool>> predicate,
            Result result,
            string category,
            string item,
            string value = ""
        )
            where T : TableModel
        {
            if (codeBookData.GetEntities(false, predicate).Count == 0)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, category, item, value));
            }
        }
    }
}
