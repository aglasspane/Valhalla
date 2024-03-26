using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class GameWorld
    {
        public ContentManager Content { get; protected set; }

        public List<Moveable> Entities { get; protected set; } = new List<Moveable>();


        public GameWorld(ContentManager content)
        {
            Content = content;
        }

    }
}
