using UnityEngine;

namespace Grid
{
    public class GridCell : MonoBehaviour
    {
        [SerializeField] private GameObject _cellBackground;

        public GameObject CellBackground => _cellBackground;
    }
}