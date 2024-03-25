using System.Collections.Generic;
using Data;
using UnityEngine;

namespace Grid
{
    public class GridCreator : MonoBehaviour
    {
        [SerializeField] private GridCell _gridPartPrefab;
        [SerializeField] private GridSettingsData gridSettingsData;
        
        private List<GridCell> _spawnedCells = new List<GridCell>();

        public void Create(int lines, int columns)
        {
            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                   var spawnedCell = Instantiate(_gridPartPrefab);
                   _spawnedCells.Add(spawnedCell);
                }
            }
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                Create(gridSettingsData.LinesAmount,gridSettingsData.ColumnsAmount);
                var distributer = new GridCellsDistributer();
                distributer.Distribute(_spawnedCells, gridSettingsData);
            }
        }
    }
}