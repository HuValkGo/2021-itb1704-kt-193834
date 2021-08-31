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
    public class RouteStopsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RouteStopsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/RouteStops
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RouteStop>>> GetRouteStops()
        {
            return await _context.RouteStops.ToListAsync();
        }

        // GET: api/RouteStops/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RouteStop>> GetRouteStop(int id)
        {
            var routeStop = await _context.RouteStops.FindAsync(id);

            if (routeStop == null)
            {
                return NotFound();
            }

            return routeStop;
        }

        // PUT: api/RouteStops/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRouteStop(int id, RouteStop routeStop)
        {
            if (id != routeStop.Id)
            {
                return BadRequest();
            }

            _context.Entry(routeStop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RouteStopExists(id))
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

        // POST: api/RouteStops
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RouteStop>> PostRouteStop(RouteStop routeStop)
        {
            var doesRouteExist =  _context.Routes.FirstOrDefault(x => x.Id == routeStop.RouteId);
            if (doesRouteExist == null)
            {
                return NotFound();
            }
            if (routeStop.OrderNo <= 0)
            {
                return BadRequest();
            }
            var containsOrderNo = _context.RouteStops.Where(x=>x.RouteId==doesRouteExist.Id).FirstOrDefault(x => x.OrderNo == routeStop.OrderNo);
            var containsStopName = _context.RouteStops.Where(x => x.RouteId== doesRouteExist.Id).FirstOrDefault(x => x.StopName == routeStop.StopName);
            if (containsOrderNo != null || containsStopName != null)
            {
                return BadRequest();
            }
            _context.RouteStops.Add(routeStop);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRouteStop", new { id = routeStop.Id }, routeStop);
        }

        // DELETE: api/RouteStops/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRouteStop(int id)
        {
            var routeStop = await _context.RouteStops.FindAsync(id);
            if (routeStop == null)
            {
                return NotFound();
            }

            _context.RouteStops.Remove(routeStop);
            await _context.SaveChangesAsync();

            return Ok(routeStop);
        }

        private bool RouteStopExists(int id)
        {
            return _context.RouteStops.Any(e => e.Id == id);
        }
    }
}
