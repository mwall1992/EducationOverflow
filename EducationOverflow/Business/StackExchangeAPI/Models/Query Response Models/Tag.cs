using System;
using System.Runtime.Serialization;

namespace StackExchangeAPI {

    [DataContract]
    public class Tag {

        [DataMember(Name = "count")]
        public Int32 Count { get; set; }

        [DataMember(Name = "has_synonyms")]
        public bool HasSynonyms { get; set; }

        [DataMember(Name = "is_moderator_only")]
        public bool IsModeratorOnly { get; set; }

        [DataMember(Name = "is_required")]
        public bool IsRequired { get; set; }

        [DataMember(Name = "last_activity_date")]
        public Int64 LastActivityDate { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "synonyms")]
        public string[] Synonyms { get; set; }

        public Tag() {
            this.SetPlaceholderValues();
        }

        // N.B. the constructor is not called during deserialisation.

        [OnDeserializing]
        private void OnDeserializing(StreamingContext context) {
            this.SetPlaceholderValues();
        }

        private void SetPlaceholderValues() {
            this.Count = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.HasSynonyms = StackExchangeAPI.DEFAULT_BOOL_VALUE;
            this.IsModeratorOnly = StackExchangeAPI.DEFAULT_BOOL_VALUE;
            this.IsRequired = StackExchangeAPI.DEFAULT_BOOL_VALUE;
            this.LastActivityDate = StackExchangeAPI.DEFAULT_DATE_VALUE;
            this.Name = StackExchangeAPI.DEFAULT_STRING_VALUE;
            this.Synonyms = (string[])StackExchangeAPI.DEFAULT_OBJ_VALUE;
        }
    }
}
