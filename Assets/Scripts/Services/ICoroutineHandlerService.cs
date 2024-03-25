using Main;

namespace Services
{
    public interface ICoroutineHandlerService
    {
        public ICoroutineRunner CoroutineRunner { get; set; }
    }
}