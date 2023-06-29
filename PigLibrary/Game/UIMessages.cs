using PigLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigLibrary.Game
{
    public class UIMessages
    {
        public static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to the game of pig!");

            Console.WriteLine("This is the game of pig, players roll two die (1-15)" +
                " and add up the two numbers which are added to the player's score for the round." +
                " After rolling a player can choose to roll again or pass the die." +
                " If the player rolls a 1 they loose all point for that turn and pass the die." +
                " If a player rolls two ones they loose thier score for the entire game and pass the die." +
                " The goal is to reach a total score of 100 or higher before the other player.");

            Console.WriteLine();

            Console.WriteLine("Press enter to begin!");

            Console.ReadLine();
        }

        public static void RollPrompt(int playerNumber)
        {
            Console.WriteLine();
            Console.WriteLine($"It is player {playerNumber}'s turn to roll");
            Console.WriteLine();
            Console.WriteLine("Press enter to roll");
            Console.ReadLine();
        }

        public static bool ReRollPrompt(int playerNumber)
        {
            string response;
            do
            {
                Console.Write($"Roll again? (y or n)");
                response = Console.ReadLine();

                if (response.ToLower() == "y")
                {
                    return true;
                }
                else if (response.ToLower() == "n")
                {
                    Console.WriteLine("Passing die");
                    return false;
                }
                else
                {
                    Console.WriteLine("Response was not y or n, try again");
                }


            } while (response.ToLower() != "y" || response.ToLower() != "n");

            return false;
        }


        public static void RollResults(int rollOne, int rollTwo, int playerScore)
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine($"You rolled a {rollOne} and a {rollTwo}");
            Console.WriteLine($"Your score is now {playerScore}");
            Console.WriteLine("-----------------------");

        }

        public static void WinMessage(List<PlayerInfo> players)
        {
            foreach (PlayerInfo player in players)
            {
                if (player.isWinner == true)
                {
                    Console.WriteLine();
                    Console.WriteLine($"-----------------------------------");
                    Console.WriteLine($"Player {player.PlayerNumber} wins!");
                    Console.WriteLine($"-----------------------------------");
                    Console.ReadLine();
                }
            }
        }

        public static int GetPlayerCount()
        {
            bool responseConverted;
            do
            {
                Console.WriteLine("How many players?");
                string response = Console.ReadLine();

                responseConverted = Int32.TryParse(response, out int playerCount);

                if (playerCount >= 0 && responseConverted == true)
                {
                    Console.WriteLine($"There are {playerCount} players");
                    Console.WriteLine();
                    return playerCount;
                }
                else { Console.WriteLine("Please enter a valid number greater than 0"); } 
            } while (responseConverted != true);
            return 0;
        }

        public static void DiePass()
        {
            Console.WriteLine("PassingDie");
        }

        public static bool ReplayPrompt()
        {
            string response;

            do
            {
                Console.WriteLine();
                Console.Write("Play again? (y or n)");
                response = Console.ReadLine();

                if (response.ToLower() == "y")
                {
                    return true;
                }
                else if (response.ToLower() == "n")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Response was not y or n, try again");
                } 
            } while (response.ToLower() != "y" || response.ToLower() != "n");
            return false;
        }
    }
}
