using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web;

namespace StackExchangeAPI {
    public abstract class StackExchangeParameterisedAPIQueryBuilder<T, V> : StackExchangeAPIQueryBuilder<T, V> 
    where T : class
    where V : StackExchangeParameterisedAPIQueryBuilder<T, V> {

        public static int MAX_PARAMETER_COUNT = 100;

        protected List<String> parameterValues;

        protected string apiMethodExtension;

        public override void Reset() {
            base.Reset();
            this.parameterValues = null;
            this.apiMethodExtension = null;
        }

        public V SetMethodParameterValues(List<String> parameterValues) {
            if (parameterValues.Count > MAX_PARAMETER_COUNT) {
                throw new ArgumentException(
                    string.Format("The number of parameter values specified is {0}. "
                                    + "The maximum number of parameter values allowed is {1}.",
                                    parameterValues.Count, MAX_PARAMETER_COUNT)
                );
            }
            
            for (int i = 0; i < parameterValues.Count; i++) {
                parameterValues[i] = HttpUtility.UrlEncode(parameterValues[i]);
            }

            this.parameterValues = parameterValues;
            return (V)this;
        }

        public V SetApiMethodExtension(string methodExtension) {
            this.apiMethodExtension = HttpUtility.UrlEncode(methodExtension);
            return (V)this;
        }

        protected string GetParameterisedAPIMethod() {
            if (this.apiMethod == null) {
                throw new ArgumentNullException("The api method cannot be null.");
            }

            const string PARAMETER_DELIMITER = ";";
            string apiMethod = this.apiMethod;

            // add parameters to the api method
            if (this.parameterValues != null && this.parameterValues.Count > 0) {

                apiMethod = apiMethod + "/";

                string methodParameter;
                for (int i = 0; i < this.parameterValues.Count; i++) {
                
                    // format parameter
                    methodParameter = this.parameterValues[i];
                    if (i < this.parameterValues.Count - 1) {
                        methodParameter = string.Concat(methodParameter, PARAMETER_DELIMITER);
                    }

                    // append parameter to api method string
                    apiMethod = apiMethod + methodParameter;
                }
            }

            // add any method name qualifiers to the method string
            if (this.apiMethodExtension != null) {
                apiMethod = string.Format("{0}/{1}", apiMethod, this.apiMethodExtension);
            }

            return apiMethod;
        }
    }
}
