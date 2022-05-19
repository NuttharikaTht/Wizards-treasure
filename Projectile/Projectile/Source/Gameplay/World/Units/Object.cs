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
        public Object(String PATH, Vector2 POS, Vector2 DIMS) : base(PATH, new Vector2(4, 400), DIMS)
        {

        }

        public override void Update()
        {
            

            base.Update();
        }

        public override void Draw()
        {

            base.Draw();
        }

    }
}
