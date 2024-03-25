using Main.StateMachineForGame;
using Main.StateMachineForGame.GameStates;
using Zenject;

namespace Installers
{
    public class GameStateInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameStateMachine>().AsSingle();
            
            BindStates();
        }

        private void BindStates()
        {
            Container.Bind<LoadLevelState>().AsSingle();
            Container.Bind<GameLoopState>().AsSingle();
            Container.Bind<UnloadLevelState>().AsSingle();
        }
    }
}