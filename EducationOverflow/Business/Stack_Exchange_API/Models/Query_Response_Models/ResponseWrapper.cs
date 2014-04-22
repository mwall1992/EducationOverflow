using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace StackExchangeAPI {

    [DataContract]
    public class ResponseWrapper<T> {

        [DataMember(Name = "backoff")]
        public Int32 backOff;

        [DataMember(Name = "error_id")]
        public Int32 errorId;

        [DataMember(Name = "error_message")]
        public string errorMessage;

        [DataMember(Name = "error_name")]
        public string errorName;

        [DataMember(Name = "has_more")]
        public bool hasMore;

        [DataMember(Name = "items")]
        public T[] items;

        [DataMember(Name = "page")]
        public Int32 page;

        [DataMember(Name = "page_size")]
        public Int32 pageSize;

        [DataMember(Name = "quota_max")]
        public Int32 quotaMax;

        [DataMember(Name = "quota_remaining")]
        public Int32 quotaRemaining;

        [DataMember(Name = "total")]
        public Int32 total;

        [DataMember(Name = "type")]
        public string type;

        public ResponseWrapper() {
            this.SetPlaceholderValues();
        }

        // N.B. the constructor is not called during deserialisation.

        [OnDeserializing]
        private void OnDeserializing(StreamingContext context) {
            this.SetPlaceholderValues();
        }

        private void SetPlaceholderValues() {
            this.backOff = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.errorId = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.errorMessage = StackExchangeAPI.DEFAULT_STRING_VALUE;
            this.errorName = StackExchangeAPI.DEFAULT_STRING_VALUE;
            this.hasMore = StackExchangeAPI.DEFAULT_BOOL_VALUE;
            this.items = (T[])StackExchangeAPI.DEFAULT_OBJ_VALUE;
            this.page = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.pageSize = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.quotaMax = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.quotaRemaining = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.total = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.type = StackExchangeAPI.DEFAULT_STRING_VALUE;
        }
    }
}
