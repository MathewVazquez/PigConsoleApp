using PigLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigLibrary.Game
{
    public class GameLogic
    {
        private const int winScore = 100;
        private const int playerCountOffset = 1;
        public bool CheckForOnesInRoll(int rollOne, int rollTwo, int playerNumber, List<PlayerInfo> players) // Checks for ones and changes score accordingly
        {
            if ((rollOne == 1 && rollTwo != 1) || (rollTwo == 1 && rollOne != 1))
            {
                players[playerNumber - playerCountOffset].SkipTurn = true;
                return true;
            }
            else if (rollOne == 1 && rollTwo == 1)
            {
                players[playerNumber - playerCountOffset].TotalScore = 0;
                players[playerNumber - playerCountOffset].SkipTurn = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckForWinInRoll(List<PlayerInfo> players) // Checks if a player has reached a score of 100 or more on their turn, making them the winner
        {
            foreach (var player in players)
            {
                if (player.TotalScore >= winScore)
                {
                    player.isWinner = true;
                }
                if (player.isWinner == true)
                {
                    return true;
                }
            }
            return false;
        }

        public void ResetPlayersTurnInfo(List<PlayerInfo> players) // Resets turn based variables for next turn
        {
            foreach (var player in players)
            {
                player.TurnScore = 0;
                player.SkipTurn = false;
            }
        }

        public void AddTurnRollsToTotal(int rollOne, int rollTwo, PlayerInfo player)
        {
            player.TotalScore += rollOne + rollTwo;
        }
        public void AddTurnRollsToTurnScore(int rollOne, int rollTwo, PlayerInfo player)
        {
            player.TurnScore += rollOne + rollTwo;
        }

        public void SubtractTurnScoreFromTotal(PlayerInfo player)
        {
            player.TotalScore = player.TotalScore - player.TurnScore;
        }

    }
}
