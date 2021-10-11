using System;

namespace GroupAssignment2
{
    class Program
    {
        // Frans Nilsson Lidström, Fredrik Wiman, Jennifer Björklund, Sahar Ali Abdou

        static void Main(string[] args)
        {
            /*
             * Extra extra challange, if you want to play poker
             * remove comment and comment out the other code
             */
            //Screen screen = new Screen(40, 120);

            //increasing regular buffersize to fit all text
            Console.SetBufferSize(120, 80);

            //Prinout 3 random cards
            Console.WriteLine($"\n3 randomly generated cards:");
            Console.WriteLine(new PlayingCard());
            Console.WriteLine(new PlayingCard());
            Console.WriteLine(new PlayingCard());

            Console.ReadKey();
            Console.Clear();

            DeckOfCards myDeck = new DeckOfCards();
            Console.WriteLine($"\nA freshly created deck with {myDeck.Count()} cards:");
            Console.WriteLine(myDeck);

            Console.ReadKey();
            Console.Clear();

            myDeck.Shuffle();
            Console.WriteLine($"\nA shuffled deck with {myDeck.Count()} cards:");
            Console.WriteLine(myDeck);

            Console.ReadKey();
            Console.Clear();

            //For the Challange
            
            Console.WriteLine($"\nRemove three card from the top:");
            Console.WriteLine(myDeck.GetTopCard());
            Console.WriteLine(myDeck.GetTopCard());
            Console.WriteLine(myDeck.GetTopCard());

            Console.WriteLine($"\nDeck has now {myDeck.Count()} cards:");
            Console.WriteLine(myDeck);

        }
    }
}