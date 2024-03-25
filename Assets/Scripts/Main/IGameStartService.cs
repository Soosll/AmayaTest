using Data;
using UI.View;

namespace Main
{
    public interface IGameStartService
    {
        public void Init(StaticData staticData, CardView cardPrefab);
        public void StartGame();
    }
}