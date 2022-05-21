using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Projectile.Source.Gameplay.World.Wall
{
    public class Dirt : Slots
    {
        public Dirt(Vector2 POS, int INDEX) : base(WallType.Dirt, POS, INDEX)
        {
        }
        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
