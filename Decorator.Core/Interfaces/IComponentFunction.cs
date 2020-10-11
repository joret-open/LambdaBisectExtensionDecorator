using System.Collections.Generic;

namespace AWSLambdaBisectExtension.Decorator
{
    //TODO actually is a good idea to have a type
    public interface IComponentFunction
    {
        IEnumerable<Record> Handle(IEnumerable<Record> records);
    }
}
