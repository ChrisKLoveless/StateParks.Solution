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

    [HttpGet("{id}")]
    public async Task<ActionResult<State>> GetState(int id)
    {
      State state = await _db.States.FindAsync(id);

      if (state == null)
      {
        return NotFound();
      }

      return state;
    }

    [HttpPost]
    public async Task<ActionResult<State>> Create(State state)
    {
      _db.States.Add(state);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetState), new { id = state.StateId }, state);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, State state)
    {
      if (id != state.StateId)
      {
        return BadRequest();
      }

      _db.States.Update(state);

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!StateExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    private bool StateExists(int id)
    {
      return _db.States.Any(e => e.StateId == id);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteState(int id)
    {
      State state = await _db.States.FindAsync(id);
      if (state == null)
      {
        return NotFound();
      }

      _db.States.Remove(state);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}