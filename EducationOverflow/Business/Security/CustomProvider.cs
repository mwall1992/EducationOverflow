using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business {
    
    public class CustomProvider {

        private static string APPLICATION_NAME = "educationoverflow";
        
        public static string ApplicationName {
            get {
                return CustomProvider.APPLICATION_NAME;
            }
        }
    }
}
