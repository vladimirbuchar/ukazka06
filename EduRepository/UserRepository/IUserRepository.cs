﻿using Core.Base.Repository;
using Model.Tables.Edu.User;

namespace EduRepository.UserRepository
{
    public interface IUserRepository : IBaseRepository<UserDbo>
    {
        UserDbo LoginUser(string email, string password);

    }
}
