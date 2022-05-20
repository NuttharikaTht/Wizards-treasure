using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Projectile.Source.Engine;
using Projectile.Source.Gameplay.World.Wall;

namespace Projectile
{
    public class World
    {
        public Thief thief;
        public Wizard wizard;
        public Arrow arrow;

        public static Floor floor;
        public Vector2 offset;
        public List<Projectile2D> projectiles = new List<Projectile2D>();

        public SpriteFont engFonts, thaiFont;

        public World()
        {

            engFonts = Globals.content.Load<SpriteFont>("fonts/Minecraft_24");
            floor = new Floor("floor", new Vector2(0, 572), new Vector2(Globals.screenWidth, 88));
            // init wall
            for (int i = 0; i < Globals.slots.Length; i++)
            {
                Globals.slots[i] = new Source.Engine.Slots(new Vector2(80 + (40 * i), 572));
                {
                    Globals.slots[i].CurrentState = Source.Engine.SlotsState.Walk;
                };
            }
            Globals.slots[11] = new Dirt(new Vector2(520, 572))
            {
                CurrentState = Source.Engine.SlotsState.Wall1
            };
            Globals.slots[13] = new Dirt(new Vector2(600, 552))
            {
                CurrentState = Source.Engine.SlotsState.Wall2
            };

            Globals.CurrentPlayer = WhoPlay.Thief;
            thief = new Thief("player/thief", new Vector2(40, 542), new Vector2(90, 90));
            wizard = new Wizard("player/wizard", new Vector2(1180, 542), new Vector2(90, 90));

            //set PaddProjectile to AddProjectile Func
            GameGlobals.PassProjectile = AddProjectile;
        }

        public virtual void Update(GameTime gameTime)
        {
            if (Globals.CurrentPlayer == WhoPlay.Thief)
            {
                thief.Update(gameTime);
                if (thief.checkAim())
                {
                    thief.arrow.Update(gameTime);
                }
            }
            else
            {
                wizard.Update(gameTime);
                if (wizard.checkAim())
                {
                    wizard.arrow.Update(gameTime);
                }
            }



            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Update(gameTime, offset, null);

                if (projectiles[i].done)
                {
                    projectiles.RemoveAt(i);
                    i--;
                }
            }
        }

        public virtual void AddProjectile(object INFO)
        {
            projectiles.Add((Projectile2D)INFO);
        }

        public virtual void Draw(Vector2 OFFSET)
        {
            floor.Draw();
            thief.Draw(OFFSET);
            wizard.Draw(OFFSET);
            foreach (Slots slot in Globals.slots)
            {
                slot.Draw(OFFSET);
            }
            if (Globals.CurrentPlayer == WhoPlay.Thief)
            {
                Globals.spriteBatch.DrawString(engFonts, "Thief's Turn", new Vector2(940, 40), Color.Yellow);
            }
            else
            {
                Globals.spriteBatch.DrawString(engFonts, "Wizard's Turn", new Vector2(940, 40), Color.Yellow);
            }


            if (thief.checkAim())
            {
                thief.arrow.Draw(OFFSET);
            }

            if (wizard.checkAim())
            {
                wizard.arrow.Draw(OFFSET);
            }

            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Draw(offset);
            }
        }
    }
}
