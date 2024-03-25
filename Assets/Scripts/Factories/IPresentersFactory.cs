using System.Collections.Generic;
using Card;
using UI.View;

namespace Factories
{
    public interface IPresentersFactory
    {
        public void Create(List<CardView> cardsView, TrueKeyChecker keyChecker);
        public List<string> GetChosenKeys();
    }
}