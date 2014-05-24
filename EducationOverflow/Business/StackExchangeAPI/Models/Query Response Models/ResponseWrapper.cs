using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace StackExchangeAPI {

    /// <summary>
    /// The model class corresponding to the "Common Wrapper" response object 
    /// as defined in the Stack Exchange API documentation:
    /// http://api.stackexchange.com/docs/wrapper
    /// </summary>
    [DataContract]
    public class ResponseWrapper<T> {

        [DataMember(Name = "backoff")]
        public Int32 BackOff { get; set; }

        [DataMember(Name = "error_id")]
        public Int32 ErrorId { get; set; }

        [DataMember(Name = "error_message")]
        public string ErrorMessage { get; set; }

        [DataMember(Name = "error_name")]
        public string ErrorName { get; set; }

        [DataMember(Name = "has_more")]
        public bool HasMore { get; set; }

        [DataMember(Name = "items")]
        public T[] Items { get; set; }

        [DataMember(Name = "page")]
        public Int32 Page { get; set; }

        [DataMember(Name = "page_size")]
        public Int32 PageSize { get; set; }

        [DataMember(Name = "quota_max")]
        public Int32 QuotaMax { get; set; }

        [DataMember(Name = "quota_remaining")]
        public Int32 QuotaRemaining { get; set; }

        [DataMember(Name = "total")]
        public Int32 Total { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }

        public ResponseWrapper() {
            this.SetPlaceholderValues();
        }

        // N.B. the constructor is not called during deserialisation.

        [OnDeserializing]
        private void OnDeserializing(StreamingContext context) {
            this.SetPlaceholderValues();
        }

        // helper methods

        private void SetPlaceholderValues() {
            this.BackOff = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.ErrorId = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.ErrorMessage = StackExchangeAPI.DEFAULT_STRING_VALUE;
            this.ErrorName = StackExchangeAPI.DEFAULT_STRING_VALUE;
            this.HasMore = StackExchangeAPI.DEFAULT_BOOL_VALUE;
            this.Items = (T[])StackExchangeAPI.DEFAULT_OBJ_VALUE;
            this.Page = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.PageSize = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.QuotaMax = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.QuotaRemaining = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.Total = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.Type = StackExchangeAPI.DEFAULT_STRING_VALUE;
        }
    }
}
