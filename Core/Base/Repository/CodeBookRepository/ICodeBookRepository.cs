using Model;

namespace Core.Base.Repository.CodeBookRepository
{
    public interface ICodeBookRepository<Model> : IBaseRepository<Model>
        where Model : CodeBookModel
    { }
}
