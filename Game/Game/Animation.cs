using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public enum AnimationType
    {
        IDLE,
        RUNLEFT,
        RUNRIGHT,
        JUMP
    }

    class Animation : Transformable, Drawable
    {
        Animation(AnimationType type, int frame, Sprite sprite)
        {
            
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            throw new NotImplementedException();
        }
    }
}
