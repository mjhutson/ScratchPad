using System;
using System.Collections.Generic;
using System.Linq;

namespace ScratchPad
{
    public class Candy
    {
        public int GetChairToWarn(int prisoners, int candyPieces, int startingChair)
        {
            var startingChairIndex = startingChair - 1;

            if (candyPieces > prisoners)
            {
                var chairsPastStart = candyPieces % prisoners;

                return startingChairIndex + chairsPastStart;
            }

            return startingChairIndex + candyPieces;
        }

        public int GetChairToWarnIterative(int prisoners, int candyPieces, int startingChair)
        {
            //5, 2, 1 => 2
            var seatsGettingCandy = new List<int>();
            var currentChair = startingChair;

            for (var candyDistributed = 1; candyDistributed <= candyPieces; candyDistributed++)
            {
                var chairGettingCandy = GetChair(currentChair, prisoners, startingChair);
                seatsGettingCandy.Add(chairGettingCandy);
                Console.WriteLine(chairGettingCandy);
                currentChair++;
            }

            int chairToWarn = seatsGettingCandy.Last();

            return chairToWarn;
        }

        private int GetChair(int currentChair, int chairs, int startingChair)
        {
            if (currentChair > chairs)
            {
                return startingChair;
            }
            return currentChair;
        }
    }
}
