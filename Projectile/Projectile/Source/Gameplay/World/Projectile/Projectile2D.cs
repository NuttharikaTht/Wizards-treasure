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
    public class Projectile2D : Basic2D
    {
        public bool done;

        public Vector2 initialPosition;
        public Vector2 initialVelocity;
        public Vector2 acceleration;

        public float time = 0;
        //public Vector2 position = Vector2.Zero;

        public Vector2 direction;
        public Unit owner;

        public McTimer timer;

        public Projectile2D(String PATH, Vector2 POS, Vector2 DIMS, Unit OWNER, Vector2 TARGET)
            : base(PATH, POS, DIMS)
        {
            owner = OWNER;

            rot = Globals.RotateTowards(pos, new Vector2(TARGET.X, TARGET.Y));

            direction = TARGET - owner.pos;
            direction.Normalize();


            //pos = initialPosition;

            //timer = new McTimer(12000);
        }

        public virtual void Update(GameTime gameTime, Vector2 OFFSET, List<Unit> UNITS)
        {
            int direc = owner.isThief ? 1 : -1;

            time += (float)gameTime.ElapsedGameTime.TotalSeconds;
            //pos = initialPosition + initialVelocity * time + 0.5f * acceleration * time * time;
            pos.X += direction.X * (((float)Globals.Power/10) * (float)Math.Cos(rot) * time);
            pos.Y += direction.Y * ((((float)Globals.Power / 10) * (direc * (float)Math.Sin(rot)) * time) - (0.5f * 9.8f * time * time));
        }

        public override void Draw(Vector2 OFFSET)
        {

            base.Draw(OFFSET);

        }
        public virtual bool IsHit(List<Unit> UNITS)
        {
            return false;
        }
    }
}
