using System;
using System.Collections.Generic;
using Keeper.Models;
using Keeper.Services;
using Microsoft.AspNetCore.Mvc;

namespace Keeper.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VaultsController : ControllerBase
    {
        private readonly VaultsService _vs;

        public VaultsController(VaultsService vs)
        {
            _vs = vs;
        }


        [HttpGet]
        public ActionResult<List<Vault>> Get()
        {
            try
            {
                List<Vault> vaults = _vs.Get();
                return Ok(vaults);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }


        }
    }
}