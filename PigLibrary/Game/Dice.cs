using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigLibrary.Game
{
    internal class Dice
    {
        public (int,int) RollDice() // Retruns 2 random numbers between 1-15
        {
            int rollOne;
            int rollTwo;

            Random random = new Random();

            rollOne = random.Next(1,15);
            rollTwo = random.Next(1, 15);

            return (rollOne, rollTwo);
        }

    }
}
