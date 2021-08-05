using HC.Core;
using HC.Core.Interface;
using HC.Entities.Models;
using HC.Library;
using HC.Library.CustomModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HC.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HarbalControlController : ControllerBase
    {
        /// <summary>
        /// HarbalControl
        /// </summary>
        #region Private Variables
        private readonly ILogger<HarbalControlController> _logger;
        private readonly IBoatTypeManager _manager;
        #endregion
        #region Constructor
        public HarbalControlController(ILogger<HarbalControlController> logger, IBoatTypeManager manager)
        {
            _logger = logger;
            _manager = manager;
        }
        #endregion
        #region Acion Methods
        /// <summary>
        /// Returns number of random boats
        /// </summary>
        /// <param name="Count"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("RandomBoats/{Count}")]
        public IActionResult Get(int Count)
        {
            _logger.LogInformation("Controller called");
            var result = new APIResult<List<BoatType>>() { Success = false, Data = null };
            try
            {
                var boats = _manager.GetAll();
                if (boats.Success)
                {
                    result.Success = true;
                    result.Data = Utils.GetSelectedRandom<BoatType>(boats.Data, Count).Select((x, i) => new BoatType()
                    {
                        Index = i + 1,
                        TypeId = x.TypeId,
                        Name = x.Name,
                        Speed = x.Speed,
                        Time = ((10 * 60) / x.Speed),
                        Status = 0
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                _logger.LogError(ex.Message.ToString());
            }
            return Ok(result);
        }
        #endregion
    }
}
