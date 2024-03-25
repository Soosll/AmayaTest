using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "StaticData/GridData", fileName = "GridData", order = 51)]
    public class GridSettingsData : ScriptableObject
    {
        [SerializeField] private int _linesAmount;
        [SerializeField] private int _columnsAmount;

        public int LinesAmount => _linesAmount;
        public int ColumnsAmount => _columnsAmount;
    }
}