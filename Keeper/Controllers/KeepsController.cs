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
    public class KeepsController : ControllerBase
    {
        private readonly KeepsService _ks;

        public KeepsController(KeepsService ks)
        {
            _ks = ks;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Keep>> CreateAsync([FromBody] Keep keepData)
        {
            try
            {

                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                keepData.CreatorId = userInfo?.Id;

                Keep newKeep = _ks.Create(keepData);
                newKeep.Creator = userInfo;
                return Ok(newKeep);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }


        }

        [HttpGet]
        public async Task<ActionResult<List<Keep>>> GetAsync()
        {
            try
            {

                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                List<Keep> keep = _ks.Get(userInfo?.Id);
                return Ok(keep);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }



        }

        [HttpGet("{id}")]
        public ActionResult<Keep> Get(int id)
        {

            try
            {
                Keep keep = _ks.Get(id);
                return Ok(keep);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }


        }

        [HttpPut("{id}")]
        [Authorize]

        public async Task<ActionResult<Keep>> EditAsync([FromBody] Keep keep, int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();

                keep.Id = id;
                keep.CreatorId = userInfo.Id;
                Keep editKeep = _ks.Edit(keep);
                return Ok(editKeep);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }


        }

        [HttpDelete("{id}")]
        [Authorize]

        public async Task<ActionResult<Keep>> DeleteAsync(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();

                _ks.Delete(id, userInfo.Id);
                return Ok("Deleted Keep");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }


        }
    }
}