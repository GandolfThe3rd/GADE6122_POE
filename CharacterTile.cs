﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hero_Adventure
{
    public abstract class CharacterTile : Tile
    {
        public int hitPoints;
        public int maximumHitPoints;
        public int attackPower;
        public Tile[] vision;
        public bool isDead;

        public Position characterPosition;

        public CharacterTile(Position aPosition, int aHitPoints, int aAttackPower) : base(aPosition)
        {
            hitPoints = aHitPoints;
            maximumHitPoints = aHitPoints;
            attackPower = aAttackPower;
            vision = new Tile[4];

            characterPosition = aPosition;
        }

        public void UpdateVision(Level aLevel)
        {
            vision[0] = aLevel.tiles[characterPosition.X, characterPosition.Y - 1]; // 0
            vision[1] = aLevel.tiles[characterPosition.X + 1, characterPosition.Y]; // 1
            vision[2] = aLevel.tiles[characterPosition.X, characterPosition.Y + 1]; // 2
            vision[3] = aLevel.tiles[characterPosition.X - 1, characterPosition.Y]; // 3

            //      0
            //  3   C   1
            //      2
        }

        public void TakeDamage(int incomingDamage)
        {
            hitPoints -= incomingDamage;

            if (hitPoints < 0)
            {
                hitPoints = 0;
            }
        }

        public void Attack(CharacterTile opponent)
        {
            opponent.TakeDamage(attackPower);
        }

        public bool IsDead
        {
            get
            {
                if (hitPoints <= 0)
                    return true;
                else
                    return false;
            }
        }
    }
}
