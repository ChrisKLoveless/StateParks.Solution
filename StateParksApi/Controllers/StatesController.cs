using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StateParks.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace StateParks.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class StatesController : ControllerBase
  {
    private readonly StateParksContext _db;

    public StatesController(StateParksContext db)
    {
      _db = db;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<State>>> Get(string title, int? userId)
    {
      IQueryable<State> query = _db.States.AsQueryable();
      if (title != null)
      {
        query = query.Where(th => th.Title == title);
      }
      if (userId != null)
      {
        query = query.Where(th => th.UsersId == userId);
      }
      return await query.ToListAsync();
    }
  }
}