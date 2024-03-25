using Data;
using Main.StateMachineForGame;
using Main.StateMachineForGame.GameStates;
using Services;
using UI.View;

namespace Main
{
    public class GameStartService : IGameStartService
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly LoadLevelState _loadLevelState;
        private readonly GameLoopState _gameLoopState;
        private readonly UnloadLevelState _unloadLevelState;

        private readonly ICurtainFadeService _curtainFadeService;
        private readonly IStaticDataService _staticDataService;

        public GameStartService(GameStateMachine gameStateMachine, LoadLevelState loadLevelState, GameLoopState gameLoopState, UnloadLevelState unloadLevelState, ICurtainFadeService curtainFadeService, IStaticDataService staticDataService)
        {
            _gameStateMachine = gameStateMachine;
            _loadLevelState = loadLevelState;
            _gameLoopState = gameLoopState;
            _unloadLevelState = unloadLevelState;
            _curtainFadeService = curtainFadeService;
            _staticDataService = staticDataService;
        }

        public void Init(StaticData staticData, CardView cardPrefab)
        {
            _gameStateMachine.Init(_loadLevelState, _gameLoopState, _unloadLevelState);
            _staticDataService.StaticData = staticData;
            _loadLevelState.Init(staticData, cardPrefab);
        }
        
        public void StartGame()
        {
            _gameStateMachine.Enter<LoadLevelState>();
        }
    }
}