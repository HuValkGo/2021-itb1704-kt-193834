using ITB1704Application.DataRepositories;
using ITB1704Application.Model;
using HotChocolate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITB1704Application.GraphQL.Resolvers
{
    public class TicketResolver
    {
        public async Task<IEnumerable<RouteStop>> GetDepartureRouteStopsByTicketAsync(
           [Parent] Ticket ticket,
           [Service] TicketRepository repository)
        {

            return await repository.GetDepartureRouteStopsByTicketAsync(ticket.Id);
        }
    }
}
