using System.Collections.Generic;
using Data;
using UnityEngine;

namespace Grid
{
    public class GridCellsDistributer
    {
        public void Distribute(List<GridCell> gridCells, GridSettingsData gridSettingsData)
        {
            if (gridCells.Count == 0)
            {
                Debug.Log("Grid cells count = 0");
                return;
            }

            if (gridSettingsData.ColumnsAmount == 0 || gridSettingsData.LinesAmount == 0)
            {
                Debug.Log("Одно из значений сетки ячеек равно нулю");
                return;
            }
            
            var cellSize = gridCells[0].transform.localScale;
            
            var generalCellsHorizontalSize = cellSize.x * gridSettingsData.ColumnsAmount;
            var generalCellsVerticalSize = cellSize.x * gridSettingsData.LinesAmount;
            
            var spawnPointX = -GetFirstCellSpawnPoint(generalCellsHorizontalSize, cellSize);
            var spawnPointY = GetFirstCellSpawnPoint(generalCellsVerticalSize, cellSize);
            
            var horizontalSpawnInterval = generalCellsHorizontalSize / gridSettingsData.ColumnsAmount;
            var verticalSpawnInterval = generalCellsVerticalSize / gridSettingsData.LinesAmount;

            int currentCellNumber = 0;

            for (int l = 0; l < gridSettingsData.LinesAmount; l++)
            {
                for (int h = 0; h < gridSettingsData.ColumnsAmount; h++)
                {
                    var currentCell = gridCells[currentCellNumber];
                    currentCell.transform.position = new Vector2(spawnPointX, spawnPointY);
                    spawnPointX += horizontalSpawnInterval;
                    currentCellNumber++;
                }
                
                spawnPointX = GetFirstCellSpawnPoint(generalCellsHorizontalSize, cellSize);
                spawnPointY -= verticalSpawnInterval;
            }
        }

        private float GetFirstCellSpawnPoint(float generalCellsSize, Vector3 cellScale) => 
            generalCellsSize / 2 + cellScale.x / 2;
    }
}