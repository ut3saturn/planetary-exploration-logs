using System.Net;
using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Missions.GetMission
{
    public class GetMission_Handler : HandlerBase<Mission>
    {
        private readonly int _missionId;

        public GetMission_Handler(PlanetExplorationDbContext context, int missionId) : base(context)
        {
            _missionId = missionId;
        }

        public override async Task<RequestResult<Mission>> HandleAsync()
        {
            var mission = await DbContext.Missions.Where(m => m.Id == _missionId).FirstOrDefaultAsync();

            if (mission == null)
            {
                return new RequestResult<Mission>()
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = $"No mission found with id: {_missionId}",
                };
            }

            var result = new RequestResult<Mission>
            {
                Data = mission,
                StatusCode = HttpStatusCode.OK,
            };
            
            return result;
        }
    }   
}