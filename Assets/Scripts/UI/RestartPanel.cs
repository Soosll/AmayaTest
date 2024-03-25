using UI.Buttons;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class RestartPanel : MonoBehaviour
    {
        [SerializeField] private RestartGameButton _restartButton;
        [SerializeField] private Image _background;

        public RestartGameButton RestartGameButton => _restartButton;
        public Image Background => _background;
    }
}