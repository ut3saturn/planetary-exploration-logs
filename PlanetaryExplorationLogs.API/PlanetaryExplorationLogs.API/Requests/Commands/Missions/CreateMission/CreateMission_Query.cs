using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.CreateMission
{
    public class CreateMission_Query : RequestBase<int>
    {
        private Mission Mission { get; }
        public CreateMission_Query(PlanetExplorationDbContext context, Mission mission) : base(context)
        {
            Mission = mission;
        }

        public override IValidator Validator => new CreateMission_Validator(DbContext, Mission);
        public override IHandler<int> Handler => new CreateMission_Handler(DbContext, Mission);
    }
}
