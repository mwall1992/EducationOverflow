using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

using System.IO.Compression;

namespace StackExchangeAPI {

    public class StackExchangeAPIRequest {

        public static ResponseWrapper<T> MakeRequest<T>(StackExchangeAPIRequestInfo requestInfo) {
            WebRequest request = WebRequest.Create("http://api.stackexchange.com/2.2/answers?order=desc&sort=activity&site=stackoverflow&filter=!Ldk(uYFB0jj2D42wej1Pr5");
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

            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ResponseWrapper<T>));
            MemoryStream stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(json));
            ResponseWrapper<T> obj = (ResponseWrapper<T>)ser.ReadObject(stream);

            stream.Close();
            compressedStream.Close();
            decompressedStream.Close();

            return obj;
        }
    }
}
