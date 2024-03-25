using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "StaticData/GridData", fileName = "GridData", order = 51)]
    public class GridSettingsData : ScriptableObject
    {
        [Header("Lines amount")]
        [SerializeField] private int _linesAmount;
        
        [Header("Columns amount")]
        [SerializeField] private int _columnsAmount;

        public int LinesAmount => _linesAmount;
        public int ColumnsAmount => _columnsAmount;
    }
}