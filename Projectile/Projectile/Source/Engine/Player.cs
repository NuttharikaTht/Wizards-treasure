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
    [Flags]
    public enum PlayerState
    {
        Idle = 0x0,
        Running = 0x1,
        Aiming = 0x2,
        Firing = 0x3,
        ProjectileFlying = 0x4,
        ProjectileHit = 0x8,
        Reset = 0x20,
    }

    public class Player
    {
        public float rot;
        public float angle;
        public Vector2 pos, dims;

        public Texture2D model;
        public SpriteFont engFonts;
        public float elapsed;

        PlayerState currentState;
        public PlayerState CurrentState
        {
            get { return currentState; }
            set { currentState = value; }
        }


        public Player(String PATH, Vector2 POS, Vector2 DIMS)
        {
            pos = POS;
            dims = DIMS;

            model = Globals.content.Load<Texture2D>("textures/" + PATH);
            engFonts = Globals.content.Load<SpriteFont>("fonts/Minecraft");
        }

        public virtual bool checkAim()
        {
            return currentState == PlayerState.Aiming;
        }

        public virtual void Firing()
        {
            CurrentState = PlayerState.Firing;


        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(Vector2 OFFSET)
        {
            if (model != null)
            {
                if (checkAim())
                {
                    Globals.spriteBatch.DrawString(engFonts, Globals.Power.ToString() + " %", new Vector2(pos.X - 10, pos.Y + 65), Color.White);
                }
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
