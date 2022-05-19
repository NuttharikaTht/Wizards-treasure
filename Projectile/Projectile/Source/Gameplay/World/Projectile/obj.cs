﻿using System;
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

        public obj(String PATH, Vector2 POS, Unit OWNER, Vector2 TARGET)
            : base(PATH, POS, new Vector2(40,40), OWNER, TARGET)
        {
            initialPosition = new Vector2(100, 400);
            initialVelocity = new Vector2(10, 10);
            acceleration = new Vector2(0, -9.8f);
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