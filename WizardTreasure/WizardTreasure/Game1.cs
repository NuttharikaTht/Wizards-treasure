using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WizardTreasure
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public static int limitTop = 108, limitBottom = 144; //Playable Height
        public static int startObjLocation = 720 - 204;
        public static int ObjThf = 120;

        Texture2D playable, obj;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
         }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();
            //Rectangle playable = new Vector2();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            playable = this.Content.Load<Texture2D>("playable");
            obj = this.Content.Load<Texture2D>("obj");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Beige);
            _spriteBatch.Begin();

            _spriteBatch.Draw(playable, new Vector2(0, limitTop), Color.White);
            _spriteBatch.Draw(obj, new Vector2(ObjThf, startObjLocation), Color.White);
            Rectangle objRect = new Rectangle(ObjThf, startObjLocation, 40, 40);


            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
