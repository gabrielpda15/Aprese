using Aprese.Extensions;
using Aprese.Models.Location;
using Aprese.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Aprese.WebAPI.Controllers
{
    public class LocationController : ApreseController
    {
        public LocationController(IServiceProvider provider) : base(provider)
        {
        }

        public async Task<IActionResult> GetCitiesAsync(CancellationToken ct)
        {
            var cityRepository = Provider.GetRequiredService<IRepository<City>>();

            return Ok();
        }
    }
}
