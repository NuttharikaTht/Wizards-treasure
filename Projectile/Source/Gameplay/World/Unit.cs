using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Projectile
{
    public class Unit : Basic2D
    {
        public static int count = 0;
        public bool isThief;
        public Unit(String PATH, Vector2 POS, Vector2 DIMS, bool ISTHIEF) : base(PATH, POS, DIMS)
        {
            isThief = ISTHIEF;
        }

        public override void Update(GameTime gameTime)
        {
           
            base.Update(gameTime);
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }

    }
}
