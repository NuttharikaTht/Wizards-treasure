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

        public float stamina;
        public Rectangle staminaRect;
        public Texture2D staminaTexture;
        private int[] staminaCount = new int[26];
        private int count;

        public Rectangle thiefRect;

        public bool hitWall;
        public int wallHitCost;
        public SlotsState wallLevel;

        private float staminaUsage;

        public Thief(String PATH, Vector2 POS, Vector2 DIMS, float newStamina) : base(PATH, POS, DIMS)
        {
            arrow = new Arrow("shooter/arrow", new Vector2(pos.X + 20, pos.Y), new Vector2(40, 40), true, this);
            staminaTexture = Globals.content.Load<Texture2D>("textures/stamina");
            CurrentState = PlayerState.Running;
            stamina = newStamina;
            thiefRect = new Rectangle((int) pos.X, (int) pos.Y, (int) dims.X, (int) dims.Y);
        }

        public void staminaUp()
        {
            float stamina = this.stamina;
            stamina += (stamina * 30) / 100;
            this.stamina = stamina;
        }

        public bool HitWallCheck()
        {
            SlotsState wallLevel = SlotsState.Walk;

            for (int i = 0; i < Globals.slots.Count(); i++)
            {
                hitWall = false;
                
                if (thiefRect.Intersects(Globals.slots[i].rect))
                {
                    if (Globals.slots[i].CurrentState != SlotsState.Walk)
                    {
                        //staminaCount[i] += 1;
                        hitWall = true;
                        wallLevel = Globals.slots[i].CurrentState;
                        if (wallLevel == SlotsState.Wall1) staminaUsage += 5;//0.3125f;
                        else if (wallLevel == SlotsState.Wall2) staminaUsage += 10;//0.625f;
                        else if (wallLevel == SlotsState.Wall3) staminaUsage += 15;// 0.9375f;
                        else if (wallLevel == SlotsState.Wall4) staminaUsage += 20;// 1.25f;
                        else if (wallLevel == SlotsState.Wall5) staminaUsage += 25; // 1.5625f;

                        //staminaCount[i] = (int) staminaUsage;
                        //count = staminaCount[i];

                        break;
                    }
                }

            }

            return hitWall;
        }

        public override void Update(GameTime gameTime)
        {
            staminaUsage = 0;
            staminaRect = new Rectangle((int)pos.X - 40, (int)pos.Y - 80, (int) stamina/5, 30);
            elapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
            thiefRect = new Rectangle((int)pos.X, (int)pos.Y, (int)dims.X, (int)dims.Y);
            //hitWall = HitWallCheck(thiefRect);

            if (!checkAim())
            {
                if(CurrentState == PlayerState.Running)
                {
                    if (Globals.keyboard.GetPress("A"))
                    {
                        pos = new Vector2(pos.X - 4, pos.Y);
                        //wallLevel = HitWallCheck(thiefRect);
                        hitWall = HitWallCheck();
                        if (!hitWall) {
                            staminaUsage += 1;
                        }
                    }

                    if (Globals.keyboard.GetPress("D"))
                    {
                        pos = new Vector2(pos.X + 4, pos.Y);
                        //wallLevel = HitWallCheck(thiefRect);
                        hitWall = HitWallCheck();
                        if (!hitWall)
                        {
                            staminaUsage += 1;
                        }
                    }
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
                        arrow.item = null;
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
            

            //Debugging ว่าชนกำแพงไหม
            Globals.spriteBatch.DrawString(engFonts, hitWall.ToString(), new Vector2(staminaRect.X, staminaRect.Y - 40), Color.Yellow);

            Globals.spriteBatch.DrawString(engFonts, "-" + staminaUsage.ToString() , new Vector2(staminaRect.X + 100, staminaRect.Y + 40), Color.Yellow);
            Globals.spriteBatch.Draw(staminaTexture, staminaRect, Color.White);
            Globals.spriteBatch.DrawString(engFonts, stamina.ToString(), new Vector2(staminaRect.X + 5, staminaRect.Y + 5), Color.Black);
            base.Draw(OFFSET);
        }

    }
}
