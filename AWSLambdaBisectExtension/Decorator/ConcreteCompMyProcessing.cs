using Amazon.Lambda.Core;
using Amazon.Lambda.KinesisEvents;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AWSLambdaBisectExtension.Decorator
{
    public class ConcreteCompMyProcessing : IComponentFunction<KinesisEvent, ILambdaContext, string>
    {
        public string Handle(KinesisEvent kinesisEvent, ILambdaContext context)
        {
            context.Logger.LogLine($"Beginning to process {kinesisEvent.Records.Count} records...");

            foreach (var record in kinesisEvent.Records)
            {
                context.Logger.LogLine($"Event ID: {record.EventId}");
                context.Logger.LogLine($"Event Name: {record.EventName}");

                string recordData = GetRecordContents(record.Kinesis);

                if (recordData.Equals("{trigger-bug}"))
                {
                    throw new Exception("Unexpected bug/condition");
                }

                context.Logger.LogLine($"Record Data:");
                context.Logger.LogLine(recordData);
            }

            context.Logger.LogLine("Stream processing complete.");
            return "OK";
        }

        private string GetRecordContents(KinesisEvent.Record streamRecord)
        {
            using (var reader = new StreamReader(streamRecord.Data, Encoding.ASCII))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
