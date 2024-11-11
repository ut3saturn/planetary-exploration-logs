using System.Net;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.CreateMission
{
    public class CreateMission_Handler : HandlerBase<int>
    {
        private readonly Mission _mission;

        public CreateMission_Handler(PlanetExplorationDbContext context, Mission mission) : base(context)
        {
            _mission = mission;
        }

        public override async Task<RequestResult<int>> HandleAsync()
        {
            var mission = await DbContext.Missions.FindAsync(_mission.Id);

            if (mission != null)
            {
                return new RequestResult<int>()
                {
                    StatusCode = HttpStatusCode.Conflict,
                    Message = $"Mission already exists with the specified id {_mission.Id}"
                };
            }
            
            DbContext.Add(_mission);
            await DbContext.SaveChangesAsync();
            
            return new RequestResult<int>()
            {
                Data = _mission.Id,
                StatusCode = HttpStatusCode.Created,
            };
        }
    }
}
