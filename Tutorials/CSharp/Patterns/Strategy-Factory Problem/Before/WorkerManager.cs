namespace CSharp.Patterns.Before
{
    class WorkerManager
    {
        public IWorkerCreateStrategy CreateStrategy { get; set; }

        public WorkerManager(IWorkerCreateStrategy createStrategy)
        {
            CreateStrategy = createStrategy;
        }

        public 
    }

    internal interface IWorkerCreateStrategy
    {
        Worker CreateWorker(int probability);
    }

    internal interface IWorker
    {
        bool DoWork();
    }

    internal class Worker : IWorker
    {
        public bool DoWork()
        {
            // Do work return true if finished
            return true;
        }
    }
}
