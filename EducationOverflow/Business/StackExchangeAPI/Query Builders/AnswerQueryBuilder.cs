using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    // Builder design pattern (fluent interface) - Concrete Builder

    public class AnswerQueryBuilder : StackExchangeSiteQueryBuilder<Answer, AnswerQueryBuilder> {

        public override IQuery<Answer> GetQuery() {
            return new StackExchangeAPIQuery<Answer>(this.GetBaseQueryUrl());
        }
    }
}
