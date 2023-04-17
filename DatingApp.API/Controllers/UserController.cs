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
    public async ActionResult<IEnumerable<User>> GetUsers() 
        => _dataContext.Users.ToListAsync();        

    [HttpGet("{id}")]
    public async ActionResult<User> GetUser(int id)
        => await _dataContext.Users.Where(o => o.Id == id).FirstOrDefaultAsync();
}

