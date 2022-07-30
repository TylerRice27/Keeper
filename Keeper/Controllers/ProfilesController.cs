using System;
using System.Collections.Generic;
using Keeper.Models;
using Keeper.Services;
using Microsoft.AspNetCore.Mvc;

namespace Keeper.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly AccountService _acctServ;

        private readonly KeepsService _ks;

        private readonly VaultsService _vs;

        public ProfilesController(AccountService acctServ, KeepsService ks, VaultsService vs)
        {
            _acctServ = acctServ;
            _ks = ks;
            _vs = vs;
        }

        [HttpGet("{id}")]
        public ActionResult<Profile> getById(string id)
        {
            try
            {
                Profile profile = _acctServ.GetProfileById(id);
                return Ok(profile);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        [HttpGet("{id}/keeps")]
        public ActionResult<List<Keep>> Get(string id)
        {
            try
            {
                List<Keep> keeps = _ks.GetKeepsByCreatorId(id);
                return Ok(keeps);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

    }

}