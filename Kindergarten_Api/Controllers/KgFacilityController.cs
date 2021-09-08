using Business.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kindergarten_Api.Controllers
{
    [Route("api/[controller]")]
    public class KgFacilityController : Controller
    {
        private readonly IKgFacilityRepository _kgFacilityRepository;

        public KgFacilityController(IKgFacilityRepository kgFacilityRepository)
        {
            _kgFacilityRepository = kgFacilityRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetKgFacilitys()
        {
            var allFacilities = await _kgFacilityRepository.GetAllKgFacilities();
            return Ok(allFacilities);
        }
    }
}




