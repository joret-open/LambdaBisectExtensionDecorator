using System;
using System.Collections.Generic;
using System.Text;

namespace AWSLambdaBisectExtension.Decorator
{
    public interface IComponentFunction<TArg1, TArg2, TResult>
    {
        TResult Handle(TArg1 arg1, TArg2 arg2);
    }
}
