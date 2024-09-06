using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hero_Adventure
{
    public abstract class Tile
    {
        private Position position;

        public int X
        {
            get { return position.X; }
            set { position.X = value; }
        }

        public int Y
        {
            get { return position.X; }
            set { position.X = value; }
        }

        public Tile(Position aPosition)
        {
            position = aPosition;
        }

        public abstract char Display
        {
            get;
        }
    }
}
