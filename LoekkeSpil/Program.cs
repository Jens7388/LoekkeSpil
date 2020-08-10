using System;
using System.Collections.Generic;
using System.Linq;

namespace LoekkeSpil
{
    class Program
    {
        static int currentPlayer;
        static int roundPoints;
        static List<Player> players;

        /// <summary>
        /// Creates players with names
        /// </summary>
        private static void CreatePlayers()
        {
            Console.Clear();
            Console.WriteLine("Hvor mange spillere er med?");
            int.TryParse(Console.ReadLine(), out int noOfPlayers);
            if(noOfPlayers > 0)
            {
                players = new List<Player>();
                for(int i = 1; i <= noOfPlayers; i++)
                {
                    Console.Write($"Indtast spiller {i}'s navn: ");
                    string nameInput = Console.ReadLine();
                    Player player = new Player(nameInput, 0);
                    players.Add(player);
                }
                currentPlayer = 0;
                Turn();
            }
            else
            {
                Console.WriteLine("Ugyldigt antal spillere! Prøv igen");
                Console.ReadLine();
                CreatePlayers();
            }
        }

        /// <summary>
        /// Displays each players points in descending order
        /// </summary>
        private static void DisplayScoreBoard()
        {
            List<Player> standings = players.OrderByDescending(player => player.Points).ToList();
            foreach(Player player in standings)
            {
                Console.WriteLine($"{player.Name}: {player.Points}");
            }
        }

        /// <summary>
        /// Rolls a random number between 1 and 6
        /// </summary>
        private static void RollDice()
        {
            Random dice = new Random();
            int diceRoll = dice.Next(1, 7);
            if(diceRoll == 1)
            {
                Console.WriteLine("\nDu slog 1!, Du mister din tur, og alle dine point..");
                players[currentPlayer].Points = 0;
                Console.ReadLine();
                PassTurn();
            }
            else
            {
                Console.WriteLine($"\nDu slog: {diceRoll}");
                players[currentPlayer].Points += diceRoll;
                roundPoints += diceRoll;
            }
        }

        /// <summary>
        /// Passes the turn to the next player
        /// </summary>
        private static void PassTurn()
        {
            roundPoints = 0;
            if(currentPlayer < players.Count - 1)
            {
                currentPlayer++;
                Turn();
            }
            else
            {
                currentPlayer = 0;
                Turn();
            }
        }

        /// <summary>
        /// Allows players to play their turn
        /// </summary>
        private static void Turn()
        {
            Console.Clear();
            DisplayScoreBoard();
            Console.WriteLine($"\n{players[currentPlayer].Name}'s tur, tryk y for at slå med terningen, tryk n for at sende turen videre.");
            while(true)
            {
                string input = Console.ReadKey().Key.ToString();
                switch(input.ToLower())
                {
                    case "y":
                        RollDice();
                        break;

                    case "n":
                        Console.WriteLine($"\nDu har scoret {roundPoints} point i denne runde");
                        if(players[currentPlayer].Points >= 100)
                        {
                            Console.Clear();
                            Console.WriteLine($"{players[currentPlayer].Name} har vundet!");
                            Console.WriteLine("Endelige resultater:");
                            DisplayScoreBoard();
                            Console.ReadLine();
                            CreatePlayers();
                            break;
                        }
                        Console.ReadLine();
                        PassTurn();
                        break;

                    default:
                        Console.WriteLine("Ugyldigt input! Prøv igen");
                        break;
                }
            }
        }

        static void Main()
        {
            CreatePlayers();
        }
    }
}