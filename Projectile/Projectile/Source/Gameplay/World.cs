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
    public class World
    {
        public Thief thief;
        public Arrow arrow;

        public Vector2 offset;
        public List<Projectile2D> projectiles = new List<Projectile2D>();

        public World()
        {

            thief = new Thief("thief", new Vector2(20, 400), new Vector2(40, 40));
            arrow = new Arrow("arrow", new Vector2(100, 380), new Vector2(40, 40));

            //set PaddProjectile to AddProjectile Func
            GameGlobals.PassProjectile = AddProjectile;
        }

        public virtual void Update(GameTime gameTime)
        {
            thief.Update(gameTime);
            if (thief.checkAim()) {
                arrow.Update(gameTime);
            }

            for (int i=0; i<projectiles.Count; i++)
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
            thief.Draw(OFFSET);
            if (thief.checkAim()) {
                arrow.Draw(OFFSET);
            }

            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Draw(offset);
            }
        }
    }
}
