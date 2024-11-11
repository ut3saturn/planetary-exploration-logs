using Microsoft.AspNetCore.Mvc;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Requests.Commands.Missions.CreateDiscoveryForMission;
using PlanetaryExplorationLogs.API.Requests.Commands.Missions.CreateMission;
using PlanetaryExplorationLogs.API.Requests.Commands.Missions.DeleteMission;
using PlanetaryExplorationLogs.API.Requests.Commands.Missions.UpdateMission;
using PlanetaryExplorationLogs.API.Requests.Queries.Missions.GetDiscoveriesForMission;
using PlanetaryExplorationLogs.API.Requests.Queries.Missions.GetMission;
using PlanetaryExplorationLogs.API.Requests.Queries.Missions.GetMissions;
using PlanetaryExplorationLogs.API.Utility.Patterns;

namespace PlanetaryExplorationLogs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionController : ControllerBase
    {
        private readonly PlanetExplorationDbContext _context;
        public MissionController(PlanetExplorationDbContext context)
        {
            _context = context;
        }

        // GET: api/mission
        [HttpGet]
        public async Task<ActionResult<RequestResult<List<Mission>>>> GetMissions()
        {
            var query = new GetMissions_Query(_context);
            return await query.ExecuteAsync();
        }

        // GET: api/mission/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<RequestResult<Mission>>> GetMission(int id)
        {
            var query = new GetMission_Query(_context, id);
            return await query.ExecuteAsync();
        }

        // POST: api/mission
        [HttpPost]
        public async Task<ActionResult<RequestResult<int>>> CreateMission([FromBody] Mission mission)
        {
            var query = new CreateMission_Query(_context, mission);
            return await query.ExecuteAsync();
        }

        // PUT: api/mission
        [HttpPut]
        public async Task<ActionResult<RequestResult<int>>> UpdateMission([FromBody] Mission mission)
        {
            var query = new UpdateMission_Query(_context, mission);
            return await query.ExecuteAsync();
        }

        // DELETE: api/mission/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<RequestResult<int>>> DeleteMission(int id)
        {
            var query = new DeleteMission_Query(_context, id);
            return await query.ExecuteAsync();
        }

        // GET: api/mission/{missionId}/discovery
        [HttpGet("{missionId}/discovery")]
        public async Task<ActionResult<RequestResult<List<Discovery>>>> GetDiscoveriesForMission(int missionId)
        {
            var query = new GetDiscoveriesForMission_Query(_context, missionId);
            return await query.ExecuteAsync();
        }

        // POST: api/mission/{missionId}/discovery
        [HttpPost("{missionId}/discovery")]
        public async Task<ActionResult<RequestResult<int>>> CreateDiscoveryForMission(int missionId, [FromBody] Discovery discovery)
        {
            var query = new CreateDiscoveryForMission_Query(_context, missionId, discovery);
            return await query.ExecuteAsync();
        }
    }
}
