using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace Hero_Adventure
{
    public class Level
    {
        public Tile[,] tiles;
        private int width;
        private int height;
        private Random random = new Random();
        public HeroTile hero;
        public ExitTile exit;

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

            tiles = new Tile[Width, Height];
            InitialiseTiles();

            randomPlace = GetRandomEmptyPosition();
            
            if (aHero == null)
            {
                CreateTile(TileType.Hero, randomPlace);
                aHero = new HeroTile(randomPlace);
                this.hero = aHero;
            }
            else
            {
                aHero.characterPosition = randomPlace;
                aHero = new HeroTile(randomPlace);
                tiles[randomPlace.X, randomPlace.Y] = aHero;
                this.hero = aHero;
            }

            randomPlace = GetRandomEmptyPosition();
            CreateTile(TileType.Exit, randomPlace);
            exit = new ExitTile(randomPlace);
            exit.X = randomPlace.X;
            exit.Y = randomPlace.Y;

        }

        public enum TileType
        {
            Empty,
            Wall,
            Hero,
            Exit
        }

        private Tile CreateTile(TileType aTileType, Position aPosition)
        {
            switch (aTileType)
            {
                case TileType.Empty:
                    {
                        EmptyTile tile = new EmptyTile(aPosition);
                        tiles[aPosition.X, aPosition.Y] = tile;
                        return tile;
                    }
                case TileType.Wall:
                    {
                        WallTile tile = new WallTile(aPosition);
                        tiles[aPosition.X, aPosition.Y] = tile;
                        return tile;
                    }
                case TileType.Hero:
                    {
                        HeroTile tile = new HeroTile(aPosition);
                        tiles[aPosition.X, aPosition.Y] = tile;
                        return tile;
                    }
                case TileType.Exit:
                    {
                        ExitTile tile = new ExitTile(aPosition);
                        tiles[aPosition.X, aPosition.Y] = tile;
                        return tile;
                    }

                default:
                    {
                        EmptyTile tile = new EmptyTile(aPosition);
                        tiles[aPosition.X, aPosition.Y] = tile;
                        return tile;
                    }
            }
        }

        private Tile CreateTile(TileType aTileType, int aX, int aY)
        {
            Position position = new Position(aX, aY);
            return CreateTile(aTileType, position);
        }

        public void InitialiseTiles()
        {
            for (int h = 0; h < Height; h++)
            {
                for (int w = 0; w < Width; w++)
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

            for (int h = 0; h < Height; h++)
            {
                for (int w = 0; w < Width; w++)
                {
                    map += tiles[w, h].Display.ToString();
                }
                map += "\n";
            }

            return map;
        }

        public Tile[,] Tiles
        {
            get { return tiles; }

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

                if (tiles[temp2, temp1] is EmptyTile) // if (tiles[temp1, temp2].Display == Convert.ToChar("▯")) || Old code just in case
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
            Tile tempTile1 = object1;
            Tile tempTile2 = object2;

            object1.X = tempTile2.X; // Object 1 becomes Object 2
            object1.Y = tempTile2.Y;
            object1 = tempTile2;

            object2.X = tempTile1.X; // Object 2 becomes the Temp Tile (which was Object 1)
            object2.Y = tempTile1.Y;
            object2 = tempTile1;

            tiles[object1.X, object1.Y] = object1;
            tiles[object2.X, object2.Y] = object2;
        }

        

        public ExitTile Exit
        { get { return exit; } }

        public HeroTile HeroTile
        {
            get { return hero; }
            set { hero = value; }
        }
    }
}
