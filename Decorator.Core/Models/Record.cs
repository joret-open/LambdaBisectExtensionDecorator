using System.Collections.Generic;
using System.IO;

namespace AWSLambdaBisectExtension.Decorator
{
    public class Record
    {
        public Record(Stream stream, Dictionary<string, object> headers)
        {
            Stream = stream;
            Headers = headers;
        }

        public Stream Stream { get; }
        public Dictionary<string, object> Headers{ get; }
    }
}
