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

        public int stamina;
        public Rectangle staminaRect;
        public Texture2D staminaTexture;

        private int staminaUsage;

        public Thief(String PATH, Vector2 POS, Vector2 DIMS, int newStamina) : base(PATH, POS, DIMS)
        {
            arrow = new Arrow("shooter/arrow", new Vector2(pos.X + 20, pos.Y), new Vector2(40, 40), true, this);
            staminaTexture = Globals.content.Load<Texture2D>("textures/stamina");
            CurrentState = PlayerState.Idle;

            stamina = newStamina;
        }

        public override void Update(GameTime gameTime)
        {
            staminaUsage = 0;
            staminaRect = new Rectangle(50, 20, stamina / 5, 20);
            elapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (!checkAim())
            {
                if (Globals.keyboard.GetPress("A"))
                {
                    pos = new Vector2(pos.X - 4, pos.Y);
                    //stamina -= 1;
                    staminaUsage += 1;
                }

                if (Globals.keyboard.GetPress("D"))
                {
                    pos = new Vector2(pos.X + 4, pos.Y);
                    //stamina -= 1;
                    staminaUsage += 1;
                }
            }
            else
            {
                if (Globals.keyboard.GetPress("W"))
                {
                    Globals.Power += 1;
                    //staminaUsage += 5;
                    //stamina -= 5;
                }
                if (Globals.keyboard.GetPress("S"))
                {
                    Globals.Power -= 1;
                    //staminaUsage += 5;
                    //stamina -= 5;
                }
            }

            if (elapsed > 0.1f)
            {
                if (Globals.keyboard.GetPress("Space"))
                {
                    if (!checkAim())
                    {
                        CurrentState = PlayerState.Aiming;
                        arrow.pos = new Vector2(pos.X + 90, pos.Y);
                        staminaUsage += 5;

                        //stamina -= 5;
                    }
                    else
                    {
                        CurrentState = PlayerState.Running;
                    }
                }
                elapsed = 0f;
            }

            stamina -= staminaUsage;

            base.Update(gameTime);
        }

        public override void Draw(Vector2 OFFSET)
        {
            Globals.spriteBatch.Draw(staminaTexture, staminaRect, Color.White);
            base.Draw(OFFSET);
        }

    }
}
