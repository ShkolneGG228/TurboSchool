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

    public class Bat : IEnemy
    {
        const int SCORE_FOR_KILL = 7;

        FloatRect rect;
        bool life = true;
        float dx, dy;

        Clock clock = new Clock();
        float time;
        float currentFrame;

        Sprite sprite = new Sprite();

        public Bat(int X, int Y, float Speed)
        {
            dx = dy = Speed;
            rect = new FloatRect(X, Y, 39*2, 46*2);
            sprite.Texture = Content.MonsterEnemy;
            sprite.TextureRect = new IntRect((39+12)*0, 288, 39, 46);
            sprite.Scale = new Vector2f(2, 2);
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
            set { dx = value; }
            get { return dx; }
        }

        public float DY
        {
            set { dy = value; }
            get { return dy; }
        }

        public void CollisionWithCharacter(Player player)
        {
            if(player.dy>0 && player.rect.Top < rect.Top)
            {
                Program.score += SCORE_FOR_KILL;
                life = false;
                if (dy < 0) { dy = -dy; }
                dy *= 3f;
                dx = 0;
                player.dy = -10f;
                sprite.TextureRect = new IntRect(103, 336, 35, 43);
                sprite.Scale = new Vector2f(2, 1.3f);
                rect.Height = rect.Height*0.4f;
            }
            else
            {
                player.Damage(1);
            }
        }

        public void Draw(RenderTarget target, RenderStates states)
        {   
            target.Draw(sprite); 
        }

        public void Update()
        {
            rect.Left += dx;
            Collision(0);
            rect.Top += dy;
            Collision(1);
            currentFrame += 0.2f;
            if (currentFrame > 3f) currentFrame = 0;
            if (dx > 0) { sprite.TextureRect = new IntRect((39 + 12) * (int)currentFrame, 288, 39, 46); }
            if (dx < 0) { sprite.TextureRect = new IntRect((39 + 12) * (int)currentFrame+39, 288, -39, 46); }

            sprite.Position = new Vector2f(rect.Left - Player.offsetX, rect.Top-Player.offsetY);
        }

        void Collision(int dir)
        {
            for (int i = (int)rect.Top / 32; i < (rect.Top + rect.Height) / 32; i++)
                for (int j = (int)rect.Left / 32; j < (rect.Left + rect.Width) / 32; j++)
                {
                    if (Map.tilemap[i][j] == 'B' || Map.tilemap[i][j] == 'Q' || Map.tilemap[i][j] == 'I' || Map.tilemap[i][j]=='0' || Map.tilemap[i][j] == '8')
                    {
                            if (dir == 0)
                            {
                                if (dx > 0) { rect.Left = j * 32 - rect.Width; }
                                if (dx < 0) { rect.Left = j * 32 + 32; }
                                dx = -dx;
                            }
                            if (dir == 1)
                            {
                                if (time + 200 < clock.ElapsedTime.AsMilliseconds())
                                {
                                    if (dy > 0) { rect.Top = i * 32 - rect.Height; }
                                    if (dy < 0) { rect.Top = i * 32 + 32; }
                                    if (life) { dy = -dy; } else { dy = 0; }
                                    time = clock.ElapsedTime.AsMilliseconds();
                                }
                            }
                    }
                }
        }
    }

    public class MarioEnemy : IEnemy
    {
        const int SCORE_FOR_KILL = 3;

        float dx;
        public FloatRect rect;
        public bool life = true;
        int direction;

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
                player.dy = -10f;
            }
            else
            {
                player.Damage(1);
                if (player.Direction != direction)
                {
                    dx = -dx;
                }
            }
        }

        public void Draw(RenderTarget target, RenderStates states)
        { 
            target.Draw(sprite);
        }

        public void Update()
        {
            rect.Left += dx;

            if (dx > 0) { direction = 1; }
            if (dx < 0) { direction = -1; }
            Collision();

            currentFrame += 0.1f;
            if (currentFrame > 2) currentFrame = 0;
            sprite.TextureRect = new IntRect((int)currentFrame * 18, 0, 16, 16);
            if (!life) sprite.TextureRect = new IntRect(58, 0, 18, 16);

            sprite.Position = new Vector2f(rect.Left - Player.offsetX, rect.Top - Player.offsetY);
        }

        void Collision()
        {
            for (int i = (int)rect.Top / 32; i < (rect.Top + rect.Height) / 32; i++)
                for (int j = (int)rect.Left / 32; j < (rect.Left + rect.Width) / 32; j++)
                {
                    if (Map.tilemap[i][j] == '0' || Map.tilemap[i][j] == 'I' || Map.tilemap[i][j] == '8' || Map.tilemap[i][j] == 'K')
                    {
                        if (dx > 0) { rect.Left = j * 32 - rect.Width; }
                        if (dx < 0) { rect.Left = j * 32 + 32; }
                        dx = -dx;
                    }
                }
        }
    }
}
