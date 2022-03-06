using System;
using System.Collections.Generic;
using Usuarios.Entities;

namespace Usuarios.Repositories
{
  public interface IUsersRepository
  {
    User GetUser(System.Guid Id);
    IEnumerable<User> GetUsers();
    void CreateUser(User user);
    void UpdateUser(User user);
    void DeleteUser(Guid Id);
  }
}