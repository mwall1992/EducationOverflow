using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

using System.IO.Compression;

namespace EducationOverflow {
    
    public partial class Default : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {
            //WebRequest request = WebRequest.Create("http://api.stackexchange.com/2.2/answers?order=desc&sort=activity&site=stackoverflow&filter=!Ldk(uYFB0jj2D42wej1Pr5");
            //WebRequest request = WebRequest.Create("http://api.stackexchange.com/2.2/tags?page=1&pagesize=90&order=desc&sort=popular&inname=computer&site=stackoverflow&filter=!9WA((BMGG");
            WebRequest request = WebRequest.Create("http://api.stackexchange.com/2.2/questions?page=1&pagesize=5&order=desc&sort=activity&site=stackoverflow&filter=!9WA((I.pG");
            request.Method = "GET";

            WebResponse response = request.GetResponse();

            string json;
            MemoryStream decompressedStream = new MemoryStream();
            GZipStream compressedStream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);

            compressedStream.CopyTo(decompressedStream);
            decompressedStream.Seek(0, SeekOrigin.Begin);

            using (StreamReader reader = new StreamReader(decompressedStream, System.Text.Encoding.UTF8)) {
                json = reader.ReadToEnd();
            }

            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(StackExchangeAPI.ResponseWrapper<StackExchangeAPI.Question>));
            MemoryStream stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(json));
            //StackExchangeAPI.ResponseWrapper<StackExchangeAPI.Answer> obj = (StackExchangeAPI.ResponseWrapper<StackExchangeAPI.Answer>)ser.ReadObject(stream);
            //StackExchangeAPI.ResponseWrapper<StackExchangeAPI.Tag> obj = (StackExchangeAPI.ResponseWrapper<StackExchangeAPI.Tag>)ser.ReadObject(stream);
            StackExchangeAPI.ResponseWrapper<StackExchangeAPI.Question> obj = (StackExchangeAPI.ResponseWrapper<StackExchangeAPI.Question>)ser.ReadObject(stream);

            stream.Close();
            compressedStream.Close();
            decompressedStream.Close();
        }
    }
}