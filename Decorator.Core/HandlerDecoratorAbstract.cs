using System;
using System.Collections.Generic;
using System.Text;

namespace AWSLambdaBisectExtension.Decorator
{
    public abstract class HandlerDecoratorAbstract<TArg1, TArg2, TResult> : IComponentFunction<TArg1, TArg2, TResult>
    {
        public HandlerDecoratorAbstract(IComponentFunction<TArg1, TArg2, TResult> component) 
        {
            _componentFunction = component;
        }

        protected readonly IComponentFunction<TArg1, TArg2, TResult> _componentFunction;
        public abstract TResult Handle(TArg1 arg1, TArg2 arg2);
    }
}
