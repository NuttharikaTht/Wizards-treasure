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
    public class Basic2D
    {
        public float rot;
        public float angle;
        public Vector2 pos, dims;

        public Texture2D model;

        public Basic2D(String PATH, Vector2 POS, Vector2 DIMS)
        {

            pos = POS;
            dims = DIMS;
            
            model = Globals.content.Load<Texture2D>("textures/"+PATH);

        }

        public virtual void Update(GameTime gameTime)
        {
            
        }

        public virtual void Draw(Vector2 OFFSET)
        {
            if(model != null)
            { 
                Globals.spriteBatch.Draw(model, new Rectangle((int)(pos.X + OFFSET.X) , (int)(pos.Y + OFFSET.Y) , (int)dims.X, (int)dims.Y), null, Color.White, rot,
                    new Vector2(model.Bounds.Width/2, model.Bounds.Height/2), new SpriteEffects(), 0); ;
            }
        }

        //overload
        public virtual void Draw(Vector2 OFFSET, Vector2 ORIGIN)
        {
            if (model != null)
            {
                Globals.spriteBatch.Draw(model, new Rectangle((int)(pos.X + OFFSET.X), (int)(pos.Y + OFFSET.Y), (int)dims.X, (int)dims.Y), null, Color.White, rot,
                    new Vector2(ORIGIN.X, ORIGIN.Y), new SpriteEffects(), 0); ;
            }
        }
    }
}
