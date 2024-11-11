using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.CreateDiscoveryForMission
{
    public class CreateDiscoveryForMission_Query : RequestBase<int>
    {
        private int MissionId { get; }
        private Discovery Discovery { get; }

        public CreateDiscoveryForMission_Query(PlanetExplorationDbContext context, int missionId, Discovery discovery) :
            base(context)
        {
            MissionId = missionId;
            Discovery = discovery;
        }

        public override IValidator? Validator => new CreateDiscoveryForMission_Validator(DbContext, MissionId);
        public override IHandler<int> Handler => new CreateDiscoveryForMission_Handler(DbContext, MissionId, Discovery);
    }
}
