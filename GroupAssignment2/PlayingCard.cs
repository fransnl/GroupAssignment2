using System;

namespace GroupAssignment2
{
	public enum PlayingCardColor
	{
		Clubs = 0, Diamonds, Hearts, Spades         // Poker suit order, Spades highest
	}
	public enum PlayingCardValue
	{
		Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten,
		Knight, Queen, King, Ace                // Poker Value order
	}
	public class PlayingCard
	{
		Random rand = new Random();

		public PlayingCardColor Color { get; init; }
		public PlayingCardValue Value { get; init; }
		/// <summary>
		/// Constructor that generates a random card
		/// </summary>
		/// 
		public PlayingCard()
		{
			Random rand = new Random();
			Color = (PlayingCardColor)rand.Next(0,4);
			Value = (PlayingCardValue)rand.Next(2, 15);

		}
		// constructor to add specific cards to deck of cards
		public PlayingCard(PlayingCardColor color, PlayingCardValue value)
		{
			Color = color;
			Value = value;
		}

		public string BlackOrRed
		{
			get
			{
				if (Color == PlayingCardColor.Clubs || Color == PlayingCardColor.Spades)
					return "Black";

				return "Red";
			}
		}

		/// <summary>
		/// Returns "Face" for Ace,Knight, Queen, King. Otherwise it returns "Value".
		/// 
		/// </summary>
		string FaceOrValue
		{
			get
			{
                //YOUR CODE
                //to return "Face" or "Value"
                //Use switch expression

                switch (Value)
                {
                    case PlayingCardValue.Knight:
						return "Face";
                    case PlayingCardValue.Queen:
						return "Face";
                    case PlayingCardValue.King:
						return "Face";
                    case PlayingCardValue.Ace:
						return "Face";
					default:
						return "value";
                }
            }
		}
		public override string ToString() => $"{Value} of {Color}, a {BlackOrRed} {FaceOrValue} card";
	}
}

