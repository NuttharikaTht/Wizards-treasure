using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Projectile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projectile.States
{
    #region Fields
    public abstract class State
    {
        protected ContentManager _content;

        protected GraphicsDevice _graphicsDevice;

        protected GraphicsDeviceManager _graphics;

        protected Main _game;

    #endregion

        #region Methods


        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        //public abstract void PostUpdate(GameTime gameTime);

        public State(Main game, GraphicsDevice graphicsDevice, ContentManager content)
        {
            _game = game;

            _graphicsDevice = graphicsDevice;

            _content = content;

        }

        public abstract void Update(GameTime gameTime);

        #endregion
    }
}
