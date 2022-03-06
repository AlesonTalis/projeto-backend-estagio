using Guid = System.Guid;
using DateTimeOffset = System.DateTimeOffset;

namespace Usuarios.Dtos
{
  public record UserPublicDto
  {
    public Guid Id {get;init;}
    // public string UserName {get;init;}
    // public string UserPassword {get;init;}
    public string UserFullName {get;init;}
    public string UserEmail {get;init;}
    public DateTimeOffset UserCreatedDate {get;init;}
  }
}