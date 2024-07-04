using Core.Base.Dto;
using Core.DataTypes;
using Microsoft.AspNetCore.Http;
using Model;
using System;
using System.Collections.Generic;

namespace Core.Base.Service
{
    public interface IBaseService<Model, Create, ObjectĹist, Detail, Update, FileModel> : IBaseService<Model, Create, ObjectĹist, Detail, Update>
        where Create : CreateDto
        where Update : UpdateDto
        where ObjectĹist : ListDto
        where Detail : DetailDto
        where Model : TableModel
    {
        Result FileUpload(Guid parentId, string culture, Guid userId, List<IFormFile> files, FileModel model, System.Linq.Expressions.Expression<Func<FileModel, bool>> deleteFiles = null);
        Result FileDelete(Guid id, Guid userId);
    }

    public interface IBaseService<Model, Create, ObjectĹist, Detail, Update> : IBaseService<Model, Create, ObjectĹist, Detail>
        where Create : CreateDto
        where Update : UpdateDto
        where ObjectĹist : ListDto
        where Detail : DetailDto
        where Model : TableModel
    {
        Result<Detail> UpdateObject(Update update, Guid userId, string culture, Result<Detail> result = null);
    }

    public interface IBaseService<Model, Create, ObjectĹist, Detail> : IBaseService
        where Create : CreateDto
        where ObjectĹist : ListDto
        where Detail : DetailDto
        where Model : TableModel
    {
        Result<Detail> AddObject(Create addObject, Guid userId, string culture);
        Result DeleteObject(Guid objectId, Guid userId);
        Result MultipleDelete(System.Linq.Expressions.Expression<Func<Model, bool>> predicate, Guid userId);
        HashSet<ObjectĹist> GetList(System.Linq.Expressions.Expression<Func<Model, bool>> predicate = null, bool deleted = false, string culture = "");
        Detail GetDetail(Guid objectId, string culture);
        Detail GetDetail(System.Linq.Expressions.Expression<Func<Model, bool>> predicate, string culture);
        Result RestoreObject(Guid objectId, Guid userId);
    }

    public interface IBaseService
    {
        Guid GetOrganizationIdByObjectId(Guid objectId);
    }
}
