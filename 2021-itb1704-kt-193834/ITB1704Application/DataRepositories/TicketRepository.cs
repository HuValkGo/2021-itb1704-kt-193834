using ITB1704Application.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITB1704Application.DataRepositories
{
    public class TicketRepository
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;
        RouteRepository route = new RouteRepository();
        public TicketRepository(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<RouteStop>> GetDepartureRouteStopsByTicketAsync(int ticketId)
        {
            using var context = _contextFactory.CreateDbContext();
            var ticket = context.Tickets.FirstOrDefault(x => x.Id == ticketId);
            var routeStops = context.RouteStops.Where(x => x.RouteId== ticket.RouteId).AsQueryable();
            if (route.Order != null)
            {
                if (route.Order == "desc") routeStops = routeStops.OrderByDescending(x => x.OrderNo);
                if (route.Order == "asc") routeStops = routeStops.OrderBy(x => x.OrderNo);
            }
            return await routeStops.ToListAsync();
        }
    }
}
