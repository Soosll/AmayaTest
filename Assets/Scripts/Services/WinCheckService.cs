using System;
using DG.Tweening;
using Extensions;
using Main.StateMachineForGame;
using Main.StateMachineForGame.GameStates;
using UI.View;

namespace Services
{
    public class WinCheckService : IWinCheckService
    {
        public event Action OnRunNextLevel; 

        private readonly GameStateMachine _gameStateMachine;
        
        private readonly IStaticDataService _staticDataService;
        private readonly ICompleteLevelsCalculateService _completeLevelsCalculateService;

        private CardPresenter[] _presenters;

        public WinCheckService(GameStateMachine gameStateMachine, IStaticDataService staticDataService, ICompleteLevelsCalculateService completeLevelsCalculateService)
        {
            _gameStateMachine = gameStateMachine;
            _staticDataService = staticDataService;
            _completeLevelsCalculateService = completeLevelsCalculateService;
        }

        public void Init(CardPresenter[] presenters)
        {
            _presenters = presenters;

            foreach (var presenter in _presenters)
                presenter.OnTrueKeyWasChosen += RunNextLevel;
        }

        public void RunNextLevel()
        {
            _completeLevelsCalculateService.IncreaseAmount();
            
            if (_completeLevelsCalculateService.GetAmount() < _staticDataService.StaticData.GridsSettingsData.Length)
            {
                OnRunNextLevel?.Invoke();
                _gameStateMachine.Enter<LoadLevelState>();
                return;                
            }

            var restartPanel = _staticDataService.StaticData.SceneDependencies.RestartPanel;
            
            OnRunNextLevel?.Invoke();

            restartPanel.transform.Activate();
            restartPanel.Background.DOFade(0.8f, 1);
        }
    }
}