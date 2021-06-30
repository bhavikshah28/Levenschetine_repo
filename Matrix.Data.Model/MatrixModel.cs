using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix.Data.Model
{
    public class MatrixModel
    {
        /// <summary>
        /// Gets or Sets the FirstInput
        /// </summary>
        public string FirstInput { get; set; }
        /// <summary>
        /// Gets or Sets the Second INput
        /// </summary>
        public string SecondInput { get; set; }
        /// <summary>
        /// Gets or sets the total levenschentein distance
        /// </summary>
        public int TotalDistance { get; set; }
    }
}
