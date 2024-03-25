using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "StaticData/LevelTasks", fileName = "LevelTaskData", order = 51)]
    public class LevelCardsData : ScriptableObject
    {
        [SerializeField] private CardData[] _cardsData;

        public CardData[] CardsData => _cardsData;

        public List<string> GetAllKeys()
        {
            var keysList = new List<string>();
            
            foreach (var cardData in _cardsData)
                keysList.Add(cardData.CardKey);

            return keysList;
        }

        public List<Sprite> GetAllSprites()
        {
            var spritesList = new List<Sprite>();
            
            foreach (var cardData in _cardsData)
                spritesList.Add(cardData.CardSpriteValue);

            return spritesList;
        }
    }
}