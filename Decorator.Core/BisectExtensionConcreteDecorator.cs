using AWSLambdaBisectExtension.Decorator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator.Core
{
    public class BisectExtensionConcreteDecorator<TArg1, TArg2, TResult> : HandlerDecoratorAbstract<TArg1, TArg2, TResult>
    {
        private readonly BisectConfig _config;
        private readonly int _recordsInBatch;
        private IShardMetrics _shardMetrics;

        public BisectExtensionConcreteDecorator(IComponentFunction<TArg1, TArg2, TResult> component, BisectConfig config, int recordsInBatch, IShardMetrics shardMetrics) : base(component)
        {
            _config = config;
            _shardMetrics = shardMetrics;
        }

        public override TResult Handle(TArg1 arg1, TArg2 arg2)
        {
            if (!IsShardOpen())
                throw new ShardClosedException();

            try
            {
                return _componentFunction.Handle(arg1, arg2);
            }
            catch
            {
                if (_recordsInBatch == _config.AllowedErrorsPerBatch)
                {
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
