using HC.Entities.Models;
using HC.Library.CustomModels;
using System.Collections.Generic;

namespace HC.Core.Interface
{
    /// <summary>
    ///  Boat type manager
    /// </summary>
    public interface IBoatTypeManager
    {
        /// <summary>
        /// Returns list of boat types
        /// </summary>
        /// <returns></returns>
        APIResult<List<BoatType>> GetAll();
    }
}
