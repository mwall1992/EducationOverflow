using System;
using System.Runtime.Serialization;

namespace StackExchangeAPI {

    [DataContract]
    public class Site {

        [DataMember(Name = "aliases")]
        public string[] aliases;

        [DataMember(Name = "api_site_parameter")]
        public string apiSiteParameter;

        [DataMember(Name = "audience")]
        public string audience;

        [DataMember(Name = "closed_beta_date")]
        public Int64 closedBetaDate;

        [DataMember(Name = "favicon_url")]
        public string favIconUrl;

        [DataMember(Name = "icon_url")]
        public string iconUrl;

        [DataMember(Name = "high_resolution_icon_url ")]
        public string largeIconUrl;

        [DataMember(Name = "launch_date")]
        public Int64 launchDate;

        [DataMember(Name = "logo_url")]
        public string logoUrl;

        [DataMember(Name = "markdown_extensions")]
        public string[] markdownExtensions;

        [DataMember(Name = "name")]
        public string name;

        [DataMember(Name = "open_beta_date")]
        public Int64 openBetaDate;

        [DataMember(Name = "site_url")]
        public string siteUrl;

        public Site() {
            this.SetPlaceholderValues();
        }

        // N.B. the constructor is not called during deserialisation.

        [OnDeserializing]
        private void OnDeserializing(StreamingContext context) {
            this.SetPlaceholderValues();
        }

        private void SetPlaceholderValues() {
            this.aliases = (string[])StackExchangeAPI.DEFAULT_OBJ_VALUE;
            this.apiSiteParameter = StackExchangeAPI.DEFAULT_STRING_VALUE;
            this.audience = StackExchangeAPI.DEFAULT_STRING_VALUE;
            this.closedBetaDate = StackExchangeAPI.DEFAULT_DATE_VALUE;
            this.favIconUrl = StackExchangeAPI.DEFAULT_STRING_VALUE;
            this.iconUrl = StackExchangeAPI.DEFAULT_STRING_VALUE;
            this.largeIconUrl = StackExchangeAPI.DEFAULT_STRING_VALUE;
            this.launchDate = StackExchangeAPI.DEFAULT_DATE_VALUE;
            this.logoUrl = StackExchangeAPI.DEFAULT_STRING_VALUE;
            this.markdownExtensions = (string[])StackExchangeAPI.DEFAULT_OBJ_VALUE;
            this.name = StackExchangeAPI.DEFAULT_STRING_VALUE;
            this.openBetaDate = StackExchangeAPI.DEFAULT_DATE_VALUE;
            this.siteUrl = StackExchangeAPI.DEFAULT_STRING_VALUE;
        }
    }
}
