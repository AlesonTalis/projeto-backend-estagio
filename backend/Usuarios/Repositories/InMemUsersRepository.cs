using System;
using System.Collections.Generic;
using System.Linq;
using Usuarios.Entities;

namespace Usuarios.Repositories
{
  public class InMemUsersRepository : IUsersRepository
  {
    private readonly List<User> users = new List<User>()
    {
      new User {
        Id = Guid.NewGuid(),
        UserName = "UsuarioTeste01",
        UserPassword = "Usu@rioP@ss01_",
        UserFullName = "Usuario Teste 01",
        UserEmail = "usuario01@teste",
        UserCreatedDate = DateTimeOffset.UtcNow
      },
      new User {
        Id = Guid.NewGuid(),
        UserName = "UsuarioTeste02",
        UserPassword = "Usu@rioP@ss02_",
        UserFullName = "Usuario Teste 02",
        UserEmail = "usuario02@teste",
        UserCreatedDate = DateTimeOffset.UtcNow
      },
      new User {
        Id = Guid.NewGuid(),
        UserName = "UsuarioTeste03",
        UserPassword = "Usu@rioP@ss03_",
        UserFullName = "Usuario Teste 03",
        UserEmail = "usuario03@teste",
        UserCreatedDate = DateTimeOffset.UtcNow
      },
    };


    public IEnumerable<User> GetUsers() => users;

    public User GetUser(Guid Id) => users.Where(user => user.Id == Id).SingleOrDefault();

    public void CreateUser(User user)
    {
      users.Add(user);
    }

    public void UpdateUser(User user)
    {
      var index = users.FindIndex(lUser => lUser.Id == user.Id);
      users[index] = user;
    }

    public void DeleteUser(Guid Id)
    {
      var index = users.FindIndex(lUser => lUser.Id == Id);
      users.RemoveAt(index);
    }
  }
}