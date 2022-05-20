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
    public class Structure : Basic2D
    {
        
        public Structure(String PATH, Vector2 POS, Vector2 DIMS)
            : base(PATH, POS, DIMS)
        {

            rect = new Rectangle((int)pos.X, (int)pos.Y, (int)dims.X, (int)dims.Y);

        }

        public virtual void Update(GameTime gameTime, Vector2 OFFSET, List<Unit> UNITS)
        {
            //rect = new Rectangle((int)pos.X, (int)pos.Y, (int)dims.X, (int)dims.Y);
        }

        public virtual void Draw()
        {
            if (model != null)
            {
                //Globals.spriteBatch.Draw(model, new Rectangle((int)(pos.X), (int)(pos.Y), (int)dims.X, (int)dims.Y), Color.White); ;
                Globals.spriteBatch.Draw(model, new Rectangle(rect.X, rect.Y, rect.Width, rect.Height), Color.White);
            }

        }
    }
}
