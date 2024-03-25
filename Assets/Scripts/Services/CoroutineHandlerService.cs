using Main;

namespace Services
{
    public class CoroutineHandlerService : ICoroutineHandlerService
    {
        public ICoroutineRunner CoroutineRunner { get; set; }
    }
}