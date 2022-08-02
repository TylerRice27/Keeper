using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
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
        public ActionResult<List<Keep>> GetKeepsByCreatorId(string id)
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

        [HttpGet("{id}/vaults")]

        public async Task<ActionResult<List<Vault>>> GetVaultsByCreatorIdAsync(string id)
        {

            try
            {
                //IF THEY ARE LOGGED IN
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                List<Vault> vaults = _vs.GetVaultsByCreatorId(id, userInfo?.Id);
                return Ok(vaults);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }


        }

    }

}