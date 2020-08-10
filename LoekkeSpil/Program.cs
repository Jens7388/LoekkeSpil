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

        private static void CreatePlayers()
        {
            Console.Clear();
            Console.WriteLine("Hvor mange spillere er med?");
            int.TryParse(Console.ReadLine(), out int noOfPlayers);
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

        private static void DisplayScoreBoard()
        {
            Console.WriteLine("Point:");
            for(int i = 0; i < players.Count; i++)
            {
                Console.WriteLine($"{players[i].Name}" + ": " + players[i].Points);
            }
        }

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

        private static void PassTurn()
        {
            roundPoints = 0;
            if(currentPlayer < players.Count -1)
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

        private static void Turn()
        {
            Console.Clear();
            DisplayScoreBoard();
            Console.WriteLine($"\n{players[currentPlayer].Name}'s tur, tryk y for at slå med terningen, tryk n for at sende turen videre.");        
            while(true)
            {
                string input = Console.ReadKey().Key.ToString();
                if(input.ToLower() == "y")
                {
                    RollDice();
                }
                else if(input.ToLower() == "n")
                {
                    Console.WriteLine($"\nDu har scoret {roundPoints} point i denne runde");
                    if(players[currentPlayer].Points >= 100)
                    {
                        Console.Clear();
                        Console.WriteLine($"{players[currentPlayer].Name} har vundet!");
                        Console.WriteLine("Endelige resultater:");
                        List<Player> finalStandings = players.OrderByDescending(player => player.Points).ToList();
                        foreach(Player player in finalStandings)
                        {
                            Console.WriteLine($"{player.Name}: {player.Points}");
                        }
                        Console.ReadLine();
                        Main();
                        break;
                    }
                    Console.ReadLine();
                    PassTurn();
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
            CreatePlayers();
            Turn();
        }
    }
}