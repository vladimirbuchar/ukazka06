using Core.Base.Dto;
using Model;
using System.Collections.Generic;

namespace Core.Base.Convertor
{
    public interface IBaseConvertor<Model, Create, ObjectĹist, Detail, Update> : IBaseConvertor<Model, Create, ObjectĹist, Detail>
        where Model : TableModel
        where Create : CreateDto
        where Update : UpdateDto
        where ObjectĹist : ListDto
        where Detail : DetailDto
    {
        Model ConvertToBussinessEntity(Update update, Model entity, string culture);
    }

    public interface IBaseConvertor<Model, Create, ObjectĹist, Detail> : IBaseConvertor
        where Model : TableModel
        where Create : CreateDto
        where ObjectĹist : ListDto
        where Detail : DetailDto
    {
        Model ConvertToBussinessEntity(Create create, string culture);
        HashSet<ObjectĹist> ConvertToWebModel(HashSet<Model> list, string culture);
        Detail ConvertToWebModel(Model detail, string culture);
    }

    public interface IBaseConvertor { }
}
