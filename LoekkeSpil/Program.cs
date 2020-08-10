using System;

namespace LoekkeSpil
{
    class Program
    {
        static int noOfPlayers;
        static int currentPlayer;
        static int points;

        private static void rollDice()
        {
            Random dice = new Random();
            int diceRoll = dice.Next(1, 7);
            if(diceRoll == 1)
            {
                Console.WriteLine("Du slog 1!, Du mister din tur, og alle dine point..");
                points = 0;
                Console.ReadLine();
                passTurn();         
            }
            else
            {
                Console.WriteLine($"Du slog: {diceRoll}");
                points += diceRoll;
            }
        }

        private static void passTurn()
        {
            if(currentPlayer < noOfPlayers)
            {
                currentPlayer++;
                Console.Clear();
                turn();
            }
            else
            {
                currentPlayer = 1;
                Console.Clear();
                turn();
            }
        }

        private static void turn()
        {
            Console.WriteLine($"Spiller {currentPlayer}'s tur, tryk y for at slå med terningen, tryk n for at sende turen videre.");        
            while(true)
            {
                string input = Console.ReadLine();
                if(input.ToLower() == "y")
                {
                    rollDice();
                }
                else if(input.ToLower() == "n")
                {
                    Console.WriteLine($"Du har scoret {points} i denne runde");
                    Console.ReadLine();
                    passTurn();
                    break;
                }
                else
                {
                    Console.WriteLine("Ugyldigt input! Prøv igen");
                    break;
                }
            }
            
        }

        static void Main()
        {
            Console.WriteLine("Hvor mange spillere er med?");
            int.TryParse(Console.ReadLine(), out noOfPlayers);
            currentPlayer = 1;
            turn();
        }
    }
}