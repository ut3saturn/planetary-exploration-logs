using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Missions.GetMission
{
    public class GetMission_Query : RequestBase<Mission>
    {
        private int Id { get; }

        public GetMission_Query(PlanetExplorationDbContext context, int id) : base(context)
        {
            Id = id;
        }

        public override IHandler<Mission> Handler => new GetMission_Handler(DbContext, Id);
    }
}