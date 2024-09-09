using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Pqc.Crypto.Picnic;
using VetCare_BackEnd.Data;
using VetCare_BackEnd.Models;
using ZstdSharp.Unsafe;

namespace VetCare_BackEnd.Controllers.V1
{
    [ApiController]
    [Route("api/v1/users")]
    public class UserPostController : ControllerBase
    {
        // private readonly ApplicationDbContext _userService;

        // public UserPostController(ApplicationDbContext userservice)
        // {
        //     _userService = userservice;
        // }

        // [HttpPost("create")]
        // public async Task<IActionResult> CreateUser([FromBody] User newUser)
        // {
        //     _userService.Users.Add(newUser);
        //     await _userService.SaveChangesAsync();
        //     return Ok("usuario creado");
        // }
        //     if( UserDTO==null)
        //     {
        //         return BadRequest();
        //     }

        //     else if (!ModelState.IsValid)
        //     {
        //         return BadRequest();
        //     }

        //     var UserKeyFRole= await _userService.Roles.FindAsync(UserDTO.Role_id);
        //     if (UserKeyFRole==null)
        //     {
        //         return NotFound();
        //     }

        //     var UserKeyDocumentType= await _userService.DocumentTypes.FindAsync(UserDTO.DocumentType_id);
        //     if (UserKeyDocumentType==null)
        //     {
        //         return NotFound();
        //     }

        //     var NewUser= new User{
        //         Name = UserDTO.Name,
        //         LastName= UserDTO.LastName,
        //         BirthDate= UserDTO.BirthDate,
        //         DocumentNumber= UserDTO.DocumentNumber,
        //         Password=UserDTO.Password,
        //         PhoneNumber=UserDTO.PhoneNumber,
        //         Email=UserDTO.Email,
        //         DocumentType_id = UserDTO.DocumentType_id,
        //         Role_id = UserDTO.Role_id,
        //         Role = UserKeyFRole,
        //         DocumentType= UserKeyDocumentType
        //     };


        //     _userService.Users.Add(NewUser);

        //     await _userService.SaveChangesAsync();

        //     return CreatedAtAction(nameof(CreateUser), new { id = NewUser.Id }, NewUser);

        //     // return Created();
        // }

    }
}