using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix.Data.Common
{
    class ServiceResponse
    {
        /// <summary>
        /// Gets or Sets the Status
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// Gets or Sets the UniqueRequestID
        /// </summary>
        public string UniqueRequestID { get; set; }
        /// <summary>
        /// Gets or Sets the Message
        /// </summary>
        public object Message { get; set; }
        /// <summary>
        /// Gets or Sets the Data
        /// </summary>
        public object Data { get; set; }
    }
}
