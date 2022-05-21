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

        public Arrow(String PATH, Vector2 POS, Vector2 DIMS, bool ISTHIEF, Player OWNER) : base(PATH, POS, DIMS, ISTHIEF)
        {
            speed = 2.0f;
            owner = OWNER;
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
                    item = new obj("ammo/thief/" + itemName, new Vector2(pos.X, pos.Y - 20), this, new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y), new Vector2(10, 10));

                }

                else
                {
                    itemName = "titan";
                    item = new obj("ammo/thief/" + itemName, new Vector2(pos.X, pos.Y - 20), this, new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y), new Vector2(10, 10));

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
            item.Draw(OFFSET);
            base.Draw(OFFSET);

        }

    }
}
