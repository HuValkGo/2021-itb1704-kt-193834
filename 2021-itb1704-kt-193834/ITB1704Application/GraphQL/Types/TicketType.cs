using System;
using System.Collections.Generic;
using System.Linq;
using ITB1704Application.GraphQL.Resolvers;
using ITB1704Application.Model;
using System.Threading.Tasks;
using HotChocolate.Types;
using HotChocolate.Data;

namespace ITB1704Application.GraphQL.Types
{
    public class TicketType : ObjectType<Ticket>
    {

        [UseFiltering]
        [UseSorting]
        protected override void Configure(IObjectTypeDescriptor<Ticket> descriptor)
        {

            descriptor.Field<TicketResolver>(r => r.GetDepartureRouteStopsByTicketAsync(default, default))
                .Name("departureRouteStop");
        }
    }
}
