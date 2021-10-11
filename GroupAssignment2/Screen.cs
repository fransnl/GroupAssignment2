using System;

namespace GroupAssignment2
{
    class Poker
    {
        static DeckOfCards deckOfCards = new DeckOfCards();
        public static PlayingCard[] board = new PlayingCard[5];
        public static PlayingCard[] p1 = new PlayingCard[2];
        public static PlayingCard[] p2 = new PlayingCard[2];
        public static int pot = 0;
        public static int p1Stack = 2000;
        public static int p2Stack = 2000;

        public Poker()
        {
            deckOfCards.Shuffle();
            Deal();
        }

        public static void DrawStacks() 
        {
            for (int i = 0; i < p1Stack.ToString().Length; i++)
            {
                Screen.screen[2 * 120+i] = p1Stack.ToString()[i].ToString();
            }
            for (int i = 0; i < p2Stack.ToString().Length; i++)
            {
                Screen.screen[3 * 120 + i] = p2Stack.ToString()[i].ToString();
            }
        }

        public static void DrawPoints(int p1, int p2)
        {
            for (int i = 0; i < p1.ToString().Length; i++)
            {
                Screen.screen[5 * 120 + i] = p1.ToString()[i].ToString();
            }
            for (int i = 0; i < p2.ToString().Length; i++)
            {
                Screen.screen[6 * 120 + i] = p2.ToString()[i].ToString();
            }
        }

        public static int cNr = 0;
        public static bool[] isItShowing = new bool[5];

        static void Deal() 
        {
            for (int i = 0; i < 5; i++)
            {
                board[i] = deckOfCards.GetTopCard();
            }
            for (int i = 0; i < 2; i++)
            {
                p1[i] = deckOfCards.GetTopCard();
            }
            for (int i = 0; i < 2; i++)
            {
                p2[i] = deckOfCards.GetTopCard();
            }
        }

        public static void Input()
        {
            ConsoleKeyInfo key = Console.ReadKey(true);


            if (key.Key == ConsoleKey.Enter)
            {
                cNr++;

                switch (cNr)
                {
                    case 1:
                        if (p1Stack > 0 && p2Stack > 0)
                        {
                            p1Stack -= 500;
                            p2Stack -= 500;
                            pot += 1000;
                        }
                        isItShowing[0] = true;
                        isItShowing[1] = true;
                        isItShowing[2] = true;
                        break;
                    case 2:
                        isItShowing[3] = true;
                        break;
                    case 3:
                        isItShowing[4] = true;
                        WhoWins(p1, p2);
                        break;
                    case 4:
                        cNr = 0;
                        for (int i = 0; i < 5; i++)
                        {
                            isItShowing[i] = false;
                            deckOfCards = new DeckOfCards();
                            deckOfCards.Shuffle();
                            Deal();
                        }
                        break;
                    default:
                        break;
                }
            }

            while (Console.KeyAvailable)
                Console.ReadKey(false);
        }

