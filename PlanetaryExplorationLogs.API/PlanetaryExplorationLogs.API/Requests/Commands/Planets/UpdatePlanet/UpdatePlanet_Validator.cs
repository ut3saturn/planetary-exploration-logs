﻿using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using System.Net;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Planets.UpdatePlanet
{
    public class UpdatePlanet_Validator : ValidatorBase
	{
		private readonly Planet _planet;

		public UpdatePlanet_Validator(PlanetExplorationDbContext context, Planet planet)
			: base(context)
		{
			_planet = planet;
		}

		public override async Task<RequestResult> ValidateAsync()
		{
			// Obviously, this is dummy validation logic. Replace it with your own.
			await Task.CompletedTask;

            if(DbContext.Planets.Any(p => p.Id == _planet.Id))

            if (string.IsNullOrEmpty(_planet.Name.Trim()))
            {
                return await InvalidResultAsync(
                    HttpStatusCode.BadRequest,
                    "The planet must have a name.");
            }

            if (string.IsNullOrEmpty(_planet.Type.Trim()))
            {
                return await InvalidResultAsync(
                    HttpStatusCode.BadRequest,
                    "The planet must have a type.");
            }

            // You can also check things in the database, if needed, such as checking if a record exists
            return await ValidResultAsync();
		}
	}

}
