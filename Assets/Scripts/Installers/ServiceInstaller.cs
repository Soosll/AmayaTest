using Main;
using Services;
using Zenject;

namespace Installers
{
    public class ServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ICurtainFadeService>().To<CurtainFadeService>().AsSingle();
            Container.Bind<ICompleteLevelsCalculateService>().To<CompleteLevelsCalculateService>().AsSingle();
            Container.Bind<IGridCreateService>().To<GridCreateService>().AsSingle();
            Container.Bind<IGridCardsDistributeService>().To<GridCardsDistributeService>().AsSingle();
            Container.Bind<IGameStartService>().To<GameStartService>().AsSingle();
            Container.Bind<IWinCheckService>().To<WinCheckService>().AsSingle();
            Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
            Container.Bind<ICoroutineHandlerService>().To<CoroutineHandlerService>().AsSingle();
            Container.Bind<ITrueKeysRemindService>().To<TrueKeysRemindService>().AsSingle();
        }
    }
}