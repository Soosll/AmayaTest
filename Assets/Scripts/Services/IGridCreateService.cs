using System.Collections.Generic;
using UI.View;

namespace Services
{
    public interface IGridCreateService
    {
        public List<CardView> Create(CardView prefab, int lines, int columns);
        public List<CardView> CreateWithBounce(CardView prefab, int lines, int columns);
        public void Destroy();
    }
}