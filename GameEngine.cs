using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        // Temporary
        public string coords;

        public GameEngine(int aNoOfLevels)
        {
            int tempW;
            int tempH;

            noOfLevels = aNoOfLevels;
            random = new Random();
            tempW = random.Next(MIN_SIZE, MAX_SIZE);
            tempH = random.Next(MIN_SIZE, MAX_SIZE);
            level = new Level(tempH, tempW);
        }

        public override string ToString()
        {
            switch(gameState)
            {
                case GameState.Complete:
                    {
                        return "Congratulations, You Have Completed The Game!";
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

        private bool MoveHero(Direction aDirection)
        {
            Tile targetTile = level.hero.vision[(int)aDirection];
            
            //targetTile.X = targetTile.X;
            //targetTile.Y = targetTile.Y;

            if (targetTile is ExitTile && currentLevel == noOfLevels)
            {
                gameState = GameState.Complete;
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

        public void TriggerMovement(Direction aDirection)
        {
            level.hero.UpdateVision(level);
            MoveHero(aDirection);
            //level.hero.UpdateVision(level);

            coords = $"X:{level.hero.X}\nY:{level.hero.Y}";
        }

        public enum GameState
        {
            InProgress,
            Complete,
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

        public enum Direction
        {
            Up,
            Right,
            Down,
            Left,
            None
        }
    }

    
}
