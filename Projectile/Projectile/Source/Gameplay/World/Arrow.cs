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
    public class Arrow : Unit
    {
        public float speed;
        public Player owner;

        public obj item;
        public string itemName;
        public obj newItem;

        public string pathImage = "FlowerShow";
        public SpriteFont engFonts;

        public Arrow(String PATH, Vector2 POS, Vector2 DIMS, bool ISTHIEF, Player OWNER) : base(PATH, POS, DIMS, ISTHIEF)
        {
            speed = 2.0f;
            owner = OWNER;
            engFonts = Globals.content.Load<SpriteFont>("fonts/Minecraft");
        }
        public string randomWand()
        {
            List<KeyValuePair<string, double>> elements = new List<KeyValuePair<string, double>>();
            String name = "";
            elements.Add(new KeyValuePair<string, double>("dirt", 0.25));
            elements.Add(new KeyValuePair<string, double>("fire", 0.25));
            elements.Add(new KeyValuePair<string, double>("wind", 0.25));
            elements.Add(new KeyValuePair<string, double>("water", 0.25));

            Random r = new Random();
            double diceRoll = r.NextDouble();

            double cumulative = 0.0;
            for (int i = 0; i < elements.Count; i++)
            {
                cumulative += elements[i].Value;
                if (diceRoll < cumulative)
                {
                    string selectedElement = elements[i].Key;
                    //model = Globals.content.Load<Texture2D>(selectedElement);
                    name = selectedElement;
                    break;
                }
            }
            return name;
        }
        public string randomItem()
        {
            List<KeyValuePair<string, double>> elements = new List<KeyValuePair<string, double>>();
            String name = "";
            elements.Add(new KeyValuePair<string, double>("BlackHole", 0.01123));
            elements.Add(new KeyValuePair<string, double>("Titan", 0.02247));
            elements.Add(new KeyValuePair<string, double>("Banana", 0.02247));
            elements.Add(new KeyValuePair<string, double>("Jerry", 0.06741));
            elements.Add(new KeyValuePair<string, double>("Missile", 0.06741));
            elements.Add(new KeyValuePair<string, double>("Water", 0.26966));
            elements.Add(new KeyValuePair<string, double>("Flower", 0.26966));
            elements.Add(new KeyValuePair<string, double>("Letter", 0.26966));

            Random r = new Random();
            double diceRoll = r.NextDouble();

            double cumulative = 0.0;
            for (int i = 0; i < elements.Count; i++)
            {
                cumulative += elements[i].Value;
                if (diceRoll < cumulative)
                {
                    string selectedElement = elements[i].Key;
                    //model = Globals.content.Load<Texture2D>(selectedElement);
                    name = selectedElement;
                    break;
                }
            }
            return name;
        }

        public override void Update(GameTime gameTime)
        {

            rot = Globals.RotateTowards(pos, new Vector2(Globals.mouse.newMouse.X, Globals.mouse.newMouse.Y));

            if (item == null)
            {

                if (isThief)
                {
                    itemName = randomItem();
                    item = new obj("ammo/thief/" + itemName, new Vector2(pos.X, pos.Y - 20), this, new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y), new Vector2(10, 10), itemName);

                }

                else
                {
                    itemName = randomWand();
                    item = new obj("ammo/wizard/" + itemName, new Vector2(pos.X, pos.Y - 20), this, new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y), new Vector2(10, 10), itemName);

                    //GameGlobals.PassProjectile(new obj("ammo/thief/" + itemName, new Vector2(pos.X, pos.Y - 20), this, new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y), new Vector2(10, 10)));
                }
            }

            if (Globals.mouse.LeftClick())
            {
                owner.Firing();
                GameGlobals.PassProjectile(item);
                item = null;
            }

            base.Update(gameTime);
        }

        public override void Draw(Vector2 OFFSET)
        {
            float degree = isThief ? (float)(rot * 90 / 1.5) : 376 - (float)(rot * 90 / 1.5);
            item.Draw(OFFSET);
            Globals.spriteBatch.DrawString(engFonts, degree.ToString("0.00") + " D", new Vector2(pos.X - 30, pos.Y + 20), Color.White);
            base.Draw(OFFSET);

        }

    }
}
