using Amazon.Lambda.Core;
using Amazon.Lambda.KinesisEvents;
using AWSLambdaBisectExtension.Decorator;
using Decorator.Core;
using Moq;
using System;
using Xunit;

namespace AWSLambdaBisectExtensionTests
{
    public class BisectTests
    {
        [Fact]
        public void ProcessData()
        {

            //Arrange
            var mockProcessor = new Mock<IComponentFunction<KinesisEvent, ILambdaContext, string>>();
            var sut = new BisectExtensionConcreteDecorator<KinesisEvent, ILambdaContext, string>(mockProcessor.Object, new BisectConfig(), 5, new Mock<IShardMetrics>().Object);
        }
    }
}
