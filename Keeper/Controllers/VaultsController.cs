using System;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Keeper.Models;
using Keeper.Services;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost]
        [Authorize]

        public async Task<ActionResult<Vault>> Create([FromBody] Vault vaultData)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                vaultData.CreatorId = userInfo?.Id;
                Vault newVault = _vs.Create(vaultData);
                return Ok(newVault);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);


            }

        }

        [HttpGet("{id}")]
        public ActionResult<Vault> Get(int id)
        {

            try
            {
                Vault vault = _vs.Get(id);
                return Ok(vault);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }


        }




        // [HttpGet("{id}")]
        // public async Task<ActionResult<Vault>> Get()
        // {
        //     try
        //     {

        //         Account userInfo = await HttpContext.GetUserInfoAsync<Account>();

        //         < Vault > vault = _vs.Get(userInfo.Id);
        //         return Ok(vault);
        //     }
        //     catch (Exception e)
        //     {

        //         return BadRequest(e.Message);
        //     }


        // }
    }
}