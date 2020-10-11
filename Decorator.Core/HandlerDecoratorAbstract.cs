using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AWSLambdaBisectExtension.Decorator
{
    public abstract class HandlerDecoratorAbstract : IComponentFunction
    {
        protected readonly IComponentFunction _componentFunction;

        public HandlerDecoratorAbstract(IComponentFunction component)
        {
            _componentFunction = component;
        }

        public abstract IEnumerable<Record> Handle(IEnumerable<Record> records);
    }
}
