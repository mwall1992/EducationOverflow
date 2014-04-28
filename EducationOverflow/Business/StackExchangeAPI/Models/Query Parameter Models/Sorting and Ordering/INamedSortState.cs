using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    // State design pattern - State Interface

    public interface INamedSortState : ISortState {

        string Name {
            get;
        }
    }
}
