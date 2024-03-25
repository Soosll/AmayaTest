using UnityEngine;

namespace Data
{
    public class StaticData : MonoBehaviour
    {
        [SerializeField] private LevelCardsData[] _levelCardsDatas;
        [SerializeField] private GridSettingsData[] _gridSettingsDatas;
        [SerializeField] private SceneDependencies _sceneDependencies;

        public LevelCardsData[] LevelsCardsData => _levelCardsDatas;
        public GridSettingsData[] GridsSettingsData => _gridSettingsDatas;
        public SceneDependencies SceneDependencies => _sceneDependencies;
    }
}