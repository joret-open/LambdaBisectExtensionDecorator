using AWSLambdaBisectExtension.Decorator;
using Decorator.Core;
using Moq;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace AWSLambdaBisectExtensionTests
{
    public class BisectTests
    {
        [Fact]
        public void ProcessData()
        {
            //Arrange
            var mockProcessor = new Mock<IComponentFunction>();
            var sut = new BisectExtensionConcreteDecorator(mockProcessor.Object, new BisectConfig(), 5, new Mock<IShardMetrics>().Object);
            var records = Enumerable.Range(0, 10).Select(i => new AWSLambdaBisectExtension.Decorator.Record(StringToStream("Record:" + i), new Dictionary<string, object>()));


            //Act
            var result = sut.Handle(records);

            //Assert
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
