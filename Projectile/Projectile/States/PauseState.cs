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

      

       
        public PauseState(Main game, GraphicsDevice graphicsDevice, ContentManager content)
          : base(game, graphicsDevice, content)
        {
            bg_pause = _content.Load<Texture2D>("PauseState/bg_pause");

            var bt_resume = _content.Load<Texture2D>("PauseState/resume");
            var bt_restart = _content.Load<Texture2D>("PauseState/restart");
            var bt_exit = _content.Load<Texture2D>("PauseState/exit");


            var resumeGameButton = new Button(bt_resume, null)
            {
                Position = new Vector2(567, 360),
                Text = "",
            };

            //startGameButton.Click += StartGameButton_Click;

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

            };

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {


            Globals.spriteBatch.Draw(bg_pause, new Vector2(0, 0), Color.White);

            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);

           
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



    }
}
