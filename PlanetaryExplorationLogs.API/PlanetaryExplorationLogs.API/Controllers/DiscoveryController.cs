using Microsoft.AspNetCore.Mvc;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Requests.Commands.Discoveries.DeleteDiscoveryType;
using PlanetaryExplorationLogs.API.Requests.Commands.Discoveries.UpdateDiscoveryType;
using PlanetaryExplorationLogs.API.Requests.Queries.Discoveries.GetDiscoveryTypeById;
using PlanetaryExplorationLogs.API.Requests.Queries.Discoveries.GetDiscoveryTypes;
using PlanetaryExplorationLogs.API.Utility.Patterns;

namespace PlanetaryExplorationLogs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscoveryController : ControllerBase
    {
        private readonly PlanetExplorationDbContext _context;
        public DiscoveryController(PlanetExplorationDbContext context)
        {
            _context = context;
        }

        // GET: api/discovery/types
        [HttpGet("types")]
        public async Task<ActionResult<RequestResult<List<DiscoveryType>>>> GetDiscoveryTypes()
        {
            var query = new GetDiscoveryTypes_Query(_context);
            return await query.ExecuteAsync();
        }

        // GET: api/discovery/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<RequestResult<DiscoveryType>>> GetDiscovery(int id)
        {
            // Retrieve a specific discovery by ID.
            var query = new GetDiscoveryTypeById_Query(_context, id);
            return await query.ExecuteAsync();
        }

        // PUT: api/discovery/{id}
        [HttpPut()]
        public async Task<ActionResult<RequestResult<int>>> UpdateDiscovery([FromBody] DiscoveryType discoveryType)
        {
            // Update an existing discovery.
            var query = new UpdateDiscovery_Query(_context, discoveryType);
            return await query.ExecuteAsync();
        }

        // DELETE: api/discovery/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<RequestResult<int>>> DeleteDiscovery(int id)
        {
            // Delete a discovery.
            var query = new DeleteDiscovery_Query(_context, id);
            return await query.ExecuteAsync();
        }
    }
}
