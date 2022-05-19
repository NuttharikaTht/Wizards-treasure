using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Projectile
{
    public class Main : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch _spriteBatch;


        World world;

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

            Globals.keyboard = new McKeyboard();
            

            world = new World();
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Globals.gameTime = gameTime;
            Globals.keyboard.Update();

            world.Update();


            //Update key that've been 
            Globals.keyboard.UpdateOld();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            Globals.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

            world.Draw(Vector2.Zero);

            
            Globals.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
