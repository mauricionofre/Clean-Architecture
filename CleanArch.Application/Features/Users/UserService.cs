using CleanArch.Domain.Entities.Users;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace CleanArch.Application.Features.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly ILogger<UserService> _log;

        public UserService(ILogger<UserService> logger, IUserRepository userRepository)
        {
            _log = logger;
            _repository = userRepository;
        }

        public User GetById(int id)
        {
            _log.LogInformation($"Buscando usuario pelo id: {id}");

            User user = _repository.GetById(id);
            if (user == null)
                _log.LogDebug($"Não foi possivel encontrar o usuario com id: {id}");

            return user;
        }

        public IEnumerable<User> GetAll()
        {
            _log.LogInformation("Buscando todos os Usuários");

            return _repository.GetAll();
        }
    }
}