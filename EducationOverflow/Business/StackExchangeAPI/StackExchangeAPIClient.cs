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

    /// <summary>
    /// A client responsible for sending/retrieving data to/from the Stack Exchange API servers.
    /// </summary>
    public class StackExchangeAPIClient {

        /// <summary>
        /// Retrieve a response from the Stack Exchange API for a specified query.
        /// </summary>
        /// <typeparam name="T">The model class used for storing response data.</typeparam>
        /// <param name="query">The query.</param>
        /// <returns>A model object containing the response of the query.</returns>
        public static ResponseWrapper<T> GetResponse<T>(IQuery<T> query) where T : class {
            const string REQUEST_METHOD = "GET";

            WebRequest request = WebRequest.Create(query.GetURL());
            request.Method = REQUEST_METHOD;
            WebResponse response = request.GetResponse();
            ResponseWrapper<T> responseObj = ParseResponse<T>(response);

            return responseObj;
        }


        // helper methods


        /// <summary>
        /// Parse a response from the Stack Exchange API servers into a model object.
        /// </summary>
        /// <typeparam name="T">The model class used for storing response data.</typeparam>
        /// <param name="response">The response from the Stack Exchange API servers.</param>
        /// <returns>A model object containing the response data.</returns>
        private static ResponseWrapper<T> ParseResponse<T>(WebResponse response) {
            const int STREAM_OFFSET = 0;
            String parsedResponse;
            ResponseWrapper<T> responseObj;

            using (MemoryStream decompressedStream = new MemoryStream()) {

                // decompress response stream
                using (GZipStream compressedStream =
                            new GZipStream(response.GetResponseStream(), CompressionMode.Decompress)) {
                    compressedStream.CopyTo(decompressedStream);
                }
                decompressedStream.Seek(STREAM_OFFSET, SeekOrigin.Begin);

                // parse decompressed stream
                using (StreamReader reader =
                            new StreamReader(decompressedStream, System.Text.Encoding.UTF8)) {
                    parsedResponse = reader.ReadToEnd();
                }
            }

            // serialise response into model object
            DataContractJsonSerializer serialiser = new DataContractJsonSerializer(typeof(ResponseWrapper<T>));
            using (MemoryStream stream =
                        new MemoryStream(System.Text.Encoding.UTF8.GetBytes(parsedResponse))) {
                responseObj = (ResponseWrapper<T>)serialiser.ReadObject(stream);
            }

            return responseObj;
        }
    }
}
