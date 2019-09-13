using Laboratorio_4_OOP_201902.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio_4_OOP_201902
{
    public class Deck
    {

        private List<Card> cards;

        public Deck()
        {
        
        }

        public List<Card> Cards { get => cards; set => cards = value; }

        public void AddCard(Card card)
        {
           if(card == typeof(SpecialCard))
            {
                SpecialCard newCard = card;
                Cards.Add(newCard);
            } else
            {
                CombatCard newCard = card;
                Cards.Add(newCard);
            }
        }
        public void DestroyCard(int cardId)
        {
            Cards.removeAt(cardId);
        }
        public void Shuffle()
        {
            Random rnd = new Random();
            Card.OrderBy(rnd.Next());
        }
    }
}
