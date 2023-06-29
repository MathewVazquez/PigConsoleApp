using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigLibrary.Models
{
    public class PlayerInfo
    {
        public int PlayerNumber { get; set; } // The player's number
        public int TurnScore { get; set; } // The player's score in the current turn
        public int TotalScore { get; set; } // The player's total game score
        public bool SkipTurn { get; set; } // Bool to skip turn
        public bool isWinner { get; set; } // Bool to tell if the player is a winner
    }
}
