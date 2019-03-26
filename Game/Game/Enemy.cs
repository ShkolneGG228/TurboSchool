using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Enemy : Transformable, Drawable
    {
        
        public float dx = -5f;
        public FloatRect rect=new FloatRect(200,new Random().Next(500) , 16*3, 16*3);
        static Sprite sprite;
        float currenttime = 0;
        public bool life = true;

        public Enemy() { }

        public Enemy(int x, int y)
        {
            rect.Left = x;
            rect.Top = y;
        }
        
        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(sprite);
        }

        public static void Load()
        {
            sprite = new Sprite();
            sprite.Texture = new Texture(Content.textureMario);
            sprite.TextureRect = new IntRect(0, 0, 16*3,16*3);
            sprite.Scale = new Vector2f(3, 3);
        }

        public void Update()
        {
            
            rect.Left += dx;
            Collision();

            currenttime += 0.1f;
            if (currenttime > 2) currenttime = 0;
            sprite.TextureRect = new IntRect((int)currenttime * 18, 0, 16, 16);
            if (!life) sprite.TextureRect = new IntRect(54, 0, 18, 16);

            sprite.Position = new Vector2f(rect.Left - Player.offsetX, rect.Top);
        }

        void Collision()
        {
            for (int i = (int)rect.Top / 32; i < (rect.Top + rect.Height) / 32; i++)
                for (int j = (int)rect.Left / 32; j < (rect.Left + rect.Width) / 32; j++)
                {
                    if (Map.tilemap[i][j] == '0'||Map.tilemap[i][j] == 'I')
                    {
                        if(dx > 0) { rect.Left = j * 32 - rect.Width;}
                        if (dx < 0) { rect.Left = j * 32 + 32; }
                        dx = -dx;
                    }
                }
        }
    }
}
