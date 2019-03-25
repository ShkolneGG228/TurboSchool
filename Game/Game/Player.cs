using SFML.Graphics;
using SFML.System;

namespace Game
{
    class Player : Transformable, Drawable
    {
        public const int HEIGHT_MAP = 25;
        public const int WIDTH_MAP = 51;

        public float dx = 0, dy = 0;
        public bool OnGround = false;
        public int Direction = 0;
        public double currentFrame = 0;

        int ground = 250;

        static FloatRect rect = new FloatRect();

        static Sprite player;

        public static void Load()
        {
            player = new Sprite();
            player.Texture = Content.texturePlayer;
            player.TextureRect =new IntRect(0, 0, 32, 32);
            player.Scale = new Vector2f(2, 2);
            rect = new FloatRect(0, 0, 250, 300);
        }

        public void Update()
        {
            rect.Left += dx;
            if (!OnGround) dy += 1f;

            rect.Top += dy;

            OnGround = false;

            if(rect.Top> ground) { rect.Top = ground; dy=0; OnGround = true; }



            if (currentFrame > 4) { currentFrame = 0; }
            
            
            if (dx > 0) { player.TextureRect = new IntRect((int)currentFrame * (32 + 15) + 190, 0, 32, 32); currentFrame += 0.2; }
            
            if (dx < 0) { player.TextureRect = new IntRect((int)currentFrame * (32 + 15) + 190 + 32, 0, -32, 32); currentFrame += 0.2; }
            
            if (Direction == 1)
            {
                if (dx == 0) { player.TextureRect = new IntRect((int)currentFrame * (32 + 15), 0, 32, 32); currentFrame += 0.1; }
            }
            if (Direction == -1)
            {
                if (dx == 0) { player.TextureRect = new IntRect((int)currentFrame * (32 + 15) + 32, 0, -32, 32); currentFrame += 0.1; }
            }

            player.Position = new Vector2f(rect.Left, rect.Top);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(player);
        }
    }
}
