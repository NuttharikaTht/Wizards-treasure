using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Projectile.States;

namespace Projectile
{
    public class Main : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch _spriteBatch; 


        World world;

        Basic2D cursur;

        private State _currentState;

        private State _nextState;

        public void ChangeState(State state)
        {
            _nextState = state;
        }

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Globals.screenHeight = 720;
            Globals.screenWidth = 1280;

            graphics.PreferredBackBufferHeight = Globals.screenHeight;
            graphics.PreferredBackBufferWidth = Globals.screenWidth;

            graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {

            Globals.content = this.Content;
            Globals.spriteBatch = new SpriteBatch(GraphicsDevice);

            Globals.soundControl = new SoundControl("Sound/sound");

            /* cursur = new Basic2D("shooter/aiming", new Vector2(0, 0), new Vector2(40, 40));

             Globals.keyboard = new McKeyboard();
             Globals.mouse = new McMouseControl();

             world = new World();*/

            _currentState = new MenuState(this, graphics.GraphicsDevice, Content);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

     /*       Globals.gameTime = gameTime;
            Globals.keyboard.Update();
            Globals.mouse.Update();

            world.Update(Globals.gameTime);

            //Update key that've been pressed
            Globals.keyboard.UpdateOld();
            Globals.mouse.UpdateOld();  */

            if (_nextState != null)
            {
                _currentState = _nextState;

                _nextState = null;
            } 

            _currentState.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

       /*     Globals.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

            world.Draw(Vector2.Zero);

            if (world.thief.checkAim()) {
                cursur.Draw(new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y), new Vector2(0, 0));
            } */

            _currentState.Draw(gameTime, _spriteBatch);

          //  Globals.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
