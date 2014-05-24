using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    /// <summary>
    /// An interface required for all sort states that can be applied 
    /// to a query to the Stack Exchange API servers.
    /// </summary>
    public interface ISortState {

        string MinBound {
            get;
        }

        string MaxBound {
            get;
        }
    }
}