        public static void DrawTurnCard(int X, int Y)
        {
            int p = ((X - 1) * 120) + Y;

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    Screen.screen[p] = "#";
                    p++;
                }
                p += 117;
            }
        }
        
        public static void DrawCards()
        {
            Screen.DrawPos(2, 54, p1[0]);
            Screen.DrawPos(2, 59, p1[1]);
            Screen.DrawPos(16, 54, p2[0]);
            Screen.DrawPos(16, 59, p2[1]);
            Screen.DrawPos(9, 48, board[0]);
            Screen.DrawPos(9, 52, board[1]);
            Screen.DrawPos(9, 56, board[2]);
            Screen.DrawPos(9, 60, board[3]);
            Screen.DrawPos(9, 64, board[4]);
        }

        static int Rules(PlayingCard[] player) 
        {
            PlayingCard[] hand = new PlayingCard[7];
            int heart = 0;
            int spade = 0;
            int club = 0;
            int diamond = 0;
            int aPos = 0;
            int points = 0;
            bool Pair = false;
            bool twoPair = false;
            bool threePair = false;
            bool straight = false;
            bool flush = false;
            bool fullHouse = false;
            bool fourPair = false;
            bool straightFlush = false;
            bool rStraightFlush = false;

            for (int i = 0; i < 5; i++)
            {
                hand[aPos] = board[aPos];
                aPos++;
            }

            for (int i = 0; i < 2; i++)
            {
                hand[aPos] = player[i];
                aPos++;
            }

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if ((int)hand[i].Value < (int)hand[j].Value)
                    {
                        PlayingCard switchCards = hand[j];
                        hand[j] = hand[i];
                        hand[i] = switchCards;
                    }
                }
            }

            bool pairValue = false;



            //TwoPair, Pair

            PlayingCard[] pair = new PlayingCard[2];
            for (int i = 1; i < 7; i++)
            {
                if ((int)hand[i - 1].Value == (int)hand[i].Value && pairValue == true)
                {
                    twoPair = true;
                }
                if ((int)hand[i - 1].Value == (int)hand[i].Value)
                {
                    Pair = true;
                    pair[0] = hand[i - 1];
                    pair[1] = hand[i];
                    pairValue = true;
                }
            }

            //ThreePair
            for (int i = 2; i < 7; i++)
            {
                if ((int)hand[i - 1].Value == (int)hand[i].Value && (int)hand[i - 2].Value == (int)hand[i].Value)
                {
                    threePair = true;
                }
            }
            //FourPair
            for (int i = 3; i < 7; i++)
            {
                if ((int)hand[i - 1].Value == (int)hand[i].Value && (int)hand[i - 2].Value == (int)hand[i].Value && (int)hand[i - 3].Value == (int)hand[i].Value)
                {
                    fourPair = true;
                }
            }

            //check straight, straightFlush
            for (int i = 0; i < 2; i++)
            {
                if ((int)hand[i].Value == (int)hand[i+1].Value - 1 
                    && (int)hand[i].Value == (int)hand[i + 2].Value - 2 
                    && (int)hand[i].Value == (int)hand[i + 3].Value - 3 
                    && (int)hand[i].Value == (int)hand[i + 4].Value - 4)
                {
                    straight = true;
                    
                    if ((int)hand[i].Color == (int)hand[i + 1].Color - 1
                    && (int)hand[i].Value == (int)hand[i + 2].Color - 2
                    && (int)hand[i].Value == (int)hand[i + 3].Color - 3
                    && (int)hand[i].Value == (int)hand[i + 4].Color - 4)
                    {
                        straightFlush = true;
                    }
                }
            }
            if ((int)hand[0].Value == 2 
                && (int)hand[1].Value == 3
                && (int)hand[2].Value == 4
                && (int)hand[3].Value == 5
                && (int)hand[6].Value == 14)
            {
                straight = true;

                if ((int)hand[1].Color == (int)hand[0].Color
                && (int)hand[2].Color == (int)hand[0].Color
                && (int)hand[3].Color == (int)hand[0].Color
                && (int)hand[6].Color == (int)hand[0].Color)
                {
                    straightFlush = true;
                }
            }


            //check flush
            for (int i = 0; i < 7; i++)
            {
                if (hand[i].Color == PlayingCardColor.Hearts)
                {
                    heart++;
                    if (heart >= 5)
                    {
                        flush = true;
                    }
                }
                if (hand[i].Color == PlayingCardColor.Spades)
                {
                    spade++;
                    if (spade >= 5)
                    {
                        flush = true;
                    }
                }
                if (hand[i].Color == PlayingCardColor.Clubs)
                {
                    club++;

                    if (club >= 5)
                    {
                        flush = true;
                    }
                }
                if (hand[i].Color == PlayingCardColor.Diamonds)
                {
                    diamond++;

                    if (diamond >= 5)
                    {
                        flush = true;
                    }
                }
            }

            //fullHouse
            for (int i = 2; i < 7; i++)
            {
                if ((int)hand[i - 1].Value == (int)hand[i].Value && (int)hand[i - 2].Value == (int)hand[i].Value && pair[0].Value != hand[i].Value)
                {
                    fullHouse = true;
                }
            }

            //straightflush

            if ((int)hand[2].Value == 10 && (int)hand[3].Value == 11 && (int)hand[4].Value == 12 && (int)hand[5].Value == 13 && (int)hand[6].Value == 14)
            {
                if (hand[2].Color == hand[3].Color && hand[2].Color == hand[4].Color && hand[2].Color == hand[5].Color && hand[2].Color == hand[6].Color)
                {
                    rStraightFlush = true;
                }
            }
            

            if (Pair == true)
            {
                points += 100;
            }
            if (twoPair == true)
            {
                points = 0;
                points += 200;
            }
            if (threePair == true)
            {
                points = 0;
                points += 300;
            }
            if (straight == true)
            {
                points = 0;
                points += 400;
            }
            if (flush == true)
            {
                points = 0;
                points += 500;
            }
            if (fullHouse == true)
            {
                points = 0;
                points += 600;
            }
            if (fourPair == true)
            {
                points = 0;
                points += 700;
            }
            if (straightFlush == true)
            {
                points = 0;
                points += 800;
            }
            if (rStraightFlush == true)
            {
                points = 0;
                points += 900;
            }

            for (int i = 0; i < 5; i++)
            {
                points += (int)hand[i].Value;
            }

            return points;
        }

        static void WhoWins(PlayingCard[] player1, PlayingCard[] player2)
        {
            int p1 = Rules(player1);
            int p2 = Rules(player2);

            DrawPoints(p1, p2);

            if (p2 < p1 && p1Stack < 4000)
            {
                pot = 0;
                p1Stack += 1000;
            }
            if (p1 < p2 && p2Stack < 4000)
            {
                pot = 0;
                p2Stack += 1000;

            }
            if (p1 == p2)
            {
                p1Stack += pot/2;
                p2Stack += pot/2;
                pot = 0;
            }
        }
    }


    class Draw 
    {
        public static string[] cards = new string[4];

        string heart = "\u2665";
        string spade = "\u2660";
        string club = "\u2663";
        string diamond = "\u2666";

        public Draw(PlayingCard card)
        {
            string value = " "; 

            if ((int)card.Value < 10)
            {
                value = ((int)card.Value).ToString();
            }
            else
            {
                switch ((int)card.Value)
                {
                    case 10:
                        value = "T";
                        break;
                    case 11:
                        value = "J";
                        break;
                    case 12:
                        value = "Q";
                        break;
                    case 13:
                        value = "K";
                        break;
                    case 14:
                        value = "A";
                        break;

                    default:
                        break;
                }
            }

            cards[0] = club + club + club +
                        club + value + club +
                       club + club + club;
            
            cards[1] = diamond + diamond + diamond +
                        diamond + value + diamond +
                       diamond + diamond + diamond;
            
            cards[2] = heart + heart + heart +
                        heart + value + heart +
                       heart + heart + heart;
            
            cards[3] = spade + spade + spade +
                        spade + value + spade +
                       spade + spade + spade;
        }
    }

    class Screen
    {
        bool notRunning = false;
        public static string[] screen;


        public Screen(int X, int Y)
        {
            int hand = 0;
            Console.SetWindowSize(Y, X);
            screen = new string[40 * 120];
            Poker poker = new Poker();

            while (!notRunning)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Screen.screen[0 * 120] = hand.ToString();
                Poker.Input();
                Poker.DrawStacks();
                Poker.DrawCards();
                Screen.DrawScreen();
                hand++;
            }
        }

        public static void DrawScreen() 
        {
            int p = 0;

            int pos = 48;
            for (int i = 0; i < 5; i++)
            {
                if (!Poker.isItShowing[i])
                {
                    Poker.DrawTurnCard(9, pos);
                }
                pos += 4;
            }

            for (int x = 0; x < 40; x++)
            {
                for (int y = 0; y < 120; y++)
                {
                    if (screen[p] == "\u2665" || screen[p] == "\u2666")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    if (screen[p] == "\u2663" || screen[p] == "\u2660")
                    {
                        Console.ForegroundColor = ConsoleColor.Black;

                    }
                    if (screen[p] == null)
                    {
                        screen[p] = " ";
                    }
                    Console.SetCursorPosition(y, x);
                    Console.Write(screen[p]);
                    p++;
                }
            }

        }

        public static void DrawPos(int X, int Y, PlayingCard card) 
        {
            int s = 0;
            int p = ((X - 1) * 120) + Y;
            Draw cards = new Draw(card);

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    screen[p] = Draw.cards[(int)card.Color][s].ToString();
                    s++;
                    p++;
                }
                p += 117;
            }
        }
    }
}
