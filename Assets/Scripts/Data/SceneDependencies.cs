using UI;
using UI.View;
using UnityEngine;
using UnityEngine.UI;

namespace Data
{
    public class SceneDependencies : MonoBehaviour
    {
        [SerializeField] private Image _curtain;
        [SerializeField] private TaskTextObserver _taskTextObserver;
        [SerializeField] private RestartPanel restartPanel;
        
        public Image Curtain => _curtain;
        public TaskTextObserver TaskTextObserver => _taskTextObserver;
        public RestartPanel RestartPanel => restartPanel;
    }
}