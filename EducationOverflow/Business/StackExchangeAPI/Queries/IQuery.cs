using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    public interface IQuery<T> where T : class {

        string GetURL();
    }
}
