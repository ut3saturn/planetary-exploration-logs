using System.Net;
using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.CreateDiscoveryForMission
{
    public class CreateDiscoveryForMission_Validator : ValidatorBase
    {
        private readonly int _missionId;

        public CreateDiscoveryForMission_Validator(PlanetExplorationDbContext context, int missionId) : base(context)
        {
            _missionId = missionId;
        }

        public override async Task<RequestResult> ValidateAsync()
        {
            var mission = await DbContext.Missions
                .Include(d => d.Discoveries)
                .Where(m => m.Id == _missionId)
                .FirstOrDefaultAsync();

            if (mission == null)
            {
                return await InvalidResultAsync(
                    HttpStatusCode.NotFound,
                    $"Mission not found with ID {_missionId}."
                );
            }
            
            return await ValidResultAsync();
        }
    }
}
