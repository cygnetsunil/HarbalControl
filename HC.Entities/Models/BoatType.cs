using System;
using System.Collections.Generic;

#nullable disable

namespace HC.Entities.Models
{
    /// <summary>
    /// Boat type model
    /// </summary>
    public partial class BoatType
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int TypeId { get; set; }
        /// <summary>
        /// Name of boat type
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Boat Speed
        /// </summary>
        public decimal Speed { get; set; }
        /// <summary>
        /// Sequnce number
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// This propery is for calculated duration
        /// </summary>
        public decimal Time { get; set; }
        /// <summary>
        /// Boat Status (Pending, inprogress, Completed..etc)
        /// </summary>
        public int Status { get; set; }
    }
}
