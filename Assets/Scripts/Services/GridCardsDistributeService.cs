using System.Collections.Generic;
using Data;
using UI.View;
using UnityEngine;

namespace Services
{
    public class GridCardsDistributeService : IGridCardsDistributeService
    {
        public void Distribute(CardView prefab, List<CardView> cards, GridSettingsData gridSettingsData)
        {
            if (cards.Count == 0)
            {
                Debug.Log("Grid cells count = 0");
                return;
            }

            if (gridSettingsData.ColumnsAmount == 0 || gridSettingsData.LinesAmount == 0)
            {
                Debug.Log("Одно из значений сетки ячеек равно нулю");
                return;
            }

            var cardSize = prefab.transform.localScale;
            
            var generalCardsHorizontalSize = cardSize.x * gridSettingsData.ColumnsAmount;
            var generalCardsVerticalSize = cardSize.x * gridSettingsData.LinesAmount;
            
            var spawnPointX = -GetFirstCardsSpawnPoint(generalCardsHorizontalSize, cardSize);
            var spawnPointY = GetFirstCardsSpawnPoint(generalCardsVerticalSize, cardSize);
            
            var horizontalSpawnInterval = generalCardsHorizontalSize / gridSettingsData.ColumnsAmount;
            var verticalSpawnInterval = generalCardsVerticalSize / gridSettingsData.LinesAmount;

            int currentCardNumber = 0;
            
            for (int l = 0; l < gridSettingsData.LinesAmount; l++)
            {
                for (int h = 0; h < gridSettingsData.ColumnsAmount; h++)
                {
                    var currentCard = cards[currentCardNumber];
                    currentCard.transform.position = new Vector2(spawnPointX, spawnPointY);
                    spawnPointX += horizontalSpawnInterval;
                    currentCardNumber++;
                }
                
                spawnPointX = -GetFirstCardsSpawnPoint(generalCardsHorizontalSize, cardSize);
                spawnPointY -= verticalSpawnInterval;
            }
        }

        private float GetFirstCardsSpawnPoint(float generalCellsSize, Vector3 cellScale) => 
            generalCellsSize / 2 - cellScale.x / 2;
    }
}