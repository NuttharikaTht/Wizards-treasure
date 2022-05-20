using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Projectile.Source.Engine;

namespace Projectile.Source.Gameplay.World.Wall
{
    public class Dirt : Slots
    {
        public Dirt(Vector2 POS):base("dirt", POS)
        {
        }
        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
