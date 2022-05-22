using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Projectile
{
    [Flags]
    public enum SlotsState
    {
        Walk = 0x0,
        Wall1 = 0x1,
        Wall2 = 0x2,
        Wall3 = 0x4,
        Wall4 = 0x8,
        Wall5 = 0x10,
    }
    public enum WallType
    {
        Non = 0x0,
        Dirt = 0x1,
        Water = 0x2,
        Wind = 0x4,
        Fire = 0x8,
    }
    public class Slots : Basic2D
    {
        public String type;
        public int index;
        private readonly int areaSize = 1;
        private SlotsState state;

        public SlotsState CurrentState
        {
            get { return state; }
            set { LoadModel(value); }
        }
        public WallType Element = WallType.Non;

        public Slots(Vector2 POS, int INDEX)
        {
            dims = new Vector2(40, 40);
            pos = POS;
            index = INDEX;

        }

        public Slots(WallType TYPE, Vector2 POS, int INDEX)
        {
            dims = new Vector2(40, 40);
            pos = POS;
            Element = TYPE;
            index = INDEX;
            rect = new Rectangle((int)pos.X, (int)pos.Y, (int)dims.X, (int)dims.Y);
            switch (Element)
            {
                case WallType.Dirt: type = "dirt"; break;
                case WallType.Water: type = "water"; break;
                case WallType.Wind: type = "wind"; break;
                case WallType.Fire: type = "fire"; break;
            }
        }

        public void LoadModel(SlotsState STATE)
        {
            state = STATE;
            switch (state)
            {
                case SlotsState.Walk:
                    dims = new Vector2(40, 40);
                    pos.Y = 572;
                    break;
                case SlotsState.Wall1:
                    dims = new Vector2(40, 40);
                    pos.Y = 572;
                    model = Globals.content.Load<Texture2D>("textures/wall/" + type + "/lv1");
                    rect = new Rectangle((int)pos.X, (int)pos.Y, model.Width, model.Height);
                    break;
                case SlotsState.Wall2:
                    dims = new Vector2(40, 90);
                    pos.Y = 547;
                    model = Globals.content.Load<Texture2D>("textures/wall/" + type + "/lv2");
                    rect = new Rectangle((int)pos.X, (int)pos.Y, model.Width, model.Height);
                    break;
                case SlotsState.Wall3:
                    dims = new Vector2(40, 180);
                    pos.Y = 502;
                    model = Globals.content.Load<Texture2D>("textures/wall/" + type + "/lv3");
                    rect = new Rectangle((int)pos.X, (int)pos.Y, model.Width, model.Height);
                    break;
                case SlotsState.Wall4:
                    dims = new Vector2(40, 300);
                    pos.Y = 442;
                    model = Globals.content.Load<Texture2D>("textures/wall/" + type + "/lv4");
                    rect = new Rectangle((int)pos.X, (int)pos.Y, model.Width, model.Height);
                    break;
                case SlotsState.Wall5:
                    pos.Y = 367;
                    dims = new Vector2(40, 450);
                    model = Globals.content.Load<Texture2D>("textures/wall/" + type + "/lv5");
                    rect = new Rectangle((int)pos.X, (int)pos.Y, model.Width, model.Height);
                    break;
            }
        }

        public void UpLevel(SlotsState STATE)
        {
            switch (STATE)
            {
                case SlotsState.Walk:
                    state = SlotsState.Wall1;
                    LoadModel(state);
                    break;
                case SlotsState.Wall1:
                    state = SlotsState.Wall2;
                    LoadModel(state);
                    break;
                case SlotsState.Wall2:
                    state = SlotsState.Wall3;
                    LoadModel(state);
                    break;
                case SlotsState.Wall3:
                    state = SlotsState.Wall4;
                    LoadModel(state);
                    break;
                case SlotsState.Wall4:
                    state = SlotsState.Wall5;
                    LoadModel(state);
                    break;
                case SlotsState.Wall5:
                    break;
            }
        }

        public void DownLevel()
        {
            switch (state)
            {
                case SlotsState.Walk:
                    DestroyWall();
                    break;
                case SlotsState.Wall1:
                    state = SlotsState.Walk;
                    LoadModel(state);
                    break;
                case SlotsState.Wall2:
                    state = SlotsState.Wall1;
                    LoadModel(state);
                    break;
                case SlotsState.Wall3:
                    state = SlotsState.Wall2;
                    LoadModel(state);
                    break;
                case SlotsState.Wall4:
                    state = SlotsState.Wall3;
                    LoadModel(state);
                    break;
                case SlotsState.Wall5:
                    state = SlotsState.Wall4;
                    LoadModel(state);
                    break;
            }
        }

        public void Drop()
        {
            switch (state)
            {
                case SlotsState.Walk:
                    break;
                case SlotsState.Wall1:
                    state = SlotsState.Walk;
                    LoadModel(state);
                    break;
                case SlotsState.Wall2:
                    state = SlotsState.Wall1;
                    LoadModel(state);
                    break;
                case SlotsState.Wall3:
                    state = SlotsState.Wall1;
                    LoadModel(state);
                    break;
                case SlotsState.Wall4:
                    state = SlotsState.Wall1;
                    LoadModel(state);
                    break;
                case SlotsState.Wall5:
                    state = SlotsState.Wall1;
                    LoadModel(state);
                    break;
            }
        }

        public void MergeWall(int INDEX)
        {
            Console.WriteLine(Globals.slots[INDEX].CurrentState);
            Globals.slots[INDEX].UpLevel(Globals.slots[INDEX].CurrentState);
            Console.WriteLine(Globals.slots[INDEX].CurrentState);
        }

        public void CheckArea(WallType wall)
        {

            if (Globals.slots[index].Element == wall)
            {
                UpLevel(Globals.slots[index].CurrentState);
            }
            else
            {

                int Left = index - areaSize, Right = index + areaSize;
                if (0 <= Left && Right < 26)
                {
                    if (Globals.slots[Left].Element == wall)
                    {
                        Console.WriteLine("Detect Left");
                        MergeWall(Left);
                    }
                    else if (Globals.slots[Right].Element == wall)
                    {
                        Console.WriteLine("Detect Right");
                        MergeWall(Right);
                    }
                    else { AddWall(index, wall); }
                }
                else
                {
                    if (Left < 0)
                    {
                        if (Globals.slots[Right].Element == wall)
                        {
                            Console.WriteLine("Detect Left");
                            MergeWall(Right);
                        }
                    }
                    else if (Right < 26)
                    {
                        if (Globals.slots[Left].Element == wall)
                        {
                            Console.WriteLine("Detect Left");
                            MergeWall(Left);
                        }
                    }
                    else { AddWall(index, wall); }
                }

            }

        }

        public int FindWall()
        {

            if (Globals.slots[index].Element != WallType.Non)
            {
                int Left = index - areaSize, Right = index + areaSize;
                if (0 <= Left && Right < 26)
                {
                    if (Globals.slots[Left].Element != WallType.Non)
                    {
                        Console.WriteLine("Detect Left");
                        return Left;
                    }
                    else if (Globals.slots[Right].Element != WallType.Non)
                    {
                        Console.WriteLine("Detect Right");
                        return Right;
                    }
                }
                else
                {
                    if (Left < 0)
                    {
                        if (Globals.slots[Right].Element != WallType.Non)
                        {
                            Console.WriteLine("Detect Left");
                            return Right;
                        }
                    }
                    else if (Right < 26)
                    {
                        if (Globals.slots[Left].Element != WallType.Non)
                        {
                            Console.WriteLine("Detect Left");
                            return Left;
                        }
                    }
                }

            }

            return index;

        }

        public void AddWall(int index, WallType wall)
        {
            Globals.slots[index] = new Slots(wall, new Vector2(80 + (40 * index), 572), index)
            {
                CurrentState = SlotsState.Wall1
            };

        }
        public void DestroyWall()
        {
            Globals.slots[index] = new Slots(WallType.Non, new Vector2(80 + (40 * index), 572), index)
            {
                CurrentState = SlotsState.Walk

            };
            Globals.slots[index].rect.Height = 0;
            Globals.slots[index].rect.Width = 0;

        }

        public void Update(GameTime gameTime, WallType wall)
        {
            CheckArea(wall);
            base.Update(gameTime);
        }

        public override void Draw(Vector2 OFFSET)
        {
            if (model != null)
            {
                Globals.spriteBatch.Draw(model, new Rectangle((int)(pos.X + OFFSET.X), (int)(pos.Y + OFFSET.Y), (int)dims.X, (int)dims.Y), null, Color.White, rot,
                    new Vector2(model.Bounds.Width / 2, model.Bounds.Height / 2), new SpriteEffects(), 0); ;
            }
        }

        //overload
        public override void Draw(Vector2 OFFSET, Vector2 ORIGIN)
        {
            if (model != null)
            {
                Globals.spriteBatch.Draw(model, new Rectangle((int)(pos.X + OFFSET.X), (int)(pos.Y + OFFSET.Y), (int)dims.X, (int)dims.Y), null, Color.White, rot,
                    new Vector2(ORIGIN.X, ORIGIN.Y), new SpriteEffects(), 0); ;
            }
        }
    }
}
