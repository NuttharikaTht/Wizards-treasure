﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Projectile
{
    public class Singleton
    {
        public Vector2 Diemensions = new Vector2(1200, 600);
        public int Score = 0;
        public string BestScore = "0";


        private static Singleton instance;
        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
    }
}
