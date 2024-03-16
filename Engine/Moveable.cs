using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
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

        public virtual void Update(GameTime gameTime)
        {
            Position += Velocity;
            if (AffectedByGravity)
            {
                Velocity += (float)gameTime.ElapsedGameTime.Milliseconds / 1000.0f * (Gravity + Accel);
            }

            // Check if we have hit the temporary floor at 784px and stop any characters from going below it
            if (Position.Y >= 784)
            {
                Position = new(Position.X, 784);
            }
        }
    }
}
