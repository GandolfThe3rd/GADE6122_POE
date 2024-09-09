using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hero_Adventure
{
    internal class GameEngine
    {
        private Level level;
        private int noOfLevels;
        private Random random;

        const int MIN_SIZE = 10;
        const int MAX_SIZE = 20;

        public GameEngine(int aNoOfLevels)
        {
            int tempW;
            int tempH;

            noOfLevels = aNoOfLevels;
            random = new Random();
            tempW = random.Next(MAX_SIZE, MAX_SIZE);
            tempH = random.Next(MAX_SIZE, MAX_SIZE);
            level = new Level(tempH, tempW);
            // Fix this --------------------------------------------------------------------------------------------------------
        }

        public override string ToString()
        {
            return level.ToString();
        }
    }
}
