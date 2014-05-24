using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    /// <summary>
    /// A concrete builder for queries to the Stack Exchange API which return tag objects.
    /// For more information on 'tag objects', consider the Stack Exchange API documentation:
    /// http://api.stackexchange.com/docs/types/tag
    /// </summary>
    public class TagQueryBuilder : StackExchangeSiteQueryBuilder<Tag, TagQueryBuilder> {

        public override IQuery<Tag> GetQuery() {
            return new StackExchangeAPIQuery<Tag>(this.GetBaseQueryUrl());
        }
    }
}
