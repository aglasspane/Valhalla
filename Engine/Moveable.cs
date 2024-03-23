using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Moveable
    {
        public readonly Vector2 Gravity = new (0.0f, 9.8f);

        public Vector2 Position { get; set; } = Vector2.Zero;
        public Vector2 Velocity { get; set; } = Vector2.Zero;
        
        public Vector2 Accel { get; set; } = Vector2.Zero;

        public bool AffectedByGravity { get; set; } = true;

        public Direction Direction { get; set; } = Direction.Left;

        public bool InAir { get; protected set; } = false;

        public List<Collider> Colliders { get; protected set; } = new();

        public int Scale { get; } = 4;


        public virtual void Update(GameTime gameTime)
        {
            float dt = gameTime.ElapsedGameTime.Milliseconds / 1000.0f;

            Position += Velocity;
            if (InAir)
            {
                if (AffectedByGravity)
                {
                    Velocity += dt * Gravity;
                }

                // Check if we have hit the temporary floor at 784px and stop any characters from going below it
                if (Position.Y >= 784)
                {
                    Velocity = new(Velocity.X, 0);
                    Position = new(Position.X, 784);
                    Debug.WriteLine("Hit Floor: " + Position);
                    InAir = false;
                }
            }
            else if (Position.Y < 784)
            {
                InAir = true;
            }

            if(Position.X > 2000 - (64*4))
            {
                Velocity = new Vector2(0,Velocity.Y);
                Position = new Vector2(900,400);  
            }


            if (Position.X < 0)
            {
                Velocity = new Vector2(0, Velocity.Y);
                Position = new Vector2(900, 400);
            }

            // Deal with friction on the floor
            if(!InAir)
            {
                if (Math.Abs(Velocity.X) > 0)
                {
                    Vector2 decelleration = Vector2.Zero;
                    if (Velocity.X > 0)
                    {
                        decelleration = new Vector2(-5, 0);
                    }
                    else if (Velocity.X < 0)
                    {
                        decelleration = new Vector2(5, 0);
                    }
                    Velocity += dt * decelleration;
                }

                //if (Velocity.X <= 0 && Direction == Direction.Right)
                //{
                //    Accel = new Vector2(0, Accel.Y);
                //}
                //else if (!InAir && Velocity.X >= 0 && Direction == Direction.Left)
                //{
                //    Accel = new Vector2(0, Accel.Y);
                //}
            }
        }
        public virtual void Draw(GameTime gameTime, SpriteBatch? gd)
        {

                
        }
    }
}
