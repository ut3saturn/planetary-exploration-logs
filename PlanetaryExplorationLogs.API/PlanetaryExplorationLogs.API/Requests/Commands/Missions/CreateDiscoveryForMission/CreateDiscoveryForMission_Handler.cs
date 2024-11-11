using System.Net;
using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.CreateDiscoveryForMission
{
    public class CreateDiscoveryForMission_Handler : HandlerBase<int>
    {
        private readonly int _missionId;
        private readonly Discovery _discovery;
        public CreateDiscoveryForMission_Handler(PlanetExplorationDbContext context, int missionId, Discovery discovery) : base(context)
        {
            _missionId = missionId;
            _discovery = discovery;
        }

        public override async Task<RequestResult<int>> HandleAsync()
        {
            var mission = await DbContext.Missions
                .Include(d => d.Discoveries)
                .Where(m => m.Id == _missionId)
                .FirstOrDefaultAsync();

            if (mission != null)
            {
                mission.Discoveries.Add(_discovery);
                
                DbContext.Missions.Update(mission);
                await DbContext.SaveChangesAsync();
            }

            var result = new RequestResult<int>
            {
                Data = _missionId,
                StatusCode = HttpStatusCode.OK
            };
            
            return result;
        }
    }
}
