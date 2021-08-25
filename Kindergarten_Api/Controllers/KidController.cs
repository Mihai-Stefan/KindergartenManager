using Business.Repository.IRepository;
using Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kindergarten_Api.Controllers
{
    [Route("api/[controller]")]
    public class KidController : Controller
    {
        private readonly IKidRepository _kidRepository;

        public KidController(IKidRepository kidRepository)
        {
            _kidRepository = kidRepository;
        }


        [Authorize(Roles = SD.Role_Admin)]
        [HttpGet]
        public async Task<IActionResult> GetKids()
        {
            var allKids = await _kidRepository.GetAllKids();
            return Ok(allKids);
        }

        [HttpGet("{kidId}")]
        public async Task<IActionResult> GetKid(int? kidId)
        {
            if (kidId == null)
            {
                return BadRequest(new ErrorModel()
                {
                    Title = "",
                    ErrorMessage = "Invalid Kid Id",
                    StatusCode = StatusCodes.Status400BadRequest
                });
            }

            var kidDetails = await _kidRepository.GetKid(kidId.Value);
            if (kidDetails == null)
            {
                return BadRequest(new ErrorModel()
                {
                    Title = "",
                    ErrorMessage = "Invalid Kid Id",
                    StatusCode = StatusCodes.Status404NotFound
                });
            }

            return Ok(kidDetails);
        }

    }
}
