using DG.Tweening;

namespace Services
{
    public class CurtainFadeService : ICurtainFadeService
    {
        private readonly IStaticDataService _staticDataService;

        public CurtainFadeService(IStaticDataService staticDataService) => 
            _staticDataService = staticDataService;

        public void Fade(float endValue, float time) => 
            _staticDataService.StaticData.SceneDependencies.Curtain.DOFade(endValue, time);
    }
}