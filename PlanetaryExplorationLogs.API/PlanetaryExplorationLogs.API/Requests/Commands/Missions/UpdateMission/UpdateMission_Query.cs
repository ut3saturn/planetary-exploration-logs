using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.UpdateMission
{
    public class UpdateMission_Query : RequestBase<int>
    {
        private Mission Mission { get; }

        public UpdateMission_Query(PlanetExplorationDbContext context, Mission mission) : base(context)
        {
            Mission = mission;
        }

        public override IValidator Validator => new UpdateMission_Validator(DbContext, Mission);
        public override IHandler<int> Handler => new UpdateMission_Handler(DbContext, Mission);
    }
}