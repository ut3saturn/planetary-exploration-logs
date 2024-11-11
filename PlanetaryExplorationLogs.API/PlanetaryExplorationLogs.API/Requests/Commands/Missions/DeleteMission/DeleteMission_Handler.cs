using System.Net;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Utility.Patterns;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.DeleteMission
{
    public class DeleteMission_Handler : CommandQuery.HandlerBase<int>
    {
        private readonly int _missionId;
        public DeleteMission_Handler(PlanetExplorationDbContext context, int missionId) : base(context)
        {
            _missionId = missionId;
        }

        public override async Task<RequestResult<int>> HandleAsync()
        {
            var foundMission = await DbContext.Missions.FindAsync(_missionId);

            if (foundMission != null)
            {
                DbContext.Missions.Remove(foundMission);
                await DbContext.SaveChangesAsync();
            }

            var result = new RequestResult<int>()
            {
                Data = _missionId,
                StatusCode = HttpStatusCode.OK
            };

            return result;
        }
    }    
}
