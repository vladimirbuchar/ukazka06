using Core.Base.Dto;
using Core.Base.Filter;
using Core.Base.Paging;
using Core.DataTypes;
using Microsoft.AspNetCore.Http;
using Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Helpers;

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
        Task<Result> FileUpload(
            Guid parentId,
            string culture,
            Guid userId,
            List<IFormFile> files,
            FileModel model,
            Expression<Func<FileModel, bool>> deleteFiles = null
        );
        Task<Result> FileDelete(Guid id, Guid userId);
    }
   
    public interface IBaseService<Model, Create, ObjectList, Detail, Update, Filter> : IBaseService<Model, Create, ObjectList, Detail, Filter>
        where Create : CreateDto
        where Update : UpdateDto
        where ObjectList : ListDto
        where Detail : DetailDto
        where Model : TableModel
        where Filter : FilterRequest
    {
        Task<Result<Detail>> UpdateObject(Update update, Guid userId, string culture, Result<Detail> result = null);
    }
   
    public interface IBaseService<Model, Create, ObjectList, Detail, Filter> : IBaseService
        where Create : CreateDto
        where ObjectList : ListDto
        where Detail : DetailDto
        where Model : TableModel
        where Filter : FilterRequest
    {
        Task<Result> AddObject(Create addObject, Guid userId, string culture);
        Task<Result> DeleteObject(Guid objectId, Guid userId);
        Task<Result> MultipleDelete(Expression<Func<Model, bool>> predicate, Guid userId);
        Task<ResultTable<ObjectList>> GetList(
            Expression<Func<Model, bool>> predicate = null,
            bool deleted = false,
            string culture = "",
            Filter filter = null,
            string sortColumn = "",
            SortDirection sortDirection = SortDirection.Ascending,
            BasePaging paging = null
        );
        Task<ResultTable<ObjectList>> GetList();
        Task<ResultTable<ObjectList>> GetList(string culture = "", Filter filter = null);
        Task<ResultTable<ObjectList>> GetList(bool deleted = false, string culture = "");
        Task<Detail> GetDetail(Guid objectId, string culture);
        Task<Detail> GetDetail(Expression<Func<Model, bool>> predicate, string culture);
        Task<Result> RestoreObject(Guid objectId, Guid userId);
    }
   
    public interface IBaseService
    {
        Task<Guid> GetOrganizationIdByObjectId(Guid objectId);
        Task<Guid> GetOrganizationIdByParentId(Guid objectId);
        Task<Guid> GetOrganizationIdBFileId(Guid objectId);
    }
}
