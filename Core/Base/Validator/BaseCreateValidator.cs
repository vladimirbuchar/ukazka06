using Core.Base.Dto;
using Core.Base.Repository;
using Core.DataTypes;
using Model;
using System.Threading.Tasks;

namespace Core.Base.Validator
{
    public class BaseCreateValidator<Model, Repository, Create>(Repository repository)
        : BaseValidator<Model, Repository>(repository),
            IBaseCreateValidator<Model, Create>
        where Model : TableModel
        where Repository : IBaseRepository<Model>
        where Create : CreateDto
    {
        /// <summary>
        /// check is object valid
        /// </summary>
        /// <param name="create"></param>
        /// <returns></returns>
        public virtual async Task<ResultInsert> IsValid(Create create)
        {
            return await Task.FromResult(new ResultInsert());
        }
    }
}
