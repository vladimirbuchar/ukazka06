using System.Collections.Generic;
using Core.Base.Dto;
using Model;

namespace Core.Base.Convertor
{
    public interface IBaseConvertor<Model, Create, ObjectList, Detail, Update> : IBaseConvertor<Model, Create, ObjectList, Detail>
        where Model : TableModel
        where Create : CreateDto
        where Update : UpdateDto
        where ObjectList : ListDto
        where Detail : DetailDto
    {
        Model ConvertToBussinessEntity(Update update, Model entity, string culture);
    }

    public interface IBaseConvertor<Model, Create, ObjectList, Detail> : IBaseConvertor
        where Model : TableModel
        where Create : CreateDto
        where ObjectList : ListDto
        where Detail : DetailDto
    {
        Model ConvertToBussinessEntity(Create create, string culture);
        List<ObjectList> ConvertToWebModel(List<Model> list, string culture);
        Detail ConvertToWebModel(Model detail, string culture);
    }

    public interface IBaseConvertor { }
}
