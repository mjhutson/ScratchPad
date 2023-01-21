using System;
namespace ScratchPad
{
    public class UtopianTree
    {
        public int Grow(int height, int currentCycle, int cyclesToGrow)
        {
            if (currentCycle > cyclesToGrow)
            {
                return height;
            }
            else if (currentCycle % 2 == 1)
            {
                height *= 2;
                Console.WriteLine($"height: {height}, cycles: {currentCycle}");
                return Grow(height, ++currentCycle, cyclesToGrow);
            }
            else if (currentCycle % 2 == 0)
            {
                height++;
                Console.WriteLine($"height: {height}, cycles: {currentCycle}");
                return Grow(height, ++currentCycle, cyclesToGrow);
            }

            return height;
        }

        public int utopianTree(int n)
        {
            var initialHeight = 1;

            return Grow(initialHeight, 1, n);
        }
    }
}
