namespace Main.StateMachineForGame.GameStates
{
    public interface IState
    {
        public void Enter();
    }

    public interface IExitableState : IState
    {
        public void Exit();
    }
}