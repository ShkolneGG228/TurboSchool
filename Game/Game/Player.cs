using SFML.Graphics;
using SFML.System;

namespace Game
{
    class Player : Transformable, Drawable
    {

        public float dx = 0, dy = 0;
        public bool OnGround = false;
        public int Direction = 0;

        public static float offsetX = 0;
        public double currentFrame = 0;

        static FloatRect rect = new FloatRect();

        static Sprite player;

        public static void Load()
        {
            player = new Sprite();
            player.Texture = Content.texturePlayer;
            player.TextureRect =new IntRect(0, 0, 32, 32);
            player.Scale = new Vector2f(2f, 2f);
            rect = new FloatRect(100, 50, 64, 64);
        }

        public void Update()
        {
            rect.Left += dx;
            Collision(0);
            if (!OnGround) dy += 1f;

            rect.Top += dy;

            OnGround = false;
            Collision(1);

            if (currentFrame > 4) { currentFrame = 0; }
                        
            if (dx > 0) { player.TextureRect = new IntRect((int)currentFrame * (32 + 15) + 190, 0, 32, 32); currentFrame += 0.2; }
            
            if (dx < 0) { player.TextureRect = new IntRect((int)currentFrame * (32 + 15) + 190 + 32, 0, -32, 32); currentFrame += 0.2; }

            if (dx == 0)
            {
                if (Direction == 1)
                {
                    player.TextureRect = new IntRect((int)currentFrame * (32 + 15), 0, 32, 32); currentFrame += 0.1;
                }
                if(Direction == -1)
                {
                    player.TextureRect = new IntRect((int)currentFrame * (32 + 15) + 32, 0, -32, 32); currentFrame += 0.1;
                }
            }

            player.Position = new Vector2f(rect.Left - offsetX, rect.Top);

            if(rect.Left>400 && rect.Left<Map.WORLD_WIDTH*24)offsetX = rect.Left - 800/2;
        }

        void Collision(int dir)
        {
            for(int i =(int)rect.Top/32;i<(rect.Top+rect.Height)/32;i++)
                for(int j = (int)rect.Left / 32; j < (rect.Left + rect.Width) / 32; j++)
                {
                    if (Map.tilemap[i][j] == 'B' || Map.tilemap[i][j] == '0' || Map.tilemap[i][j] == 'Q')
                    {
                        if ((dx > 0)&&(dir==0)) { rect.Left = j * 32 - rect.Width; }
                        if ((dx < 0) && (dir == 0)) { rect.Left = j * 32 + 32; }
                        if ((dy > 0) && (dir == 1)) { rect.Top = i * 32 - rect.Height;dy = 0;OnGround = true;}
                        if ((dy < 0) && (dir == 1)) { rect.Top = i * 32+32;dy = 0; OnGround = false; }
                    }
                }
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(player);
        }
    }
}
