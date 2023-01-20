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
    public async Task<ActionResult<IEnumerable<State>>> Get(string name, int? stateId)
    {
      IQueryable<State> query = _db.States.AsQueryable();
      if (stateId != null)
      {
        query = query.Where(st => st.Name == name);
      }
      if (stateId != null)
      {
        query = query.Where(st => st.StateId == stateId);
      }
      return await query.ToListAsync();
    }
  }
}