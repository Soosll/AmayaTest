using System.Collections.Generic;
using Card;
using Data;
using Services;
using UI.View;
using UnityEngine;

namespace Factories
{
    public class PresentersFactory : IPresentersFactory
    {
        private LevelCardsData _levelCardsData;
        
        private Dictionary<string, Sprite> _cardsDictionary = new Dictionary<string, Sprite>();

        private List<string> _chosenKeys = new List<string>();
        
        private IWinCheckService _winCheckService;

        public PresentersFactory(LevelCardsData levelCardsData, IWinCheckService winCheckService)
        {
            _winCheckService = winCheckService;
            _levelCardsData = levelCardsData;
        }

        public void Create(List<CardView> cardsView, TrueKeyChecker keyChecker)
        {
            AddCardsToDictionary();
            
            var cardKeys = _levelCardsData.GetAllKeys();

            var presenters = new List<CardPresenter>();
            
            for (int i = 0; i < cardsView.Count; i++)
            {
                var currentCard = cardsView[i];
                var randomKey = cardKeys[Random.Range(0, cardKeys.Count)];

                Sprite sprite = Object.Instantiate(_cardsDictionary[randomKey]);

                var presenter = new CardPresenter(currentCard, keyChecker, sprite, randomKey);
                
                presenters.Add(presenter);
                
               _chosenKeys.Add(randomKey);
               cardKeys.Remove(randomKey);
            }
             
            _winCheckService.Init(presenters.ToArray());
        }

        public List<string> GetChosenKeys() => 
            _chosenKeys;

        private void AddCardsToDictionary()
        {
            for (var i = 0; i < _levelCardsData.CardsData.Length; i++)
            {
                var cardData = _levelCardsData.CardsData[i];
                _cardsDictionary[cardData.CardKey] = cardData.CardSpriteValue;
            }
        }
    }
}