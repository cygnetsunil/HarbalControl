using HC.Core.Interface;
using HC.Entities.Models;
using HC.Library.CustomModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
namespace HC.Core.Manager
{

    /// <summary>
    /// Boat manager implemenations
    /// </summary>
    public class BoatTypeManager : IBoatTypeManager
    {
        #region Private variables
        private readonly ILogger _logger;
        #endregion
        #region Constructor
        public BoatTypeManager(ILogger<BoatTypeManager> logger)
        {
            _logger = logger;
        }
        #endregion
        #region Action methods
        /// <summary>
        /// Implemeation for boat list
        /// </summary>
        /// <returns></returns>
        public APIResult<List<BoatType>> GetAll()
        {
            _logger.LogInformation("BoatType Manager/ Get all");
            APIResult<List<BoatType>> result = new APIResult<List<BoatType>>() { Success = false, Data = null };
            try
            {
                var boats = new List<BoatType>();
                boats.Add(new BoatType { TypeId = 1, Name = "Speed Boat", Speed = 30 });
                boats.Add(new BoatType { TypeId = 2, Name = "Sail Boat", Speed = 15 });
                boats.Add(new BoatType { TypeId = 3, Name = "Cargo Ship", Speed = 5 });
                result.Success = true;
                result.Data = boats; 
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Data = null;
                result.Message = ex.Message.ToString();
                _logger.LogError(ex.Message.ToString());
            }
            return result;
        }
        #endregion
    }
}
