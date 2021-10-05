using System;


namespace GroupAssignment2
{
    class DeckOfCards
    {
        const int MaxNrOfCards = 52;

        PlayingCard[] cards = new PlayingCard[MaxNrOfCards];

        public DeckOfCards()
        {
            //YOUR CODE
            //to write a constructor that generates a fresh deck of cards
            FreshDeck();
        }

        public PlayingCard this[int idx]
        {
            get
            {
                return cards[idx];
            }
        }

        /// <summary>
        /// Number of Cards in the deck
        /// </summary>
        public int Count() 
        {
            int count = 0;
            for (int i = 0; i < cards.Length; i++)
            {

                if (cards[i] != null)
                {
                    count++;
                }
            }

            return count;
        }

        /// <summary>
        /// Overriden and used by for example Console.WriteLine()
        /// </summary>
        /// <returns>string that represents the complete deck of cards</returns>
        public override string ToString()
        {
            string sRet = "";
            for (int i = 0; i < Count(); i++)
            {
                if (cards[i] != null)
                {
                    sRet += cards[i].ToString() + "\n";
                }
                else
                {
                    sRet += "NO CARD \n";
                }
                
            }
            return sRet;
        }

        /// <summary>
        /// Shuffles the deck of cards
        /// </summary>
        public void Shuffle()
        {
            var rnd = new Random(); //rnd is now a random generator - see .NET documentation


            //YOUR CODE
            //to shuffle the deck.
            //Hint: pick two cards in the deck randomly and swap them. Do this 1000 times

            int card1;
            int card2;
            PlayingCard card;

            for (int i = 0; i < 1000; i++)
            {
                card1 = rnd.Next(0,52);
                card2 = rnd.Next(0, 52);
                card = cards[card1];
                cards[card1] = cards[card2];
                cards[card2] = card;
            }
        }

        /// <summary>
        /// Initialize a fresh deck consisting of 52 cards
        /// </summary>
        public void FreshDeck()
        {
            int cardNr = 0;

            //YOUR CODE
            //to initialize a fresh deck of cards
            for (int i = 2; i < 15; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    cards[cardNr] = new PlayingCard((PlayingCardColor)j,(PlayingCardValue)i);
                    cardNr++;
                }
            }
        }

        /// <summary>
        /// Removes the top card in the deck and 
        /// </summary>
        /// <returns>The card removed from the deck</returns>
        public PlayingCard GetTopCard()
        {
            //YOUR CODE
            //to return the Top card of the deck and reduce the nr of cards in the deck
            bool notTopCard = false;
            int noNullCards = 52;
            
            while (!notTopCard)
            {
                noNullCards--;
                if (cards[noNullCards] != null)
                {
                    notTopCard = true;
                }
            }
            PlayingCard card = cards[noNullCards];
            cards[noNullCards] = null;

            return card;
        }
    }
}

