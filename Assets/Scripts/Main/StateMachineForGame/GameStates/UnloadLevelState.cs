using System.Collections;
using DG.Tweening;
using Services;
using UnityEngine;

namespace Main.StateMachineForGame.GameStates
{
    public class UnloadLevelState : IState
    {
        private readonly GameStateMachine _gameStateMachine;

        private readonly ICompleteLevelsCalculateService _completeLevelsCalculateService;
        private readonly ICurtainFadeService _curtainFadeService;
        private readonly ICoroutineHandlerService _coroutineHandlerService;
        private readonly ITrueKeysRemindService _trueKeysRemindService;
        private readonly IStaticDataService _staticDataService;

        public UnloadLevelState(GameStateMachine gameStateMachine, ICompleteLevelsCalculateService completeLevelsCalculateService, ICurtainFadeService curtainFadeService, ICoroutineHandlerService coroutineHandlerService, ITrueKeysRemindService trueKeysRemindService, IStaticDataService staticDataService)
        {
            _gameStateMachine = gameStateMachine;
            _completeLevelsCalculateService = completeLevelsCalculateService;
            _curtainFadeService = curtainFadeService;
            _coroutineHandlerService = coroutineHandlerService;
            _trueKeysRemindService = trueKeysRemindService;
            _staticDataService = staticDataService;
        }
        
        public void Enter()
        {
            _completeLevelsCalculateService.Clear();
            _trueKeysRemindService.Clear();
            
            _staticDataService.StaticData.SceneDependencies.RestartPanel.Background.DOFade(0, 0);
            
            var coroutineRunner = _coroutineHandlerService.CoroutineRunner;
            coroutineRunner.StartCoroutine(EndGameTimer());
        }

        private IEnumerator EndGameTimer()
        {
            _curtainFadeService.Fade(1f, 1f);
            yield return new WaitForSeconds(1f);
            _curtainFadeService.Fade(0f, 1f);
            _gameStateMachine.Enter<LoadLevelState>();
        }
    }
}