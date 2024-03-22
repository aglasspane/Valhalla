using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    internal class DmgCollider : Collider
    {

        public bool CausesKnockback = true;

        public Vector2 _knockBack = Vector2.Zero;

        protected double howMuchDmg;

        private bool _dealtDamage = false;


        public DmgCollider(Moveable owner, Rectangle bounds, double howMuchDmg, Vector2 knockBack) : this(owner, bounds, howMuchDmg)
        {
            _knockBack = knockBack;
        }

        public DmgCollider(Moveable owner, Rectangle bounds, double howMuchDmg) : base(owner, bounds)
        {
            this.howMuchDmg = howMuchDmg;
        }

        public void Update(GameTime gameTime, Moveable moveable) 
        {

        }
        


        public override void handleCollision(Moveable target)
        {
            base.handleCollision(target);
            
            if(CausesKnockback && !_dealtDamage)
            {
                Debug.WriteLine("Dealt damage" + howMuchDmg);
                _dealtDamage = true;
                if (Owner.Direction == Direction.Left)
                {
                    target.Velocity += _knockBack;
                    Debug.WriteLine("Knockback Left: " + target.Velocity);
                }
                else
                {
                    target.Velocity += _knockBack;
                    Debug.WriteLine("Knockback Right: " + target.Velocity);
                }
            }
            
                
        }

    }
}
