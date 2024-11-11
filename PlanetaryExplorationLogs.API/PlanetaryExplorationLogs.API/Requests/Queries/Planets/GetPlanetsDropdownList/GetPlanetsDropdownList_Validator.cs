﻿using System.Net;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Planets.GetPlanetsDropdownList
{
    public class GetPlanetsDropdownList_Validator : ValidatorBase
    {
        public GetPlanetsDropdownList_Validator(PlanetExplorationDbContext context)
            : base(context)
        {
        }

        public override async Task<RequestResult> ValidateAsync()
        {
            if (!DbContext.Planets.Any())
            {
                return await InvalidResultAsync(
                    HttpStatusCode.NotFound,
                    "There are no planet records. Please add a planet.");
            }

            return await ValidResultAsync();
        }
    }

}
