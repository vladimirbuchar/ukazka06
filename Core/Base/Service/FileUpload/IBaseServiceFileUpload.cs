using Core.DataTypes;
using Microsoft.AspNetCore.Http;
using Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Base.Service.FileUpload
{
    public interface IBaseServiceFileUpload<FileModel>
        where FileModel : FileRepositoryModel

    {
        Task<Result> Execute(
         Guid parentId,
         string culture,
         Guid userId,
         List<IFormFile> files,
         FileModel model,
         Expression<Func<FileModel, bool>> deleteFiles = null
     );
        Task<Result> Execute(Guid id, Guid userId);
    }

}
