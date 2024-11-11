using System.Net;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.CreateMission
{
    public class CreateMission_Validator : ValidatorBase
    {
        private readonly Mission _mission;
        public CreateMission_Validator(PlanetExplorationDbContext context, Mission mission) : base(context)
        {
            _mission = mission;
        }

        public override async Task<RequestResult> ValidateAsync()
        {
            if (string.IsNullOrEmpty(_mission.Name))
            {
                return await InvalidResultAsync(
                    HttpStatusCode.BadRequest,
                    "Mission name is required");
            }
            
            return await ValidResultAsync();
        }
    }
}
