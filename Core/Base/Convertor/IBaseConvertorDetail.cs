using Core.Base.Dto;
using Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Base.Convertor
{
   
    public interface IBaseConvertor<Model, Create, ObjectList, Detail, Update> : IBaseConvertor<Model, Create, ObjectList, Detail>
        where Model : TableModel
        where Create : CreateDto
        where Update : UpdateDto
        where ObjectList : ListDto
        where Detail : DetailDto
    {
        Task<Model> ConvertToBussinessEntity(Update update, Model entity, string culture);
    }
   
    public interface IBaseConvertor<Model, Create, ObjectList, Detail> : IBaseConvertor
        where Model : TableModel
        where Create : CreateDto
        where ObjectList : ListDto
        where Detail : DetailDto
    {
        Task<Model> ConvertToBussinessEntity(Create create, string culture);
        Task<List<ObjectList>> ConvertToWebModel(List<Model> list, string culture);
        Task<Detail> ConvertToWebModel(Model detail, string culture);
    }

    public interface IBaseConvertorList<Model, ObjectList> : IBaseConvertor
       where Model : TableModel
       where ObjectList : ListDto

    {
        Task<List<ObjectList>> ConvertToWebModel(List<Model> list, string culture);

    }


    public interface IBaseConvertorCreate<Model, Create> : IBaseConvertor
        where Model : TableModel
        where Create : CreateDto
    {
        Task<Model> ConvertToBussinessEntity(Create create, string culture);
    }

    public interface IBaseConvertorUpdate<Model, Update> : IBaseConvertor
        where Model : TableModel
        where Update : UpdateDto
    {
        Task<Model> ConvertToBussinessEntity(Update update, Model entity, string culture);
    }


    public interface IBaseConvertorDetail<Model, Detail> : IBaseConvertor
        where Model : TableModel
        where Detail : DetailDto
    {

        Task<Detail> ConvertToWebModel(Model detail, string culture);
    }

    public interface IBaseConvertor { }
}
