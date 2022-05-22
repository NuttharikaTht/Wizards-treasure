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
    public class Wizard : Player
    {
        public Arrow arrow;

        public Wizard(String PATH, Vector2 POS, Vector2 DIMS) : base(PATH, POS, DIMS)
        {
            arrow = new Arrow("shooter/arrow", new Vector2(pos.X + 20, pos.Y), new Vector2(40, 40), false, this);
            CurrentState = PlayerState.Idle;
        }

        public override void Update(GameTime gameTime)
        {
            elapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (!checkAim())
            {
                
            }
            else
            {
                if (Globals.keyboard.GetPress("W"))
                {
                    Globals.Power += 1;
                }
                if (Globals.keyboard.GetPress("S"))
                {
                    Globals.Power -= 1;
                }
            }

            if (Globals.keyboard.GetPressRelease(Keys.Space))
            {
                if (!checkAim())
                {
                    CurrentState = PlayerState.Aiming;
                    arrow.pos = new Vector2(pos.X - 90, pos.Y);
                }
                else
                {
                    CurrentState = PlayerState.Running;
                    arrow.pos = new Vector2(0, 0);
                }
            }


            base.Update(gameTime);
        }

        public override void Draw(Vector2 OFFSET)
        {

            base.Draw(OFFSET);
        }

    }
}
