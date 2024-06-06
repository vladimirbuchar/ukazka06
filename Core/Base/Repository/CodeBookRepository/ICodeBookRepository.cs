using System.Collections.Generic;
using Model.Tables.CodeBook;

namespace Core.Base.Repository.CodeBookRepository
{
    public interface ICodeBookRepository<Model> : IBaseRepository<Model>
        where Model : CodeBook
    {
        HashSet<Model> GetCodeBookItems(System.Linq.Expressions.Expression<System.Func<Model, bool>> predicate = null);
    }
}
