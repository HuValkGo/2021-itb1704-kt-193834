using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ITB1704Application;
using ITB1704Application.Model;

namespace ITB1704Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RoutesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Routes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Route>>> GetRoutes(string? name)
        {
            if(name != null)
            {
                return await _context.Routes.Where(x => x.Name == name).ToListAsync();
            }
            return await _context.Routes.ToListAsync();
        }

        // GET: api/Routes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Route>> GetRoute(int id)
        {
            var route = await _context.Routes.FindAsync(id);

            if (route == null)
            {
                return NotFound();
            }

            return route;
        }

        // GET: api/Routes/{id}/tickets
        [HttpGet("{id}/tickets")]
        public async Task<ActionResult<IEnumerable<int>>> GetRouteTickets(int id, string? departureStopName)
        {
            var tickets = _context.Tickets.Where(x => x.RouteId == id).AsQueryable();
            if (departureStopName != null)
            {
                var roadStop = _context.RouteStops.FirstOrDefault(x => x.StopName.ToUpper() == departureStopName.ToUpper());
                if (roadStop == null)
                {
                    return new List<int>();
                }
                tickets = tickets.Where(x => x.DepartureRouteStopId == roadStop.Id);
            }
            var intQuery = tickets.Select(x => x.Id).AsQueryable();
            return await intQuery.ToListAsync();
        }

        // PUT: api/Routes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoute(int id, Route route)
        {
            if (id != route.Id)
            {
                return BadRequest();
            }

            _context.Entry(route).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RouteExists(id))
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

        // POST: api/Routes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Route>> PostRoute(Route route)
        {
            if (route.Name.Length >= 5)
            {
                _context.Routes.Add(route);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetRoute", new { id = route.Id }, route);
            }
            return BadRequest();
        }

        // DELETE: api/Routes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoute(int id)
        {
            var route = await _context.Routes.FindAsync(id);
            if (route == null)
            {
                return NotFound();
            }

            _context.Routes.Remove(route);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RouteExists(int id)
        {
            return _context.Routes.Any(e => e.Id == id);
        }
    }
}
