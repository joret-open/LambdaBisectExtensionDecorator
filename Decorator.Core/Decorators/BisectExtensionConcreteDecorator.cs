using AWSLambdaBisectExtension.Decorator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator.Core
{
    public class BisectExtensionConcreteDecorator : HandlerDecoratorAbstract
    {
        private readonly BisectConfig _config;
        private readonly int _recordsInBatch;
        private IShardMetrics _shardMetrics;

        public BisectExtensionConcreteDecorator(IComponentFunction component, BisectConfig config, int recordsInBatch, IShardMetrics shardMetrics) : base(component)
        {
            _config = config;
            _shardMetrics = shardMetrics;
            _recordsInBatch = recordsInBatch;
        }

        public override IEnumerable<Record> Handle(IEnumerable<Record> records)
        {
            if (!IsShardOpen())
                throw new ShardClosedException();

            try
            {
                return _componentFunction.Handle(records);
            }
            catch
            {
                if (_recordsInBatch == _config.AllowedErrorsPerBatch)
                {
                    Console.WriteLine("===Minimum errors in records accepted, continue processing without exception");
                    return default;
                }
                else
                {
                    throw;
                }
            }
        }

         private bool IsShardOpen()
        {
            return _shardMetrics.GetMetricsInPeriod() < _config.MaxAllowedErrorsInShard;
        }
    }
}
