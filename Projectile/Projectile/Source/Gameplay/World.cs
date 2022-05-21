using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Projectile.Source.Gameplay.World.Wall;

namespace Projectile
{
    public class World
    {
        public Thief thief;
        public Wizard wizard;
        public Arrow arrow;

        public static Floor floor;
        public static Treasure treasure;

        public Vector2 offset;
        public List<obj> projectiles = new List<obj>();

        public SpriteFont engFonts, thaiFont;

        public World()
        {

            engFonts = Globals.content.Load<SpriteFont>("fonts/Minecraft_24");
            floor = new Floor("floor", new Vector2(0, 572), new Vector2(Globals.screenWidth, 88));
            // init wall
            for (int i = 0; i < Globals.slots.Length; i++)
            {
                Globals.slots[i] = new Slots(new Vector2(80 + (40 * i), 572), i);
                {
                    Globals.slots[i].CurrentState = SlotsState.Walk;
                };
            }
            Globals.slots[11] = new Dirt(new Vector2(520, 572), 11)
            {
                CurrentState = SlotsState.Wall1
            };
            Globals.slots[13] = new Dirt(new Vector2(600, 572), 13)
            {
                CurrentState = SlotsState.Wall3
            };

            Globals.CurrentPlayer = WhoPlay.Thief;
            thief = new Thief("player/thief", new Vector2(40, 542), new Vector2(90, 90), 500);
            wizard = new Wizard("player/wizard", new Vector2(1180, 542), new Vector2(90, 90));

            treasure = new Treasure("treasure", new Vector2(wizard.pos.X - 40, wizard.pos.Y), new Vector2(40, 40));

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

            if (projectiles.Count > 0)
            {
                projectiles[0].Update(gameTime, offset, null);
                if (projectiles[0].isDone)
                {
                    // x = slot that projectile hit
                    float x = (projectiles[0].pos.X - 80) / 40;
                    int index = (int)MathF.Round(x, MidpointRounding.AwayFromZero);
                    Console.WriteLine(projectiles[0].type);
                    if (Globals.CurrentPlayer == WhoPlay.Wizard)
                    {
                        // add wall in slot index x
                        AddWall(index, projectiles[0].type, gameTime);
                    }

                    projectiles.RemoveAt(0);
                    Globals.CurrentPlayer = Globals.CurrentPlayer == WhoPlay.Thief ? WhoPlay.Wizard : WhoPlay.Thief;
                    Globals.ResetTimer();
                }
            }

        }
        public void AddWall(int INDEX, String type, GameTime gameTime)
        {
            WallType wall = WallType.Non;
            switch (type)
            {
                case "dirt": wall = WallType.Dirt; break;
                case "water": wall = WallType.Water; break;
                case "wind": wall = WallType.Wind; break;
                case "fire": wall = WallType.Fire; break;
            }
            Globals.slots[INDEX].Update(gameTime, wall);
        }

        public virtual void AddProjectile(object INFO)
        {
            projectiles.Add((obj)INFO);
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
            //projectile.Draw(OFFSET);
            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Draw(offset);
            }
        }
    }
}
