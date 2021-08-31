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
    public class RouteType : ObjectType<Route>
    {
        [UseFiltering]
        [UseSorting]
        protected override void Configure(IObjectTypeDescriptor<Route> descriptor)
        {

            descriptor.Field<RouteResolver>(r => r.GetTicketsByRouteAsync(default, default, default))
                .Name("tickets");
        }
    }
}
