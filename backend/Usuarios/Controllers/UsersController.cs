using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Usuarios.Dtos;
using Usuarios.Entities;
using Usuarios.Repositories;

namespace Usuarios.Controllers
{
  // /usuarios
  [ApiController]
  [Route("usuarios")]
  public class UsersController : ControllerBase
  {
    private readonly IUsersRepository repository;

    public UsersController(IUsersRepository repository)
    {
      this.repository = repository;
    }


    // GET /usuarios
    [HttpGet]
    public IEnumerable<UserPublicDto> GetUsers()
    {
      var users = repository.GetUsers().Select(user => user.AsPublicDto());

      return users;
    }

    // GET /usuarios/{id}
    [HttpGet("{Id}")]
    public ActionResult<UserPublicDto> GetUser(Guid Id) 
    {
      var user = repository.GetUser(Id).AsPublicDto();

      if (user is null) return NotFound();

      return user;
    }

    // POST /usuarios
    [HttpPost]
    public ActionResult<UserPublicDto> CreateUser(CreateUserDto createUserDto)
    {
      User user = new()
      {
        Id = Guid.NewGuid(),
        UserName = createUserDto.UserName,
        UserPassword = createUserDto.UserPassword,
        UserFullName = createUserDto.UserFullName,
        UserEmail = createUserDto.UserEmail,
        UserCreatedDate = DateTimeOffset.UtcNow
      };

      repository.CreateUser(user);

      return CreatedAtAction(nameof(GetUser), new { Id = user.Id}, user.AsPublicDto());
    }

    // PUT /usuarios/{id}/change-username
    [HttpPut("{Id}/change-userfullname")]
    public ActionResult UpdateUserName(Guid Id, UpdateUserFullNameDto userDto)
    {
      var eUser = repository.GetUser(Id);

      if (eUser is null) return NotFound();

      User updatedUser = eUser with
      {
        UserFullName = userDto.UserFullName
      };

      repository.UpdateUser(updatedUser);

      return NoContent();
    }

    // DELETE /usuarios/{id}
    [HttpDelete("{id}")]
    public ActionResult DeleteUser(Guid Id)
    {
      var eUser = repository.GetUser(Id);

      if (eUser is null) return NotFound();

      repository.DeleteUser(Id);

      return NoContent();
    }
  }
}