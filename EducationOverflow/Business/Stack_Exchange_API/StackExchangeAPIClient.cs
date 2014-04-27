﻿using System;
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

    public class StackExchangeAPIClient {

        // dependency inversion principle and inversion of control.

        private IQuery apiQuery;

        public StackExchangeAPIClient(IQuery query) {
            this.apiQuery = query;
        }

        private ResponseWrapper<Object> GetResponse() {
            const string REQUEST_METHOD = "GET";

            WebRequest request = WebRequest.Create(this.apiQuery.GetURL());
            request.Method = REQUEST_METHOD;

            WebResponse response = request.GetResponse();

            ResponseWrapper<Object> responseObj = ParseResponse<Object>(response);

            return responseObj;
        }

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
