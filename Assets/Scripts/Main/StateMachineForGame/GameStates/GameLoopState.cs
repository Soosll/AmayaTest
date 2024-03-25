using Services;

namespace Main.StateMachineForGame.GameStates
{
    public class GameLoopState : IState
    {
        private readonly IGridCreateService _gridCreateService;
        private readonly IWinCheckService _winCheckService;

        public GameLoopState(IGridCreateService gridCreateService, IWinCheckService winCheckService)
        {
            _gridCreateService = gridCreateService;
            _winCheckService = winCheckService;
        }

        public void Enter() => 
            _winCheckService.OnRunNextLevel += DestroyGrid;

        private void DestroyGrid()
        {
            _gridCreateService.Destroy();
            _winCheckService.OnRunNextLevel -= DestroyGrid;
        }
    }
}