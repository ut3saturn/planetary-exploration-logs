using System.Net;
using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Missions.GetDiscoveriesForMission
{
    public class GetDiscoveriesForMission_Handler : HandlerBase<List<Discovery>>
    {
        private readonly int _missionId;
        public GetDiscoveriesForMission_Handler(PlanetExplorationDbContext context, int missionId) : base(context)
        {
            _missionId = missionId;
        }

        public override async Task<RequestResult<List<Discovery>>> HandleAsync()
        {
            var missionResult = DbContext.Missions
                .Include(d => d.Discoveries)
                .Where(m => m.Id == _missionId)
                .FirstOrDefaultAsync();
            
            if (missionResult.Result == null)
            {
                return new RequestResult<List<Discovery>>()
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = $"Mission not found with id {_missionId}.",
                    Success = false
                };
            }
            
            var discoveries = missionResult.Result.Discoveries;

            if (discoveries.Count == 0)
            {
                return new RequestResult<List<Discovery>>()
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = $"No discoveries found for Mission with id {_missionId}.",
                    Success = false
                };
            }

            var resultRequest = new RequestResult<List<Discovery>>()
            {
                Data = discoveries,
                StatusCode = HttpStatusCode.OK,
                Success = true
            };

            return resultRequest;
        }
    }
}
