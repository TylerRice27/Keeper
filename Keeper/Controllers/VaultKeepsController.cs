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
    public class VaultKeepsController : ControllerBase
    {
        private readonly VaultKeepsService _vks;

        public VaultKeepsController(VaultKeepsService vks)
        {
            _vks = vks;
        }

        [HttpPost]
        [Authorize]

        public async Task<ActionResult<VaultKeep>> Create([FromBody] VaultKeep vaultKeepData)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                vaultKeepData.CreatorId = userInfo.Id;
                // VaultKeep vk = _vks.Create(vaultKeepData, userInfo?.Id);
                VaultKeep vk = _vks.Create(vaultKeepData);
                // vk.CreatorId = userInfo.Id;


                return Ok(vk);

            }
            catch (Exception e)
            {


                return BadRequest(e.Message);

            }

        }

        [HttpDelete("{id}")]
        [Authorize]

        public async Task<ActionResult<VaultKeep>> Delete(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                _vks.Delete(id, userInfo.Id);
                return Ok("Delete VaultKeep");

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }


        }


    }
}