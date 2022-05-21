using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Projectile.Controls;

namespace Projectile.States
{
    public class MenuState : State
    {
        private List<Component> _components;
      

        Texture2D bg_menu;
        Texture2D logo;

        Song song;

        public MenuState(Main game, GraphicsDevice graphicsDevice, ContentManager content)
          : base(game, graphicsDevice, content)
        {
            bg_menu = _content.Load<Texture2D>("MenuState/bg_menu");
            logo = _content.Load<Texture2D>("MenuState/newlogo");

            song = _content.Load<Song>("Sound/sound");
            MediaPlayer.Play(song);

            var bt_start = _content.Load<Texture2D>("MenuState/bt_start");
            var bt_exit = _content.Load<Texture2D>("MenuState/bt_exit");


            var startGameButton = new Button(bt_start, null)
            {
                Position = new Vector2(565, 386),
                Text = "",
            };

             startGameButton.Click += StartGameButton_Click;

            var quitGameButton = new Button(bt_exit, null)
            {
                Position = new Vector2(565, 446),
                Text = "",
            };

            quitGameButton.Click += QuitGameButton_Click;

            _components = new List<Component>()
            {
                startGameButton,
                quitGameButton,

            };

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {


            Globals.spriteBatch.Begin();

            Globals.spriteBatch.Draw(bg_menu, new Vector2(0, 0), Color.White);
            Globals.spriteBatch.Draw(logo, new Vector2(356, 152), Color.White);

            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);
            Globals.spriteBatch.End();
          
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
                component.Update(gameTime);

           
        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
           
        }

        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }
    }
}
