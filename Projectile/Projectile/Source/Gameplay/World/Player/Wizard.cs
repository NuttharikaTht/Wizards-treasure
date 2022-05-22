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

            switch (CurrentState)
            {
                case PlayerState.Running:
                    if (Globals.keyboard.GetPressRelease(Keys.Space))
                    {
                        CurrentState = PlayerState.Aiming;
                        arrow.pos = new Vector2(pos.X - 90, pos.Y);
                    }
                    break;
                case PlayerState.Aiming:
                    if (Globals.keyboard.GetPress("W"))
                    {
                        Globals.Power += 1;
                    }
                    if (Globals.keyboard.GetPress("S"))
                    {
                        Globals.Power -= 1;
                    }
                    if (Globals.keyboard.GetPressRelease(Keys.Space))
                    {
                        CurrentState = PlayerState.Running;
                    }
                    break;
            }


            base.Update(gameTime);
        }

        public override void Draw(Vector2 OFFSET)
        {

            base.Draw(OFFSET);
        }

    }
}
