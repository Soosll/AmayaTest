using Services;

namespace Main.StateMachineForGame.GameStates
{
    public class GameLoopState : IExitableState
    {
        
        private readonly IGridCreateService _gridCreateService;

        public GameLoopState(IGridCreateService gridCreateService) => 
            _gridCreateService = gridCreateService;

        public void Enter()
        {
        }

        public void Exit() => 
            _gridCreateService.Destroy();
    }
}