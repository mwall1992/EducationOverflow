using System;
using System.Runtime.Serialization;

namespace StackExchangeAPI {

    /// <summary>
    /// The model class corresponding to the "Site" response object 
    /// as defined in the Stack Exchange API documentation:
    /// http://api.stackexchange.com/docs/types/site
    /// </summary>
    [DataContract]
    public class Site {

        [DataMember(Name = "aliases")]
        public string[] Aliases { get; set; }

        [DataMember(Name = "api_site_parameter")]
        public string ApiSiteParameter { get; set; }

        [DataMember(Name = "audience")]
        public string Audience { get; set; }

        [DataMember(Name = "closed_beta_date")]
        public Int64 ClosedBetaDate { get; set; }

        [DataMember(Name = "favicon_url")]
        public string FavIconUrl { get; set; }

        [DataMember(Name = "icon_url")]
        public string IconUrl { get; set; }

        [DataMember(Name = "high_resolution_icon_url ")]
        public string LargeIconUrl { get; set; }

        [DataMember(Name = "launch_date")]
        public Int64 LaunchDate { get; set; }

        [DataMember(Name = "logo_url")]
        public string LogoUrl { get; set; }

        [DataMember(Name = "markdown_extensions")]
        public string[] MarkdownExtensions { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "open_beta_date")]
        public Int64 OpenBetaDate { get; set; }

        [DataMember(Name = "site_url")]
        public string SiteUrl { get; set; }

        public Site() {
            this.SetPlaceholderValues();
        }

        // N.B. the constructor is not called during deserialisation.

        [OnDeserializing]
        private void OnDeserializing(StreamingContext context) {
            this.SetPlaceholderValues();
        }

        // helper methods

        private void SetPlaceholderValues() {
            this.Aliases = (string[])StackExchangeAPI.DEFAULT_OBJ_VALUE;
            this.ApiSiteParameter = StackExchangeAPI.DEFAULT_STRING_VALUE;
            this.Audience = StackExchangeAPI.DEFAULT_STRING_VALUE;
            this.ClosedBetaDate = StackExchangeAPI.DEFAULT_DATE_VALUE;
            this.FavIconUrl = StackExchangeAPI.DEFAULT_STRING_VALUE;
            this.IconUrl = StackExchangeAPI.DEFAULT_STRING_VALUE;
            this.LargeIconUrl = StackExchangeAPI.DEFAULT_STRING_VALUE;
            this.LaunchDate = StackExchangeAPI.DEFAULT_DATE_VALUE;
            this.LogoUrl = StackExchangeAPI.DEFAULT_STRING_VALUE;
            this.MarkdownExtensions = (string[])StackExchangeAPI.DEFAULT_OBJ_VALUE;
            this.Name = StackExchangeAPI.DEFAULT_STRING_VALUE;
            this.OpenBetaDate = StackExchangeAPI.DEFAULT_DATE_VALUE;
            this.SiteUrl = StackExchangeAPI.DEFAULT_STRING_VALUE;
        }
    }
}
