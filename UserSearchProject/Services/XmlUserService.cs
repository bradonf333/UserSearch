﻿using UserSearchProject.Data;
using UserSearchProject.Db;

namespace UserSearchProject.Services
{
    public class XmlUserService : IUserService
    {
        private IDbRepository _dbRepository;

        public XmlUserService(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public IEnumerable<User> GetUsers()
        {
            return _dbRepository.GetUsers();
        }
    }
}
