using System;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class CardData
    {
        [SerializeField] private string _cardKey;
        [SerializeField] private Sprite _cardSpriteValue;

        public string CardKey => _cardKey;
        public Sprite CardSpriteValue => _cardSpriteValue;
    }
}