using Core.DataTypes;
using Microsoft.AspNetCore.Http;
using Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Base.Command.FileUpload
{
    public interface IBaseServiceCommand<TFileModel>
        where TFileModel : FileRepositoryModel
    {
        Task<Result> Execute(
            Guid parentId,
            string culture,
            Guid userId,
            List<IFormFile> files,
            TFileModel model,
            Expression<Func<TFileModel, bool>> deleteFiles = null
        );
        Task<Guid> GetOrganizationIdByObjectId(Guid objectId);
    }
}
