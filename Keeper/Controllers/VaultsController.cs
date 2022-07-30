using System;
using System.Collections.Generic;
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

        private readonly VaultKeepsService _vks;

        public VaultsController(VaultsService vs, VaultKeepsService vks)
        {
            _vs = vs;
            _vks = vks;
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
                // This line sent my creator.Data back has an Object
                // To make my schema model happy
                newVault.Creator = userInfo;
                return Ok(newVault);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);


            }

        }

        // [HttpGet]
        // public async Task<ActionResult<List<Vault>>> Get()
        // {

        //     try
        //     {
        //         Account userInfo = await HttpContext.GetUserInfoAsync<Account>();

        //         List<Vault> vaults = _vs.Get();
        //         return Ok(vaults);
        //     }
        //     catch (Exception e)
        //     {

        //         return BadRequest(e.Message);
        //     }


        // }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vault>> GetAsync(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();

                Vault vault = _vs.GetPrivateVaults(id, userInfo?.Id);
                return Ok(vault);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }


        }

        [HttpPut("{id}")]
        [Authorize]

        public ActionResult<Vault> Edit([FromBody] Vault vault, int id)
        {
            try
            {
                vault.Id = id;
                Vault editVault = _vs.Edit(vault);
                return Ok(editVault);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        [HttpDelete("{id}")]
        [Authorize]

        public async Task<ActionResult<Vault>> Delete(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();

                _vs.Delete(id, userInfo.Id);
                return Ok("Deleted Vault");

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/keeps")]

        public async Task<ActionResult<List<Vault>>> GetKeeps(int id)
        {


            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                List<VaultKeepViewModel> keeps = _vks.GetByVaultId(id, userInfo?.Id);

                return Ok(keeps);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }




            // try
            // {
            //     List<VaultKeepViewModel> keeps = _vks.GetByVaultId(id);
            //     return Ok(keeps);

            // }
            // catch (Exception e)
            // {

            //     return BadRequest(e.Message);
            // }

        }


    }
}