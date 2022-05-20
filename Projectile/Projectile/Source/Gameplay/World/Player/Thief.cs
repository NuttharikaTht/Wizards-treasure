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
    public class Thief : Player
    {
        public Arrow arrow;

        public Thief(String PATH, Vector2 POS, Vector2 DIMS) : base(PATH, POS, DIMS)
        {
            arrow = new Arrow("arrow", new Vector2(pos.X + 20, pos.Y), new Vector2(40, 40), true);
            CurrentState = PlayerState.Running;
        }

        public override void Update(GameTime gameTime)
        {
            elapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (!checkAim())
            {
                if (Globals.keyboard.GetPress("A"))
                {
                    pos = new Vector2(pos.X - 4, pos.Y);
                }

                if (Globals.keyboard.GetPress("D"))
                {
                    pos = new Vector2(pos.X + 4, pos.Y);
                }
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
            
            if(elapsed > 0.1f)
            {
                if (Globals.keyboard.GetPress("Space"))
                {
                    if (!checkAim())
                    {
                        CurrentState = PlayerState.Aiming;
                        arrow.pos = new Vector2(pos.X + 60, pos.Y);
                    }
                    else
                    {
                        CurrentState = PlayerState.Running;
                        arrow.pos = new Vector2(0, 0);
                    }
                }
                elapsed = 0f;
            }
           

            base.Update(gameTime);
        }

        public override void Draw(Vector2 OFFSET)
        {

            base.Draw(OFFSET);
        }

    }
}
