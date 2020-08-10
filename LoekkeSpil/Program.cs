using System;
using System.Collections.Generic;

namespace LoekkeSpil
{
    class Program
    {
        static int currentPlayer;
        static int roundPoints;
        static List<Player> players;

        private static void createPlayers()
        {
            Console.Clear();
            Console.WriteLine("Hvor mange spillere er med?");
            int noOfPlayers;
            int.TryParse(Console.ReadLine(), out noOfPlayers);
            players = new List<Player>();
            for(int i = 1; i <= noOfPlayers; i++)
            {
                Console.Write($"Indtast spiller {i}'s navn: ");
                string nameInput = Console.ReadLine();
                Player player = new Player(nameInput, 0);
                players.Add(player);
            }
            currentPlayer = 0;
        }

        private static void displayScoreBoard()
        {
            Console.WriteLine("Point:");
            for(int i = 0; i < players.Count; i++)
            {
                Console.WriteLine($"{players[i].Name}" + ": " + players[i].Points);
            }
        }

        private static void rollDice()
        {
            Random dice = new Random();
            int diceRoll = dice.Next(1, 7);
            if(diceRoll == 1)
            {
                Console.WriteLine("\nDu slog 1!, Du mister din tur, og alle dine point..");
                players[currentPlayer].Points = 0;
                Console.ReadLine();
                passTurn();         
            }
            else
            {
                Console.WriteLine($"\nDu slog: {diceRoll}");
                players[currentPlayer].Points += diceRoll;
                roundPoints += diceRoll;
            }
        }

        private static void passTurn()
        {
            roundPoints = 0;
            if(currentPlayer < players.Count -1)
            {
                currentPlayer++;
                turn();
            }
            else
            {
                currentPlayer = 0;
                turn();
            }
        }

        private static void turn()
        {
            Console.Clear();
            displayScoreBoard();
            Console.WriteLine($"\n{players[currentPlayer].Name}'s tur, tryk y for at slå med terningen, tryk n for at sende turen videre.");        
            while(true)
            {
                string input = Console.ReadKey().Key.ToString();
                if(input.ToLower() == "y")
                {
                    rollDice();
                }
                else if(input.ToLower() == "n")
                {
                    Console.WriteLine($"\nDu har scoret {roundPoints} point i denne runde");
                    if(players[currentPlayer].Points >= 100)
                    {
                        Console.WriteLine("Tillykke! Du har vundet");
                        Console.ReadLine();
                        Main();
                        break;
                    }
                    Console.ReadLine();
                    passTurn();
                    break;
                }
                else
                {
                    Console.WriteLine("Ugyldigt input! Prøv igen");
                }
            }        
        }

        static void Main()
        {
            createPlayers();
            turn();
        }
    }
}