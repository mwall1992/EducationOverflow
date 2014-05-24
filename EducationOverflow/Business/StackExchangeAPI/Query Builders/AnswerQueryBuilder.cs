using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    /// <summary>
    /// A concrete builder for queries to the Stack Exchange API which return answer objects.
    /// For more information on 'answer objects', consider the Stack Exchange API documentation:
    /// http://api.stackexchange.com/docs/types/answer
    /// </summary>
    public class AnswerQueryBuilder : StackExchangeSiteQueryBuilder<Answer, AnswerQueryBuilder> {

        public override IQuery<Answer> GetQuery() {
            return new StackExchangeAPIQuery<Answer>(this.GetBaseQueryUrl());
        }
    }
}
