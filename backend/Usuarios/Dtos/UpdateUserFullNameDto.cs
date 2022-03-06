using System.ComponentModel.DataAnnotations;

namespace Usuarios.Dtos
{
  public record UpdateUserFullNameDto
  {
    [Required]
    public string UserFullName {get;init;}
  }
}