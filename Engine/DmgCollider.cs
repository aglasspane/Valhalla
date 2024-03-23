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

        protected float howMuchDmg;

        private bool _dealtDamage = false;


        public DmgCollider(Moveable owner, Rectangle bounds, float howMuchDmg, Vector2 knockBack) : this(owner, bounds, howMuchDmg)
        {
            _knockBack = knockBack;
        }

        public DmgCollider(Moveable owner, Rectangle bounds, float howMuchDmg) : base(owner, bounds)
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
                
                _dealtDamage = true;
                if(target is Character)
                {
                    ((Character)target).PercentDmgValue += howMuchDmg;
                }
                if (Owner.Direction == Direction.Left)
                {
                    target.Velocity += _knockBack;
                    //target.Accel = new Vector2(10, 0);
                    Debug.WriteLine("Knockback Left: " + target.Velocity);
                }
                else
                {
                    target.Velocity += _knockBack;
                    //target.Accel = new Vector2(-10, 0);
                    Debug.WriteLine("Knockback Right: " + target.Velocity);
                }
            }
            
            
                
        }

    }
}
