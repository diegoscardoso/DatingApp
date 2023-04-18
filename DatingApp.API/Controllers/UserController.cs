using DatingApp.API.Data;
using DatingApp.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace DatingApp.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly DataContext _dataContext;

    public UserController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers() 
        => await _dataContext.Users.ToListAsync();        

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
        => await _dataContext.Users.FindAsync(id) ?? new Entities.User();
        
}

