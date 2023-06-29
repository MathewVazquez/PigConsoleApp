using PigLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigLibrary.Game
{
    public class Gameplay
    {
        private bool foundWinner = false;
        private bool reRoll = false;
        private bool foundAOne;
        private List<PlayerInfo> players;
        private Dice dice;
        private GameLogic gameLogic;

        public Gameplay(int playerCount)
        {
            players = new List<PlayerInfo>();
            gameLogic = new GameLogic();

            for (int i = 0; i < playerCount; i++)
            {
                PlayerInfo player = new PlayerInfo();
                player.PlayerNumber = i+1;
                players.Add(player);
            }

            dice = new Dice();
        }

        public void StartGame()
        {
            UIMessages.WelcomeMessage();

            do // Loops turns until someone wins
            {
                foreach (var player in players)
                {
                    // reset turn skips and score
                    gameLogic.ResetPlayersTurnInfo(players);
                    foundAOne = false;

                    do
                    {
                        if (foundAOne == false && foundWinner == false)
                        {
                            UIMessages.RollPrompt(player.PlayerNumber);
                            var rollResult = dice.RollDice();

                            gameLogic.AddTurnRollsToTurnScore(rollResult.Item1, rollResult.Item2, player); // Adds rolls to score in this turnm

                            // Check for ones
                            foundAOne = gameLogic.CheckForOnesInRoll(rollResult.Item1, rollResult.Item2, player.PlayerNumber, players);

                            gameLogic.AddTurnRollsToTotal(rollResult.Item1, rollResult.Item2, player); // Adds the turn score to toal score



                            if (foundAOne == true && player.TotalScore >= 0)
                            {
                                gameLogic.SubtractTurnScoreFromTotal(player); // Subtracts turn score if a one is found

                            }

                            // Check win
                            foundWinner = gameLogic.CheckForWinInRoll(players);

                            // Show results
                            UIMessages.RollResults(rollResult.Item1, rollResult.Item2, player.TotalScore);

                            if (foundAOne == false && foundWinner == false)
                            {
                                reRoll = UIMessages.ReRollPrompt(player.PlayerNumber);
                            }
                        }

                        if (foundWinner == true)
                        {
                            break; // Ends loop if a winner is found
                        }

                        if (player.SkipTurn == true)
                        {
                           UIMessages.DiePass(); // Passes die if a one is found
                        }

                    } while ((reRoll == true && player.SkipTurn == false));
                }

            } while (foundWinner != true);


            UIMessages.WinMessage(players); // Display winner

        }


    }
}
