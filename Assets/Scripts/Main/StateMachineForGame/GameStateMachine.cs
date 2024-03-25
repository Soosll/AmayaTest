using System;
using System.Collections.Generic;
using Main.StateMachineForGame.GameStates;

namespace Main.StateMachineForGame
{
    public class GameStateMachine
    {
        private Dictionary<Type, IState> _states;

        private IState _currentState;

        public void Init(LoadLevelState loadLevelState, GameLoopState gameLoopState, UnloadLevelState unloadLevelState)
        {
            _states = new Dictionary<Type, IState>()
            {
                [typeof(LoadLevelState)] = loadLevelState,
                [typeof(GameLoopState)] = gameLoopState,
                [typeof(UnloadLevelState)] = unloadLevelState
            };
        }

        public void Enter<TState>() where TState : IState
        {
            var newState = _states[typeof(TState)];
            _currentState = newState;
            _currentState.Enter();
        }
    }
}