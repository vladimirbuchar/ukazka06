using System;
using Core.Base.Repository;
using Model.Tables.Edu.LinkLifeTime;

namespace EduRepository.LinkLifeTimeRepository
{
    public interface ILinkLifeTimeRepository : IBaseRepository<LinkLifeTimeDbo>
    {
        LinkLifeTimeDbo GetLinkWithUser(Guid id);
    }
}
