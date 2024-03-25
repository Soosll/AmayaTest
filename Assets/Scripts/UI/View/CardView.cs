using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.View
{
    public class CardView : MonoBehaviour, IPointerClickHandler
    {
        public event Action OnCellClicked;

        [SerializeField] private SpriteRenderer _spriteContainer;
        public SpriteRenderer SpriteContainer => _spriteContainer;

        public void OnPointerClick(PointerEventData eventData) => 
            OnCellClicked?.Invoke();
    }
}