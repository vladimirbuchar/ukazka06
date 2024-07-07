using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.CodeBook;

namespace Core.Base.Repository.CodeBookRepository
{
    public class CodeBookRepository<Model>(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<Model>(dbContext, memoryCache), ICodeBookRepository<Model>
        where Model : CodeBook { }
}
