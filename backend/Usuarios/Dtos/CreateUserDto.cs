using System.ComponentModel.DataAnnotations;

namespace Usuarios.Dtos
{
  public record CreateUserDto
  {
    [Required]
    public string UserName {get;init;}
    [Required]
    public string UserPassword {get;init;}
    [Required]
    public string UserFullName {get;init;}
    [Required]
    public string UserEmail {get;init;}
  }
}