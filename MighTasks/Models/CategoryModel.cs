using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MighTasks.Models
{
    public class CategoryModel
    {
        // Property to store the category title
        /// <summary>
        /// Represents the name of the category (e.g., "Shopping")
        /// </summary>
        public string CategoryTitle { get; set; }
        // Property to store the hex colour of the badge background.
        /// <summary>
        /// Stores the colour code associated with the category for visualisation.
        /// </summary>
        public string HexColour { get; set; }
    }
}
