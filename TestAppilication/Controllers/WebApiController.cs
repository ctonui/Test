using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAppilication.Repository;
using TestAppilication.Repository.Models;

namespace TestAppilication.Controllers
{
   
    [Route("WebApi/")]
    [ApiController]
    public class WebApiController : ControllerBase
    {
        private readonly BankInterface _bankInterface;
        public WebApiController(BankInterface bankInterface)
        {
            _bankInterface = bankInterface;
        }
       
        [HttpGet("GetBanks")]
        public async Task<IEnumerable<TblBank>> GetBanks()
        {
            return await _bankInterface.Get();
        }
        [HttpGet ("GetBank/{Id}")]
        public async Task<ActionResult<TblBank>> GetBank(int Id)
        {
            return await _bankInterface.Get(Id);
        }
        //public async Task<ActionResult<TblBank>> Addbank(int Id)
        //{
        //    return await _bankInterface.Get(Id);
        //}

        //[HttpPost]
        //public async Task<ActionResult<TblBank>> CreateBank(TblBank Bank)
        //{
        //    try
        //    {
        //        if (Bank == null)
        //            return BadRequest();

        //        var createdBank = await _bankInterface.Create(Bank);

        //        return CreatedAtAction(nameof(GetBank),
        //            new { id = createdBank.BankId }, createdBank);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //            "Error creating new employee record");
        //    }
        //}

        [HttpPost]

        public async Task<ActionResult<TblBank>> AddBank([FromForm] TblBank newBank)
        {
            var newLoanType = await _bankInterface.Create(newBank);
            return CreatedAtAction(nameof(GetBank), new { Id = newLoanType.BankId }, newLoanType);

        }
    }
}
    