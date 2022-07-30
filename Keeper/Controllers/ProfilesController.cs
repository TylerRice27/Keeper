using System;
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

        public ProfilesController(AccountService acctServ)
        {
            _acctServ = acctServ;
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

    }

}