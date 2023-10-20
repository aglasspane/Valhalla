using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class MenuScreen : Screen
    {
        public override void Update(GameTime gameTime)
        {
            Console.WriteLine("Updating Menu Screen");
        }
        public override void Draw(GameTime gameTime)
        {
            Console.WriteLine("Drawing Menu Screen");
        }
    }
}
