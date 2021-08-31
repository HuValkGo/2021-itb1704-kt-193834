using ITB1704Application.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITB1704Application.DataRepositories
{
    public class RouteRepository
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;
        public string Order = "asc";
        public RouteRepository(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public RouteRepository()
        {
        }

        public async Task<List<Ticket>> GetTicketsByRouteAsync(int routeId, string? order)
        {
            using var context = _contextFactory.CreateDbContext();
            var tickets = context.Tickets.Where(x => x.RouteId == routeId).AsQueryable();
            Order = order;
            return await tickets.ToListAsync();
        }

        public async Task<List<Route>> GetRoutesAsync(string? name)
        {
            using var context = _contextFactory.CreateDbContext();
            var query = context.Routes.AsQueryable();
            if (name != null)
                query = query.Where(x => x.Name.ToUpper().Contains(name.ToUpper()));
            return await query.ToListAsync();
        }

    }
}
