using System.Collections.Generic;
using Card;
using Data;
using Factories;
using Services;
using UI.View;
using UnityEngine;

namespace Main.StateMachineForGame.GameStates
{
    public class LoadLevelState : IExitableState
    {
        private readonly GameStateMachine _gameStateMachine;
        
        private readonly IGridCreateService _gridCreateService;
        private readonly ICompleteLevelsCalculateService _completeLevelsCalculateService;
        private readonly IWinCheckService _winCheckService;
        private readonly IStaticDataService _staticDataService;
        private readonly ITrueKeysRemindService _trueKeysRemindService;

        private LevelCardsData[] _levelsCardsData;
        private CardView _cardPrefab;
        private GridSettingsData[] _gridsSettings;

        public LoadLevelState(GameStateMachine gameStateMachine, IGridCreateService gridCreateService, ICompleteLevelsCalculateService completeLevelsCalculateService, IWinCheckService winCheckService, IStaticDataService staticDataService, ITrueKeysRemindService trueKeysRemindService)
        {
            _gameStateMachine = gameStateMachine;
            _gridCreateService = gridCreateService;
            _completeLevelsCalculateService = completeLevelsCalculateService;
            _winCheckService = winCheckService;
            _staticDataService = staticDataService;
            _trueKeysRemindService = trueKeysRemindService;
        }

        public void Init(StaticData _staticData, CardView cardPrefab)
        {
            _levelsCardsData = _staticData.LevelsCardsData;
            _cardPrefab = cardPrefab;
            _gridsSettings = _staticData.GridsSettingsData;
        }

        public void Enter()
        {
            var currentLevelNumber = _completeLevelsCalculateService.GetAmount();
            var currentGridSettings = _gridsSettings[currentLevelNumber];
            var randomLevelData = _levelsCardsData[Random.Range(0, _levelsCardsData.Length)];

            var cards = CreateCardsView(currentGridSettings);

            var distributeSystem = new GridCardsDistributeService();
            var presentersFactory = new PresentersFactory(randomLevelData, _winCheckService);
            var trueKeyGenerator = new TrueKeyGenerator(_trueKeysRemindService);
            var trueKeyChecker = new TrueKeyChecker(trueKeyGenerator);
           
            presentersFactory.Create(cards, trueKeyChecker);
            trueKeyGenerator.Generate(presentersFactory.GetChosenKeys());
            distributeSystem.Distribute(_cardPrefab, cards, currentGridSettings);

            _staticDataService.StaticData.SceneDependencies.TaskTextObserver.UpdateText(trueKeyGenerator.TrueKey);
            
            _gameStateMachine.Enter<GameLoopState>();
        }

        private List<CardView> CreateCardsView(GridSettingsData currentGridSettings)
        {
            List<CardView> cards = new List<CardView>();

            if (_completeLevelsCalculateService.GetAmount() == 0) 
                cards = _gridCreateService.CreateWithBounce(_cardPrefab, currentGridSettings.LinesAmount, currentGridSettings.ColumnsAmount);

            else
               cards = _gridCreateService.Create(_cardPrefab, currentGridSettings.LinesAmount, currentGridSettings.ColumnsAmount);
            
            return cards;
        }

        public void Exit()
        {
        }
    }
}