using ITB1704Application.DataRepositories;
using ITB1704Application.Model;
using HotChocolate.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITB1704Application.GraphQL
{
    public class Query
    {
        private readonly TestRepository _testRepository;
        private readonly RouteRepository _routeRepository;
        public Query( TestRepository testRepository, RouteRepository routeRepository)
        {
            _testRepository = testRepository
               ?? throw new ArgumentNullException(nameof(testRepository));
                _routeRepository = routeRepository
               ?? throw new ArgumentNullException(nameof(routeRepository)); 
        }

        [UseFiltering]
        [UseSorting]
        public async Task<IEnumerable<Test>> GetTestsAsync(string? name)
        {
            return await _testRepository.GetTestsAsync(name);
        }

        public async Task<Test> GetTestAsync(int id)
        {
            return await _testRepository.GetTestAsync(id);
        }

        [UseFiltering]
        [UseSorting]
        public async Task<IEnumerable<Route>> GetRoutesAsync(string? name)
        {
            return await _routeRepository.GetRoutesAsync(name);
        }

    }
}
