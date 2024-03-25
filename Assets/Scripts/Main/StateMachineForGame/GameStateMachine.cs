using System;
using System.Collections.Generic;
using Main.StateMachineForGame.GameStates;

namespace Main.StateMachineForGame
{
    public class GameStateMachine
    {
        private Dictionary<Type, IExitableState> _states;

        private IExitableState _currentState;

        public void Init(LoadLevelState loadLevelState, GameLoopState gameLoopState, UnloadLevelState unloadLevelState)
        {
            _states = new Dictionary<Type, IExitableState>()
            {
                [typeof(LoadLevelState)] = loadLevelState,
                [typeof(GameLoopState)] = gameLoopState,
                [typeof(UnloadLevelState)] = unloadLevelState
            };
        }

        public void Enter<TState>() where TState : IExitableState
        {
            _currentState?.Exit();
            var newState = _states[typeof(TState)];
            _currentState = newState;
            _currentState.Enter();
        }
    }
}