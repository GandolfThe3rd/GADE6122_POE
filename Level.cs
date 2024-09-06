using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hero_Adventure
{
    public class Level
    {
        private Tile[,] tiles;
        private int width;
        private int height;

        public int Width
        { 
            get { return width; }
            set {  width = value; } 
        }
        public int Height
        { 
            get { return height; }
            set { height = value; } 
        }

        public Level(int width, int height)
        {
            Width = width;
            Height = height;

            tiles = new Tile[Height, Width];
            InitialiseTiles();
        }

        public enum TileType
        {
            Empty
        }

        private Tile CreateTile(TileType aTileType, Position aPosition)
        {
            switch(aTileType)
            {
                case TileType.Empty:
                    {
                        EmptyTile emptytile = new EmptyTile(aPosition);
                        tiles[aPosition.Y, aPosition.X] = emptytile;
                        return emptytile;
                    }
                default:
                    {
                        EmptyTile emptytile = new EmptyTile(aPosition);
                        tiles[aPosition.Y, aPosition.X] = emptytile;
                        return emptytile;
                    }
            }
        }

        private void CreateTile(TileType aTileType, int aX, int aY)
        {
            Position position = new Position(aX, aY);
            CreateTile(aTileType, position);
        }

        public void InitialiseTiles()
        {
            for (int h = 0; h < width; h++)
            {
                for (int w = 0; w < height; w++)
                {
                    CreateTile(TileType.Empty, w, h);
                }
            }
        }

        public override string ToString()
        {
            for (int h = 0; h < width; h++)
            {
                for (int w = 0; w < height; w++)
                {
                    Console.Write(tiles[h,w].Display + " ");
                }
                Console.Write("\n");
            }

            return ""; // Fix This --------------------------------------------------------------------
        }
    }
}
