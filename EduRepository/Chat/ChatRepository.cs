using Core.Base.Repository;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Model.Edu.Chat;

namespace Repository.Chat
{
    public class ChatRepository(EduDbContext dbContext, IMemoryCache memoryCache)
        : BaseRepository<ChatDbo>(dbContext, memoryCache),
            IChatRepository
    { }
}
