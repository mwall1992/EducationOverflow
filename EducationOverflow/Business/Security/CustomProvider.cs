using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business {
    
    /// <summary>
    /// A class containing static properties and functionality associated with both the 
    /// custom role provider and custom membership provider used by the Education 
    /// Overflow Web application.
    /// </summary>
    public class CustomProvider {

        private static string APPLICATION_NAME = "educationoverflow";
        
        /// <summary>
        /// Get the application name for the Education Overflow Web application.
        /// </summary>
        public static string ApplicationName {
            get {
                return CustomProvider.APPLICATION_NAME;
            }
        }
    }
}
