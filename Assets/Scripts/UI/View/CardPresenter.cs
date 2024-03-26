using System;
using Card;
using DG.Tweening;
using UnityEngine;

namespace UI.View
{
    public class CardPresenter
    {
        public event Action OnTrueKeyWasChosen; 

        private readonly TrueKeyChecker _trueKeyChecker;
        private readonly Sprite _sprite;
        private readonly CardView _card;

        private readonly string _cardKey;
        
        public CardPresenter(CardView card, TrueKeyChecker trueKeyChecker, Sprite sprite, string cardKey)
        {
            _trueKeyChecker = trueKeyChecker;
            _sprite = sprite;
            _cardKey = cardKey;
            _card = card;

            SetView();
            Subscribe();
        }

        private void SetView()
        {
            if (_sprite.border.x != 0)
                _card.SpriteContainer.transform.Rotate(0,0,-90); 

            _card.SpriteContainer.sprite = _sprite;
        }

        private void Subscribe() => 
            _card.OnCellClicked += Check;

        private void Check()
        {
            
            if (_trueKeyChecker.Check(_cardKey))
                _card.SpriteContainer.transform.DOShakeScale(0.5f, 0.5f).onComplete += () => OnTrueKeyWasChosen?.Invoke();

            else
                _card.SpriteContainer.transform.DOShakePosition(0.3f, 0.1f).SetEase(Ease.Linear);
        }
    }
}