using DG.Tweening;
using TMPro;
using UnityEngine;

namespace UI.View
{
    public class TaskTextObserver : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        private void Start() => 
            Show();

        private void Show() => 
            _text.DOFade(1f, 1f);

        public void UpdateText(string trueKey) => 
            _text.text = $"Find: {trueKey}";
    }
}