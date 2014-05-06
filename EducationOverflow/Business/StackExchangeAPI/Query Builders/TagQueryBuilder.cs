using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    // Builder design pattern (fluent interface) - Concrete Builder

    public class TagQueryBuilder : StackExchangeSiteQueryBuilder<Tag, TagQueryBuilder> {

        public override IQuery<Tag> GetQuery() {
            return new StackExchangeAPIQuery<Tag>(this.GetBaseQueryUrl());
        }
    }
}
