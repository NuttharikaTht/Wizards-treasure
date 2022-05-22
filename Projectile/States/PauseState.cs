using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Projectile.Controls;

namespace Projectile.States
{
    class PauseState : State
    {
        private List<Component> _components;

        Texture2D bg_pause;

        float volume = Globals.soundControl.volume;

        SpriteFont font;

        public PauseState(Main game, GraphicsDevice graphicsDevice, ContentManager content)
          : base(game, graphicsDevice, content)
        {
            bg_pause = _content.Load<Texture2D>("PauseState/bg_pause");

            font = _content.Load<SpriteFont>("fonts/Minecraft");

            var bt_resume = _content.Load<Texture2D>("PauseState/resume");
            var bt_restart = _content.Load<Texture2D>("PauseState/restart");
            var bt_exit = _content.Load<Texture2D>("PauseState/exit");

            var bt_left = _content.Load<Texture2D>("PauseState/left");
            var bt_right = _content.Load<Texture2D>("PauseState/right");

            var LeftButton = new Button(bt_left, null)
            {
                Position = new Vector2(659, 220),
                Text = "",
            };

            LeftButton.Click += LeftButton_Click;

            var RightButton = new Button(bt_right, null)
            {
                Position = new Vector2(810, 220),
                Text = "",
            };
            RightButton.Click += RightButton_Click;


            var restartGameButton = new Button(bt_restart, null)
            {
                Position = new Vector2(567, 420),
                Text = "",
            };

            restartGameButton.Click += RestartGameButton_Click;

            var quitGameButton = new Button(bt_exit, null)
            {
                Position = new Vector2(567, 480),
                Text = "",
            };

            quitGameButton.Click += MenuGameButton_Click;

            _components = new List<Component>()
            {
                restartGameButton,
                quitGameButton,
                RightButton,
                LeftButton,

            };

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            Globals.spriteBatch.Draw(bg_pause, new Vector2(0, 0), Color.White);

            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);

            Globals.spriteBatch.DrawString(font, "Volume", new Vector2(477, 220), Color.White);
            Globals.spriteBatch.DrawString(font, (((float)Math.Round(volume, 1)) * 10).ToString(), new Vector2(740, 220), Color.White);


        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
                component.Update(gameTime);
        }

        private void MenuGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
        }

        private void RestartGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
        }

        private void LeftButton_Click(object sender, EventArgs e)
        {
            if (volume >= 0.1)
            {
                volume -= 0.10f;
                Globals.soundControl.AdjustVolume(volume);
            }
            else
            {
                Globals.soundControl.AdjustVolume(0);
            }

        }
        private void RightButton_Click(object sender, EventArgs e)
        {
            if (volume <= 0.9f)
            {
                volume += 0.1f;
                Globals.soundControl.AdjustVolume(volume);
            }
            else
            {
                Globals.soundControl.AdjustVolume(1);
            }
        }



    }
}
