namespace Decorator.Core
{
    public class BisectConfig
    {
        public int MaxAllowedErrorsInShard { get; } = 10;
        public int AllowedErrorsPerBatch { get; } = 1;
    }
}