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
    public class Arrow : Basic2D
    {
        public Arrow(String PATH, Vector2 POS, Vector2 DIMS) : base(PATH, POS, DIMS)
        {

        }

        public override void Update()
        {
            if (Globals.keyboard.GetPress("W"))
            {
                pos = new Vector2(pos.X, pos.Y+1);
            }

            if (Globals.keyboard.GetPress("S"))
            {
                pos = new Vector2(pos.X, pos.Y-1);
            }

            base.Update();
        }

        public override void Draw(Vector2 OFFSET)
        {

            base.Draw(OFFSET);
        }

    }
}
