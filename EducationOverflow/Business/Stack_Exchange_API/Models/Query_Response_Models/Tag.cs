using System;
using System.Runtime.Serialization;

namespace StackExchangeAPI {

    [DataContract]
    public class Tag {

        [DataMember(Name = "count")]
        public Int32 count;

        [DataMember(Name = "has_synonyms")]
        public bool hasSynonyms;

        [DataMember(Name = "is_moderator_only")]
        public bool isModeratorOnly;

        [DataMember(Name = "is_required")]
        public bool isRequired;

        [DataMember(Name = "last_activity_date")]
        public Int64 lastActivityDate;

        [DataMember(Name = "name")]
        public string name;

        [DataMember(Name = "synonyms")]
        public string[] synonyms;

        public Tag() {
            this.SetPlaceholderValues();
        }

        // N.B. the constructor is not called during deserialisation.

        [OnDeserializing]
        private void OnDeserializing(StreamingContext context) {
            this.SetPlaceholderValues();
        }

        private void SetPlaceholderValues() {
            this.count = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.hasSynonyms = StackExchangeAPI.DEFAULT_BOOL_VALUE;
            this.isModeratorOnly = StackExchangeAPI.DEFAULT_BOOL_VALUE;
            this.isRequired = StackExchangeAPI.DEFAULT_BOOL_VALUE;
            this.lastActivityDate = StackExchangeAPI.DEFAULT_DATE_VALUE;
            this.name = StackExchangeAPI.DEFAULT_STRING_VALUE;
            this.synonyms = (string[])StackExchangeAPI.DEFAULT_OBJ_VALUE;
        }
    }
}
