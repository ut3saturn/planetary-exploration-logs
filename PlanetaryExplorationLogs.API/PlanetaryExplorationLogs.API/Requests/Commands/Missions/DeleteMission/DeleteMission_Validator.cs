using System.Net;
using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.DeleteMission
{
    public class DeleteMission_Validator : ValidatorBase
    {
        private readonly int _missionId;

        public DeleteMission_Validator(PlanetExplorationDbContext context, int missionId) : base(context)
        {
            _missionId = missionId;
        }

        public override async Task<RequestResult> ValidateAsync()
        {
            await Task.CompletedTask;

            if (!await DbContext.Missions.AnyAsync(m => m.Id == _missionId))
            {
                return await InvalidResultAsync(
                    HttpStatusCode.NotFound,
                    "Mission not found");
            }
            
            return await ValidResultAsync();
        }
    }
}
