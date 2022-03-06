using Usuarios.Dtos;
using Usuarios.Entities;

namespace Usuarios
{
  public static class Extensions
  {
    public static UserPublicDto AsPublicDto(this User user) => new UserPublicDto{
      Id = user.Id,
      UserFullName = user.UserFullName,
      UserEmail = user.UserEmail,
      UserCreatedDate = user.UserCreatedDate
    };
  }
}