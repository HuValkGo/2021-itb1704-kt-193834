using ITB1704Application.DataRepositories;
using ITB1704Application.Model;
using HotChocolate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITB1704Application.GraphQL.Resolvers
{
    public class RouteResolver
    {
        public async Task<IEnumerable<Ticket>> GetTicketsByRouteAsync(
            string? order,
           [Parent] Route route,
           [Service] RouteRepository repository)
        {
            return await repository.GetTicketsByRouteAsync(route.Id, order);
        }
    }
}
