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
        public Arrow arrow;

        public Thief(String PATH, Vector2 POS, Vector2 DIMS) : base(PATH, POS, DIMS)
        {
            arrow = new Arrow("arrow", new Vector2(pos.X + 20, pos.Y), new Vector2(40, 40));
        }

        public override void Update(GameTime gameTime)
        {
            if (Globals.keyboard.GetPress("A"))
            {
                pos = new Vector2(pos.X - 4, pos.Y);
            }

            if (Globals.keyboard.GetPress("D"))
            {
                pos = new Vector2(pos.X + 4, pos.Y);
            }

            if (Globals.keyboard.GetPress("Space"))
            {
                isAim = true;
                arrow.pos = new Vector2(pos.X+60, pos.Y);
            }
            
            base.Update(gameTime);
        }

        public override void Draw(Vector2 OFFSET)
        {

            base.Draw(OFFSET);
        }

    }
}
