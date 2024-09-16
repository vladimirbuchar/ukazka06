using Core.Base.Repository;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.Note;

namespace Repository.Note
{
    public class NoteRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<NoteDbo>(dbContext, memoryCache),
            INoteRepository
    { }
}
