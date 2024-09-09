using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Hero_Adventure
{
    public class GameEngine
    {
        private Level level;
        private int noOfLevels;
        private Random random;

        private int currentLevel;

        const int MIN_SIZE = 10;
        const int MAX_SIZE = 20;

        GameState gameState = GameState.InProgress;

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
            switch(gameState)
            {
                case GameState.Compleate:
                    {
                        return "Congradulation, You Have Compleated The Game!";
                    }
                case GameState.InProgress:
                    {

                        return level.ToString();
                    }
                default:
                    {
                        return "";
                    }
            }
        }

        private bool MoveHero(Level.Direction aDirection)
        {
            int theDirection = Convert.ToInt32(aDirection);

            Tile targetTile = level.hero.vision[theDirection];

            if (targetTile is ExitTile && currentLevel == noOfLevels)
            {
                gameState = GameState.Compleate;
                return false;
            }
            else if(targetTile is ExitTile)
            {
                NextLevel();
                return true;
            }
            else if (targetTile is EmptyTile)
            {
                level.SwopTiles(level.hero, targetTile);
                level.hero.UpdateVision(level);

                return true;
            }
            else
            {
                return false;
            }
        }

        public void TriggerMovement(Level.Direction aDirection)
        {
            MoveHero(aDirection);
        }

        public enum GameState
        {
            InProgress,
            Compleate,
            GameOver
        }

        public void NextLevel()
        {
            currentLevel++;

            int tempW;
            int tempH;
            HeroTile tempHero;
            tempHero = level.hero;

            tempW = random.Next(MAX_SIZE, MAX_SIZE);
            tempH = random.Next(MAX_SIZE, MAX_SIZE);
            level = new Level(tempH, tempW, tempHero);
        }
    }
}
