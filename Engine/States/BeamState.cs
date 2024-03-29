using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.States
{
    internal class BeamState : State
    {
        private DmgCollider? dmgCollider;
        private const float Dmg = 25f;

        private Texture2D beamSpritesheet;
        public BeamState(List<AnimationFrame> framesw, Texture2D beamSpritesheet) : base(framesw)
        {
            this.beamSpritesheet = beamSpritesheet;

        }
        public override string? NextStateName(Action? currentAction, Moveable moveable, GameWorld _world)
        {
            string? stateName = null;
            if (dmgCollider == null)
            {
                if (moveable.Direction == Direction.Right)
                {
                    dmgCollider = new DmgCollider(moveable, new Rectangle(40, 8, 400, 64), Dmg, new Vector2(10, 0));

                }
                else
                {
                    dmgCollider = new DmgCollider(moveable, new Rectangle(-365, 8, 400, 64), Dmg, new Vector2(-10, 0));

                }
                moveable.Colliders.Add(dmgCollider);
            }

            if (Finished)
            {
                stateName = "idle";
                DeleteCollider(moveable);
            }


            return stateName;


        }

        public override void Draw(GameTime gameTime, SpriteBatch sb, Moveable moveable)
        {
            base.Draw(gameTime, sb, moveable);    
            if (dmgCollider != null) 
            {
                SpriteEffects spriteEffects = SpriteEffects.None;   
                if(moveable.Direction == Direction.Left)
                {
                    spriteEffects = SpriteEffects.FlipHorizontally;
                    Rectangle r = dmgCollider.Bounds;
                    r.Offset(moveable.Position);
                    r.Width = dmgCollider.Bounds.Width - (160 * moveable.Scale);
                    sb.Draw(beamSpritesheet, r, new Rectangle(160, 2032, 96, 160), Color.White, 0, Vector2.Zero, spriteEffects, 0f);
                    r.X += 228 * moveable.Scale;
                    r.Width = 160 * moveable.Scale;
                    sb.Draw(beamSpritesheet, r, new Rectangle(0, 2032, 160, 160), Color.White, 0, Vector2.Zero, spriteEffects, 0f);

                }
                else
                {
                    Rectangle r = dmgCollider.Bounds;
                    r.Offset(moveable.Position);
                    r.Width = 160 * moveable.Scale;
                    sb.Draw(beamSpritesheet, r, new Rectangle(0, 2032, 160, 160), Color.White, 0, Vector2.Zero, spriteEffects, 0f);
                    r.X += 160 * moveable.Scale;
                    r.Width = dmgCollider.Bounds.Width - (160 * moveable.Scale);
                    sb.Draw(beamSpritesheet, r, new Rectangle(160, 2032, 96, 160), Color.White, 0, Vector2.Zero, spriteEffects, 0f);

                }

            }

        }
        private void DeleteCollider(Moveable moveable)
        {
            if (dmgCollider != null)
            {
                moveable.Colliders.Remove(dmgCollider);
                dmgCollider = null;
            }
        }
    }
}
