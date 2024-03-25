using System;
using UI.View;

namespace Services
{
    public interface IWinCheckService
    {
        public event Action OnRunNextLevel;
        public void Init(CardPresenter[] presenters);
        public void RunNextLevel();
    }
}