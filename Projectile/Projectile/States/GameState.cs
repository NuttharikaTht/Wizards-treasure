using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Projectile;
using Projectile.Controls;


namespace Projectile.States
{
    public class GameState : State
    {
        Texture2D bg_game;
        Texture2D bg_time;

        SpriteFont gameFont;

        State PauseState;

        private List<Component> _components;
        private List<Component> _resume;

        float Time = 30;

        bool pause = false;

        World world;

        Basic2D cursur;



        public GameState(Main game, GraphicsDevice graphicsDevice, ContentManager content)
          : base(game, graphicsDevice, content)
        {
          //
            cursur = new Basic2D("shooter/aiming", new Vector2(0, 0), new Vector2(40, 40));

            Globals.keyboard = new McKeyboard();
            Globals.mouse = new McMouseControl();

            world = new World();

            //
            Globals.ResetTimer();
            bg_game = _content.Load<Texture2D>("GameState/bg_game");
            bg_time = _content.Load<Texture2D>("GameState/time");

            gameFont = _content.Load<SpriteFont>("fonts/Minecraft");

            var bt_pause = _content.Load<Texture2D>("GameState/pause");
            var bt_resume = _content.Load<Texture2D>("PauseState/resume");

            var pauseGameButton = new Button(bt_pause, null)
            {
                Position = new Vector2(1185, 36),
                Text = "",
            };
           

            pauseGameButton.Click += PauseGameButton_Click;

            var resumeGameButton = new Button(bt_resume, null)
            {
                Position = new Vector2(567, 360),
                Text = "",
            };

            resumeGameButton.Click += ResumeGameButton_Click;

            _components = new List<Component>()
            {
                pauseGameButton,
            };
            _resume = new List<Component>()
            {
                resumeGameButton,
            };
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Globals.spriteBatch.Begin();

            Globals.spriteBatch.Draw(bg_game, new Vector2(0, 0), Color.White);
            Globals.spriteBatch.Draw(bg_time, new Vector2(615, 25), Color.White);

            foreach (var component in _components)
                   component.Draw(gameTime, spriteBatch);

            // time
            Globals.spriteBatch.DrawString(gameFont, Globals.timer.ToString("00" + "  S"), new Vector2(664, 50), Color.White);

            

            //draw game play
            world.Draw(Vector2.Zero);

            if (world.thief.checkAim())
            {
                cursur.Draw(new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y), new Vector2(0, 0));
            }
            if (world.wizard.checkAim())
            {
                cursur.Draw(new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y), new Vector2(0, 0));
            }

            //draw game pause
            if (pause== true)
            {

             PauseState.Draw(gameTime, spriteBatch);
                foreach (var component in _resume)
                    component.Draw(gameTime, spriteBatch);
            }

            Globals.spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            

            if (pause == true)
            {
                PauseState.Update(gameTime);
                foreach (var component in _resume)
                    component.Update(gameTime);
            }
            else
            {
                foreach (var component in _components)
                    component.Update(gameTime);

                // update time
                Globals.timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;

                //update game play
                Globals.gameTime = gameTime;
                Globals.keyboard.Update();
                Globals.mouse.Update();

                world.Update(Globals.gameTime);

                //Update key that've been pressed
                Globals.keyboard.UpdateOld();
                Globals.mouse.UpdateOld();

            }
        }

        private void PauseGameButton_Click(object sender, EventArgs e)
        {
            PauseState = new PauseState(_game, _graphicsDevice, _content);
            pause = true;
        }
        private void ResumeGameButton_Click(object sender, EventArgs e)
        {
            pause = false;
            //_game.ChangeState(new GameState(_game, _graphicsDevice, _content));
        }
    }
}
