using System;
using System.IO;
using System.Text;

using Amazon.Lambda.Core;
using Amazon.Lambda.KinesisEvents;
using AWSLambdaBisectExtension.Decorator;
using Decorator.Core;
using ShardStatistics;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AWSLambdaBisectExtension
{
    public class Function
    {
        public string FunctionHandler(KinesisEvent kinesisEvent, ILambdaContext context)
        {
            var bisectDecorator = new BisectExtensionConcreteDecorator<KinesisEvent, ILambdaContext, string>(new ConcreteCompMyProcessing(), new BisectConfig(), kinesisEvent.Records.Count, new CloudWatchShardMetrics());
            return bisectDecorator.Handle(kinesisEvent, context);
            //IoC on your dependencies
        }

        /* Original Processing Code
        public void FunctionHandler(KinesisEvent kinesisEvent, ILambdaContext context)
        {
            context.Logger.LogLine($"Beginning to process {kinesisEvent.Records.Count} records...");

            foreach (var record in kinesisEvent.Records)
            {
                context.Logger.LogLine($"Event ID: {record.EventId}");
                context.Logger.LogLine($"Event Name: {record.EventName}");

                string recordData = GetRecordContents(record.Kinesis);
                context.Logger.LogLine($"Record Data:");
                context.Logger.LogLine(recordData);
            }

            context.Logger.LogLine("Stream processing complete.");
        }

        private string GetRecordContents(KinesisEvent.Record streamRecord)
        {
            using (var reader = new StreamReader(streamRecord.Data, Encoding.ASCII))
            {
                return reader.ReadToEnd();
            }
        }*/
     }
}