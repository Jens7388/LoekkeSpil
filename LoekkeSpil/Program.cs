using System;

namespace LoekkeSpil
{
    class Program
    {
        private int noOfPlayers;
        private int currentPlayer;
        private int points;
        private void rollDice()
        {
            Random dice = new Random();
            int diceRoll = dice.Next(1, 7);
            if(diceRoll == 1)
            {
                Console.WriteLine("Du slog 1!, Du mister din tur, og alle dine point..");
            }
            else
            {

            }
            Console.WriteLine(diceRoll);
            Console.ReadLine();
        }
        private void passTurn()
        {
            if(currentPlayer < noOfPlayers)
            {
                currentPlayer++;
                Console.Clear();
                Console.WriteLine($"Spiller {currentPlayer}'s tur, tryk y for at slå med terningen, tryk n for at sende turen videre.");
            }
        }

        void Main()
        {
            Console.WriteLine("Hvor mange spillere er med?");
            int noOfPlayers;
            int.TryParse(Console.ReadLine(), out noOfPlayers);
            currentPlayer = 1;
            Console.WriteLine($"Spiller {currentPlayer}'s tur, tryk y for at slå med terningen, tryk n for at sende turen videre.");
            string input = Console.ReadLine();
            if(input.ToLower() == "y")
            {
                rollDice();
            }
            else if(input.ToLower() == "n")
            {
                passTurn();
            }
            else
            {
                Console.WriteLine("Ugyldigt input! Prøv igen");
            }
        }
    }
}