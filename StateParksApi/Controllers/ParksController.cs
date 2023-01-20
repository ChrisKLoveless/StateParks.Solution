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
    public async Task<ActionResult<IEnumerable<Park>>> Get(string name, int? parkId)
    {
      IQueryable<Park> query = _db.Parks.AsQueryable();
      if (name != null)
      {
        query = query.Where(p => p.Name == name);
      }
      if (parkId != null)
      {
        query = query.Where(p => p.ParkId == parkId);
      }
      return await query.ToListAsync();
    }
  }
}