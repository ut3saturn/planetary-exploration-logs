using System.Net;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.UpdateMission
{
    public class UpdateMission_Handler : HandlerBase<int>
    {
        private readonly Mission _mission;
        public UpdateMission_Handler(PlanetExplorationDbContext context, Mission mission) : base(context)
        {
            _mission = mission;
        }
        
        public override async Task<RequestResult<int>> HandleAsync()
        {
            var existingMission = await DbContext.Missions.FindAsync(_mission.Id);
            
            if (existingMission == null)
            {
                var response = new RequestResult<int>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = $"Mission not found with ID {_mission.Id}. Nothing to update."
                };
                return response;
            }

            existingMission.Name = _mission.Name;
            existingMission.Description = _mission.Description;

            DbContext.Missions.Update(existingMission);
            await DbContext.SaveChangesAsync();

            var requestResult = new RequestResult<int>
            {
                Data = _mission.Id,
                StatusCode = HttpStatusCode.OK,
            };

            return requestResult;
        }
    }    
}
