using System.Collections.Generic;
using DG.Tweening;
using UI.View;
using UnityEngine;

namespace Services
{
    public class GridCreateService : IGridCreateService
    {
        List<CardView> _spawnedCards = new List<CardView>();
        
        public List<CardView> Create(CardView prefab, int lines, int columns)
        {
            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                   var spawnedCard = Object.Instantiate(prefab);
                   _spawnedCards.Add(spawnedCard);
                }
            }

            return _spawnedCards;
        }

        public List<CardView> CreateWithBounce(CardView prefab, int lines, int columns)
        {
            _spawnedCards = Create(prefab, lines, columns);

            var cardScale = prefab.transform.localScale;
            
            foreach (var spawnedCard in _spawnedCards)
            {
                spawnedCard.transform.localScale = Vector3.zero;
                spawnedCard.transform.DOScale(cardScale, 1f);
            }
            
            return _spawnedCards;
        }
        
        public void Destroy()
        {
            foreach (var card in _spawnedCards)
                Object.Destroy(card.gameObject);
            
            _spawnedCards.Clear();
        }
    }
}