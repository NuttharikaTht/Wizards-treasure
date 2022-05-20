using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Projectile.Source.Engine
{
    [Flags]
    public enum SlotsState
    {
        Walk = 0x0,
        Wall1 = 0x1,
        Wall2 = 0x2,
        Wall3 = 0x4,
        Wall4 = 0x8,
        Wall5 = 0x10,
    }
    public class Slots
    {
        public float rot;
        public Vector2 pos, dims;

        public Texture2D model;
        public String type;
        private SlotsState state;
        public SlotsState CurrentState
        {
            get { return state; }
            set { LoadModel(value); }
        }
        public Slots(Vector2 POS)
        {
            dims = new Vector2(40,40);
            pos = POS;
        }
        public Slots(String TYPE,Vector2 POS)
        {
            dims = new Vector2(40, 40);
            pos = POS;
            type = TYPE;
        }
        public void LoadModel(SlotsState STATE)
        {
            state = STATE;
            switch (state)
            {
                case SlotsState.Walk:
                    model = Globals.content.Load<Texture2D>("textures/blockLine");
                    break;
                case SlotsState.Wall1:
                    model = Globals.content.Load<Texture2D>("textures/wall/" + type + "/lv1");
                    break;
                case SlotsState.Wall2:
                    dims = new Vector2(40, 80);
                    model = Globals.content.Load<Texture2D>("textures/wall/" + type + "/lv2");
                    break;
                case SlotsState.Wall3:
                    dims = new Vector2(40, 180);
                    model = Globals.content.Load<Texture2D>("textures/wall/" + type + "/lv3");
                    break;
                case SlotsState.Wall4:
                    dims = new Vector2(40, 300);
                    model = Globals.content.Load<Texture2D>("textures/wall/" + type + "/lv4");
                    break;
                case SlotsState.Wall5:
                    dims = new Vector2(40, 450);
                    model = Globals.content.Load<Texture2D>("textures/wall/" + type + "/lv5");
                    break;
            }
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(Vector2 OFFSET)
        {
            if (model != null)
            {
                Globals.spriteBatch.Draw(model, new Rectangle((int)(pos.X + OFFSET.X), (int)(pos.Y + OFFSET.Y), (int)dims.X, (int)dims.Y), null, Color.White, rot,
                    new Vector2(model.Bounds.Width / 2, model.Bounds.Height / 2), new SpriteEffects(), 0); ;
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
