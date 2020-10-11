using Amazon.Lambda.Core;
using AWSLambdaBisectExtension.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace AWSLambdaBisectExtension.Decorator
{
    public class ConcreteCompMyProcessing : IComponentFunction
    {
        public IEnumerable<Record> Handle(IEnumerable<Record> records)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            //context.Logger.LogLine($"Beginning to process {records.Count()} records...");
            var output = new List<Record>();
            foreach (var record in records)
            {
                string recordData = GetRecordContents(record.Stream);

                Console.WriteLine($"Record Data:{recordData}");
                var deserialized = JsonSerializer.Deserialize<MyData>(recordData, options);


                Console.WriteLine($"Content:{deserialized.Content}");
                //TODO Do some processing...
                var processed = new MyData(deserialized.Id, deserialized.Content.ToUpper());


                if (deserialized.Content.Equals("poison"))
                {
                    throw new Exception("Unexpected bug/condition");
                }

                var outContent = JsonSerializer.Serialize(processed);

                output.Add(new Record (StringToStream(outContent), record.Headers));
            }

            return output;
        }

        private string GetRecordContents(Stream record)
        {
            using var reader = new StreamReader(record, Encoding.ASCII);

            byte[] data = Convert.FromBase64String(reader.ReadToEnd());
            string decodedString = Encoding.UTF8.GetString(data);
            return decodedString;
        }

        public static Stream StringToStream(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
