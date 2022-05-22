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
    public delegate void passObject(object i);
    public delegate void passObjectAndeReturn(object i);

    [Flags]
    public enum WhoPlay
    {
        Thief,
        Wizard,
    }
    public enum WhoWin
    {
        Non,
        Thief,
        Wizard,
    }

    public class Globals
    {
        public static int screenWidth, screenHeight;
        public static float timer;

        static int power = 0;
        public static int Power
        {
            get { return power; }
            set { if (value >= 0 && value <= 100) power = value; }
        }
        public static float LimitStamina = 100;

        static WhoPlay currentPlayer;
        public static WhoPlay CurrentPlayer
        {
            get { return currentPlayer; }
            set { currentPlayer = value; }
        }
        static WhoWin currentStatus;
        public static WhoWin CurrentStatus
        {
            get { return currentStatus; }
            set { currentStatus = value; }
        }
        public static Slots[] slots = new Slots[26]; 

        public static ContentManager content;
        public static SpriteBatch spriteBatch;

        public static McKeyboard keyboard;
        public static McMouseControl mouse;

        public static GameTime gameTime;

        public static SoundControl soundControl;

        public static void ResetTimer() {
            timer = 15;
        }
        public static void SwapPlayer() {
            CurrentPlayer = CurrentPlayer == WhoPlay.Thief ? WhoPlay.Wizard : WhoPlay.Thief;

            power = 0;
            LimitStamina = 100;
            ResetTimer();
        }

        public static float GetDistance(Vector2 pos, Vector2 target)
        {
            return (float)Math.Sqrt(Math.Pow(pos.X - target.X, 2) + Math.Pow(pos.Y - target.Y, 2));
        }

        public static float RotateTowards(Vector2 Pos, Vector2 focus)
        {
            float h, sineTheta, angle;

            if (Pos.Y - focus.Y != 0)
            {
                h = (float)Math.Sqrt(Math.Pow(Pos.X - focus.X, 2) + Math.Pow(Pos.Y - focus.Y, 2));
                sineTheta = (float)(Math.Abs(Pos.Y - focus.Y) / h); //* ((item.Pos.Y-focus.Y)/(Math.Abs(item.Pos.Y-focus.Y))));
            }
            else
            {
                h = Pos.X - focus.X;
                sineTheta = 0;
            }

            angle = (float)Math.Asin(sineTheta);

            // Drawing diagonial lines here.
            //Quadrant 2
            if (Pos.X - focus.X > 0 && Pos.Y - focus.Y > 0)
            {
                angle = (float)(Math.PI * 3 / 2 + angle);
            }
            //Quadrant 3
            else if (Pos.X - focus.X > 0 && Pos.Y - focus.Y < 0)
            {
                angle = (float)(Math.PI * 3 / 2 - angle);
            }
            //Quadrant 1
            else if (Pos.X - focus.X < 0 && Pos.Y - focus.Y > 0)
            {
                angle = (float)(Math.PI / 2 - angle);
            }
            else if (Pos.X - focus.X < 0 && Pos.Y - focus.Y < 0)
            {
                angle = (float)(Math.PI / 2 + angle);
            }
            else if (Pos.X - focus.X > 0 && Pos.Y - focus.Y == 0)
            {
                angle = (float)Math.PI * 3 / 2;
            }
            else if (Pos.X - focus.X < 0 && Pos.Y - focus.Y == 0)
            {
                angle = (float)Math.PI / 2;
            }
            else if (Pos.X - focus.X == 0 && Pos.Y - focus.Y > 0)
            {
                angle = (float)0;
            }
            else if (Pos.X - focus.X == 0 && Pos.Y - focus.Y < 0)
            {
                angle = (float)Math.PI;
            }

            return angle;
        }
    }
}
