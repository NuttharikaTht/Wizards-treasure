using System;
using System.Collections;
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
        public Object item;

        public Vector2 VectorItem;

        public World()
        {
            thief = new Thief("thief", new Vector2(20, 400), new Vector2(40, 40));
            arrow = new Arrow("arrow", new Vector2(60, 400), new Vector2(40, 40));
            item = new Object("Flower", new Vector2(90, 400), new Vector2(30, 30));
        }

        public virtual void Update()
        {
            thief.Update();
            arrow.Update();
            item.Update();
        }

        public virtual void Draw(Vector2 OFFSET)
        {
            thief.Draw(OFFSET);
            arrow.Draw(OFFSET);
            item.Draw(OFFSET);
        }
    }
}
