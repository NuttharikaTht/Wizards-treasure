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
    public class Arrow : Unit
    {
        public float speed;
        public Player owner;

        public Arrow(String PATH, Vector2 POS, Vector2 DIMS, bool ISTHIEF, Player OWNER) : base(PATH, POS, DIMS, ISTHIEF)
        {
            speed = 2.0f;
            owner = OWNER;
        }

        public override void Update(GameTime gameTime)
        {

            rot = Globals.RotateTowards(pos, new Vector2(Globals.mouse.newMouse.X, Globals.mouse.newMouse.Y));

            if (0 <= rot && rot <= 180)
            {
                if (Globals.mouse.LeftClick())
                {
                    owner.Firing();
                    //GameGlobals.PassProjectile(new obj("ammo/thief/titan", new Vector2(pos.X, pos.Y - 20), this, new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y), new Vector2(10, 10)));
                    GameGlobals.PassProjectile(new obj("ammo/thief/titan", new Vector2(pos.X, pos.Y - 20), this, new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y), new Vector2(10, 10)));
                }
            }

            base.Update(gameTime);
        }

        public override void Draw(Vector2 OFFSET)
        {

            if (0 <= rot && rot <= 180)
            {
                base.Draw(OFFSET);
            }

        }

    }
}
