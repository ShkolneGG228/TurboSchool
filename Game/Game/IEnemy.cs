using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    interface IEnemy : Drawable
    {
        void Update();
        void CollisionWithCharacter(Player player);

        FloatRect Rect { get; set; }
        bool Life { get; set; }
        float DX { get; set; }
        float DY { get; set; }
    }

    public class MarioEnemy : IEnemy
    {
        const int SCORE_FOR_KILL = 5;
        float dx;
        public FloatRect rect;
        public bool life = true;
        Sprite sprite = new Sprite(Content.textureMario);
        float currentFrame;

        public MarioEnemy(int X, int Y, float DX)
        {
            dx = DX;
            rect = new FloatRect(X, Y, 48, 48);
            sprite.Scale = new Vector2f(3, 3);
        }

        public FloatRect Rect
        {
            get { return rect; }
            set { rect = value; }
        }

        public bool Life
        {
            get { return life; }
            set { life = value; }
        }
        
        public float DX
        {
            get { return dx; }
            set { dx = value; }
        }

        public float DY { get; set; } = 0;

        public void CollisionWithCharacter(Player player)
        {
            if (player.dy > 0)
            {
                Program.score += SCORE_FOR_KILL;
                life = false;
                dx = 0;
                player.dy -= 24f;
            }
            else
            {
                player.Damage(1);
                dx = -dx;
            }
        }

        public void Draw(RenderTarget target, RenderStates states)
        { 
            target.Draw(sprite);
        }

        public void Update()
        {
            rect.Left += dx;
            Collision();

            currentFrame += 0.1f;
            if (currentFrame > 2) currentFrame = 0;
            sprite.TextureRect = new IntRect((int)currentFrame * 18, 0, 16, 16);
            if (!life) sprite.TextureRect = new IntRect(58, 0, 18, 16);

            sprite.Position = new Vector2f(rect.Left - Player.offsetX, rect.Top);
        }

        void Collision()
        {
            for (int i = (int)rect.Top / 32; i < (rect.Top + rect.Height) / 32; i++)
                for (int j = (int)rect.Left / 32; j < (rect.Left + rect.Width) / 32; j++)
                {
                    if (Map.tilemap[i][j] == '0' || Map.tilemap[i][j] == 'I')
                    {
                        if (dx > 0) { rect.Left = j * 32 - rect.Width; }
                        if (dx < 0) { rect.Left = j * 32 + 32; }
                        dx = -dx;
                    }
                }
        }
    }
}
