using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    /// <summary>
    /// An interface required for all named sort states that can be applied 
    /// to a query to the Stack Exchange API servers.
    /// </summary>
    public interface INamedSortState : ISortState {

        string Name {
            get;
        }
    }
}
