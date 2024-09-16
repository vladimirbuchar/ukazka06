using Core.Base.Dto;
using Core.Base.Repository;
using Core.DataTypes;
using Model;
using System.Threading.Tasks;

namespace Core.Base.Validator
{
    public class BaseUpdateValidator<Model, Repository, Update>(Repository repository)
        : BaseValidator<Model, Repository>(repository),
            IBaseUpdateValidator<Model, Update>
        where Model : TableModel
        where Repository : IBaseRepository<Model>
        where Update : UpdateDto
    {
        /// <summary>
        /// check is object valid
        /// </summary>
        /// <param name="create"></param>
        /// <returns></returns>
        public virtual async Task<Result> IsValid(Update update)
        {
            return await Task.FromResult(new Result());
        }
    }
}
