using System;
using System.Collections.Generic;
using System.Data;
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
        private Random random = new Random();
        public HeroTile hero;

        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public Level(int width, int height, HeroTile aHero = null)
        {
            Position randomPlace;

            Width = width;
            Height = height;

            tiles = new Tile[Height, Width];
            InitialiseTiles();

            randomPlace = GetRandomEmptyPosition();
            
            if (aHero == null)
            {
                CreateTile(TileType.Hero, randomPlace);
                hero = aHero;
            }
            else
            {
                aHero.characterPosition = randomPlace;
                tiles[randomPlace.Y, randomPlace.X] = aHero;
                hero = aHero;
            }
        }

        public enum TileType
        {
            Empty,
            Wall,
            Hero
        }

        private Tile CreateTile(TileType aTileType, Position aPosition)
        {
            Tile tile;
            switch (aTileType)
            {
                case TileType.Empty:
                    {
                        tile = new EmptyTile(aPosition);
                        tiles[aPosition.Y, aPosition.X] = tile;
                        return tile;
                    }
                case TileType.Wall:
                    {
                        tile = new WallTile(aPosition);
                        tiles[aPosition.Y, aPosition.X] = tile;
                        return tile;
                    }
                case TileType.Hero:
                    {
                        tile = new HeroTile(aPosition);
                        tiles[aPosition.Y, aPosition.X] = tile;
                        return tile;
                    }
                default:
                    {
                        tile = new EmptyTile(aPosition);
                        tiles[aPosition.Y, aPosition.X] = tile;
                        return tile;
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
            for (int h = 0; h < Width; h++)
            {
                for (int w = 0; w < Height; w++)
                {
                    if (w == 0 | w == Width - 1 | h == 0 | h == Height - 1)
                    {
                        CreateTile(TileType.Wall, w, h);
                    }
                    else
                    {
                        CreateTile(TileType.Empty, w, h);
                    }
                }
            }
        }

        public override string ToString()
        {
            string map = "";

            for (int h = 0; h < Width; h++)
            {
                for (int w = 0; w < Height; w++)
                {
                    map += tiles[h, w].Display;
                }
                map += "\n";
            }

            return map;
        }

        public Tile GetTiles(int aH, int aW)
        {
            return tiles[aH, aW];
        }

        private Position GetRandomEmptyPosition()
        {
            Position value = null;
            int temp1;
            int temp2;

            while (value == null)
            {
                temp1 = random.Next(0, Height);
                temp2 = random.Next(0, Width);

                if (tiles[temp1, temp2].Display == Convert.ToChar("▯"))
                {
                    value = new Position(temp2, temp1);
                    return value;
                }
            }
            return value;
        }

        public HeroTile Hero
        {
            get { return hero; }
        }

        public void SwopTiles(Tile object1, Tile object2)
        {
            Tile tempTile = null;

            tempTile = object1;
            tempTile.X = object2.X;
            tempTile.Y = object2.Y;

            object1 = object2;
            object1.X = object2.X;
            object1.Y = object2.Y;

            object2 = tempTile;
            object2.X = tempTile.X;
            object2.Y = tempTile.Y;

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
