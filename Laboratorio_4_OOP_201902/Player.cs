using Laboratorio_4_OOP_201902.Cards;
using Laboratorio_4_OOP_201902.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio_4_OOP_201902
{
    public class Player
    {
        //Constantes
        private const int LIFE_POINTS = 2;
        private const int START_ATTACK_POINTS = 0;

        //Static
        private static int idCounter;

        //Atributos
        private int id;
        private int lifePoints;
        private int attackPoints;
        private Deck deck;
        private Hand hand;
        private Board board;
        private SpecialCard captain;

        //Constructor
        public Player()
        {
            LifePoints = LIFE_POINTS;
            AttackPoints = START_ATTACK_POINTS;
            Deck = new Deck();
            Hand = new Hand();
            Id = idCounter++;
        }

        //Propiedades
        public int Id { get => id; set => id = value; }
        public int LifePoints
        {
            get
            {
                return this.lifePoints;
            }
            set
            {
                this.lifePoints = value;
            }
        }
        public int AttackPoints
        {
            get
            {
                return this.attackPoints;
            }
            set
            {
                this.attackPoints = value;
            }
        }
        public Deck Deck
        {
            get
            {
                return this.deck;
            }
            set
            {
                this.deck = value;
            }
        }
        public Hand Hand
        {
            get
            {
                return this.hand;
            }
            set
            {
                this.hand = value;
            }
        }
        public Board Board
        {
            get
            {
                return this.board;
            }
            set
            {
                this.board = value;
            }
        }
        public SpecialCard Captain
        {
            get
            {
                return this.captain;
            }
            set
            {
                this.captain = value;
            }
        }

        //Metodos
        public void DrawCard(int cardId = 0)
        {
            if(deck.Cards[cardId] == typeof(SpecialCard))
            {
                SpecialCard card = deck.Cards[cardId];
                hand.AddCard(card);
                deck.DestroyCard(cardId);
            } else
            {
                CombatCard card = deck.Cards[cardId];
                hand.AddCard(card);
                deck.DestroyCard(cardId);
            }
        }
        public void PlayCard(int cardId, EnumType buffRow = EnumType.None)
        {
            if (hand.Cards[cardId] == typeof(CombatCard))
            {
                CombatCard card = hand.Cards[cardId];
                Board.AddCard(card, Id);
                hand.DestroyCard(cardId);
            } else
            {
                SpecialCard card = hand.Cards[cardId];

                if (card.Type == EnumType.buff || card.Type == EnumType.buffmelee || card.Type == EnumType.buffrange || card.Type == EnumType.bufflongRange)
                {
                    Board.AddCard(card, Id, buffRow);
                } else if(card.Type == EnumType.weather)
                {
                    Board.AddCard(card, Id);
                }
                hand.DestroyCard(cardId);
            }
        }
        public void ChangeCard(int cardId)
        {
            Random rnd = new Random();
            int numberOfCardsOnDeck = deck.Cards.Count;
            int randomCardId = rnd.Next(0, numberOfCardsOnDeck - 1);

            if (hand.Cards[cardId] == typeof(CombatCard))
            {
                CombatCard card = hand.Cards[cardId];

                if (deck.Cards[randomCardId] == typeof(CombatCard))
                {
                    CombatCard newCard = deck.Cards[randomCardId];
                    hand.AddCard(newCard);
                    Deck.DestroyCard(randomCardId);
                }
                else
                {
                    SpecialCard newCard = deck.Cards[randomCardId];
                    hand.AddCard(newCard);
                    Deck.DestroyCard(randomCardId);
                }

                Deck.AddCard(card);
                hand.DestroyCard(cardId);

            }
            else
            {
                SpecialCard card = hand.Cards[cardId];
                if (deck.Cards[randomCardId] == typeof(CombatCard))
                {
                    CombatCard newCard = deck.Cards[randomCardId];
                    hand.AddCard(newCard);
                    Deck.DestroyCard(randomCardId);
                }
                else
                {
                    SpecialCard newCard = deck.Cards[randomCardId];
                    hand.AddCard(newCard);
                    Deck.DestroyCard(randomCardId);
                }

                Deck.AddCard(card);
                hand.DestroyCard(cardId);
            }
        }

        public void FirstHand()
        {
            Random rnd = new Random();
            int numberOfCardsOnDeck = deck.Cards.Count;

            for (int i = 0; i < 10; i++)
            {
                int randomCardId = rnd.Next(0, numberOfCardsOnDeck - 1);

                if(Deck.Cards[randomCardId] == typeof(SpecialCard)) {
                    SpecialCard card = Deck.Cards[randomCardId];
                    hand.AddCard(card);
                } else
                {
                    CombatCard card = Deck.Cards[randomCardId];
                    hand.AddCard(card);
                }

                deck.DestroyCard(randomCardId);
            }
        }

        public void ChooseCaptainCard(SpecialCard captainCard)
        {
            Captain = captainCard;
        }

    }
}
