using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Helpers;
using Core.Base.Dto;
using Core.Base.Filter;
using Core.Base.Paging;
using Core.DataTypes;
using Microsoft.AspNetCore.Http;
using Model;

namespace Core.Base.Service
{
    public interface IBaseService<Model, Create, ObjectList, Detail, Update, FileModel, Filter>
        : IBaseService<Model, Create, ObjectList, Detail, Update, Filter>
        where Create : CreateDto
        where Update : UpdateDto
        where ObjectList : ListDto
        where Detail : DetailDto
        where Model : TableModel
        where FileModel : FileRepositoryModel
        where Filter : FilterRequest
    {
        Result FileUpload(
            Guid parentId,
            string culture,
            Guid userId,
            List<IFormFile> files,
            FileModel model,
            Expression<Func<FileModel, bool>> deleteFiles = null
        );
        Result FileDelete(Guid id, Guid userId);
    }

    public interface IBaseService<Model, Create, ObjectList, Detail, Update, Filter> : IBaseService<Model, Create, ObjectList, Detail, Filter>
        where Create : CreateDto
        where Update : UpdateDto
        where ObjectList : ListDto
        where Detail : DetailDto
        where Model : TableModel
        where Filter : FilterRequest
    {
        Result<Detail> UpdateObject(Update update, Guid userId, string culture, Result<Detail> result = null);
    }

    public interface IBaseService<Model, Create, ObjectList, Detail, Filter> : IBaseService
        where Create : CreateDto
        where ObjectList : ListDto
        where Detail : DetailDto
        where Model : TableModel
        where Filter : FilterRequest
    {
        Result<Detail> AddObject(Create addObject, Guid userId, string culture);
        Result DeleteObject(Guid objectId, Guid userId);
        Result MultipleDelete(Expression<Func<Model, bool>> predicate, Guid userId);
        List<ObjectList> GetList(
            Expression<Func<Model, bool>> predicate = null,
            bool deleted = false,
            string culture = "",
            Filter filter = null,
            string sortColumn = "",
            SortDirection sortDirection = SortDirection.Ascending,
            BasePaging paging = null
        );
        List<ObjectList> GetList();
        List<ObjectList> GetList(string culture = "", Filter filter = null);
        List<ObjectList> GetList(bool deleted = false, string culture = "");
        Detail GetDetail(Guid objectId, string culture);
        Detail GetDetail(Expression<Func<Model, bool>> predicate, string culture);
        Result RestoreObject(Guid objectId, Guid userId);
    }

    public interface IBaseService
    {
        Guid GetOrganizationIdByObjectId(Guid objectId);
        Guid GetOrganizationIdByParentId(Guid objectId);
    }
}
