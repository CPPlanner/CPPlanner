using CPPlanner.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPPlanner.Controllers.Api
{
    [Authorize]
    [Route("/api/catalog")]
    public class CatalogController : Controller
    {
        private ICPPlannerRepository _repository;

        public CatalogController(ICPPlannerRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("")]
        public IActionResult GetCatalog()
        {
            try
            {
                var results = _repository.GetCatalogs(this.User.Identity.Name);
                return Ok(results);
            }
            catch (Exception e)
            {
                return BadRequest($"Error while retrieving catalogs for username: {this.User.Identity.Name}");
            }
        }
    }
}
