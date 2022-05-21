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
    public class obj : Projectile2D
    {
        public String type;
        public obj(String PATH, Vector2 POS, Unit OWNER, Vector2 TARGET, Vector2 Velocity, String TYPE)
            : base(PATH, POS, new Vector2(40, 40), OWNER, TARGET)
        {

            initialPosition = new Vector2(POS.X, POS.Y);
            initialVelocity = Velocity; //new Vector2(10, 10);
            acceleration = new Vector2(0, -9.8f);
            isHit = false;
            isDone = false;
            type = TYPE;
            //done = false;
        }

        public override void Update(GameTime gameTime, Vector2 OFFSET, List<Unit> UNITS)
        {
            base.Update(gameTime, OFFSET, UNITS);
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }

    }
}
