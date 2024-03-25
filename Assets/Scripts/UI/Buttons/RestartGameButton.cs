using Main.StateMachineForGame;
using Main.StateMachineForGame.GameStates;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Buttons
{
    public class RestartGameButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        
        private GameStateMachine _gameStateMachine;

        [Inject]
        public void Construct(GameStateMachine gameStateMachine) => 
            _gameStateMachine = gameStateMachine;

        private void OnEnable() => 
            _button.onClick.AddListener(EnterUnloadState);

        private void EnterUnloadState() => 
            _gameStateMachine.Enter<UnloadLevelState>();

        private void OnDisable() => 
            _button.onClick.RemoveListener(EnterUnloadState);
    }
}