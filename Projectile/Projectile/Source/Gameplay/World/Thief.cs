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
    public class Thief : Basic2D
    {
        public Thief(String PATH, Vector2 POS, Vector2 DIMS) : base(PATH, POS, DIMS)
        {

        }

        public override void Update()
        {
            if (Globals.keyboard.GetPress("A"))
            {
                pos = new Vector2(pos.X - 4, pos.Y);
            }

            if (Globals.keyboard.GetPress("D"))
            {
                pos = new Vector2(pos.X + 4, pos.Y);
            }

            base.Update();
        }

        public override void Draw(Vector2 OFFSET)
        {

            base.Draw(OFFSET);
        }

    }
}
