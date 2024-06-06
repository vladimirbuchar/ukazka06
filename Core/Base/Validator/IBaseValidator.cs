using Core.Base.Dto;
using Core.Base.Repository;
using Core.DataTypes;
using Model;

namespace Core.Base.Validator
{
    public interface IBaseValidator<Model, Repository, Create, Detail, Update> : IBaseValidator<Model, Repository, Create, Detail>
        where Model : TableModel
        where Repository : IBaseRepository<Model>
        where Create : CreateDto
        where Update : UpdateDto
        where Detail : DetailDto
    {
        Result<Detail> IsValid(Update update);
    }

    public interface IBaseValidator<Model, Repository, Create, Detail> : IBaseValidator<Model, Repository>
        where Model : TableModel
        where Repository : IBaseRepository<Model>
        where Create : CreateDto
        where Detail : DetailDto
    {
        Result<Detail> IsValid(Create create);
    }

    public interface IBaseValidator<Model, Repository>
        where Model : TableModel
        where Repository : IBaseRepository<Model>
    {
        void IsValidString(string text, Result result, string category, string item);
        void IsValidString(string text, Result result, string category, string item, bool required);
        void IsValidEmail(string email, Result result, string category, string item);
        void IsValidUri(string uri, Result result, string category, string item);
        void IsValidPhoneNumber(string phoneNumber, Result result, string category, string item);
        void IsValidPostiveNumber(int number, Result result, string category, string item);
        void IsValidPostiveNumber(double number, Result result, string category, string item);
    }
}
