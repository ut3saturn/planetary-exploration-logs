using PlanetaryExplorationLogs.API.Data.Context;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.DeleteMission
{
    public class DeleteMission_Query : RequestBase<int>
    {
        private int Id { get; }
        public DeleteMission_Query(PlanetExplorationDbContext context, int id) : base(context)
        {
            Id = id;
        }

        public override IValidator? Validator => new DeleteMission_Validator(DbContext, Id);
        public override IHandler<int> Handler => new DeleteMission_Handler(DbContext, Id);
    }
}
