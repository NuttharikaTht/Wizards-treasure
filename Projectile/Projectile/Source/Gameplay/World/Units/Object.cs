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
    public class Object : Basic2D
    {
        public string pathImage;
        public Object(String PATH, Vector2 POS, Vector2 DIMS) : base(PATH, new Vector2(4, 400), DIMS)
        {

        }

        public override void Update()
        {
            if (Globals.keyboard.GetPress("A"))
            {
                pos = new Vector2(pos.X - 4, pos.Y);
            }

            if (Globals.keyboard.GetPress("D"))
            {
                pos = new Vector2(pos.X + 4, pos.Y);
            }

            if (Globals.keyboard.GetPress("R"))
            {
                List<KeyValuePair<string, double>> elements = new List<KeyValuePair<string, double>>();

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
                        model = Globals.content.Load<Texture2D>(selectedElement);
                        break;
                    }
                }
            }

            base.Update();
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
