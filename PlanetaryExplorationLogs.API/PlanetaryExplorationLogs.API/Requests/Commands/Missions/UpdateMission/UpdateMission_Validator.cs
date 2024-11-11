using System.Net;
using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.UpdateMission
{
    public class UpdateMission_Validator : ValidatorBase
    {
        private readonly Mission _mission;

        public UpdateMission_Validator(PlanetExplorationDbContext context, Mission mission) : base(context)
        {
            _mission = mission;
        }

        public override async Task<RequestResult> ValidateAsync()
        {
            await Task.CompletedTask;

            if (!await DbContext.Missions.AnyAsync(m => m.Id == _mission.Id))
            {
                return await InvalidResultAsync(
                    HttpStatusCode.NotFound, "Mission doesn't exist.");
            }
            return await ValidResultAsync();
        }
    }
}
