using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Missions.GetDiscoveriesForMission
{
    public class GetDiscoveriesForMission_Query : RequestBase<List<Discovery>>
    {
        private int MissionId { get; }
        public GetDiscoveriesForMission_Query(PlanetExplorationDbContext context, int missionId) : base(context)
        {
            MissionId = missionId;
        }

        public override IHandler<List<Discovery>> Handler => new GetDiscoveriesForMission_Handler(DbContext, MissionId);
    }
}
