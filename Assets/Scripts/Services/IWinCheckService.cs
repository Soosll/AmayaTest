using UI.View;

namespace Services
{
    public interface IWinCheckService
    {
        public void Init(CardPresenter[] presenters);
        public void RunNextLevel();
    }
}