using System.Collections.Generic;
using Data;
using UI.View;

namespace Services
{
    public interface IGridCardsDistributeService
    {
        public void Distribute(CardView prefab, List<CardView> cards, GridSettingsData gridSettingsData);
    }
}