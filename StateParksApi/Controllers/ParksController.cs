using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StateParks.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace ParkParks.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ParksController : ControllerBase
  {
    private readonly StateParksContext _db;

    public ParksController(StateParksContext db)
    {
      _db = db;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Park>>> Get(string title, int? userId)
    {
      IQueryable<Park> query = _db.Parks.AsQueryable();
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