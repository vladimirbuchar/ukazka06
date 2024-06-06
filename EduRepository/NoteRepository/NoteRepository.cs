using Core.Base.Repository;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Tables.Edu.Note;

namespace EduRepository.NoteRepository
{
    public class NoteRepository(EduDbContext dbContext, IMemoryCache memoryCache) : BaseRepository<NoteDbo>(dbContext, memoryCache), INoteRepository { }
}
