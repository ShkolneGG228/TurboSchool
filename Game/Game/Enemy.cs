using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class Enemy : Drawable
    {
        public bool life = true;
        public float dx, dy, x, y;
        public Sprite sprite;
        public FloatRect rect;
        public int direction;
        public float currentFrame;
        public RectangleShape Rectangle = new RectangleShape();

        public Enemy(float X, float Y)
        {
            x = X;
            y = Y;
        }

        public float DX
        {
            get { return dx; }
            set { dx = value; }
        }

        public float DY
        {
            get { return dy; }
            set { dy = value; }
        }

        public bool Life
        {
            get { return life; }
            set { life = value; }
        }

        public abstract void Update();
        public abstract void CollisionWithCharacter(Player player);

        public void Draw(RenderTarget target, RenderStates states)
        {
            Rectangle.FillColor = Color.Red;
            //target.Draw(Rectangle);
            target.Draw(sprite);
        }
    }

    public class Bat : Enemy
    {
        const int SCORE_FOR_KILL = 7;
        float time;
        Clock clock = new Clock();

        public Bat(float X, float Y, float DX, float DY) : base(X,Y)
        {
            dx = DX;
            dy = dx/2;
            sprite = new Sprite(Content.MonsterEnemy);
            sprite.Scale = new Vector2f(2, 2);
            rect = new FloatRect(X, Y, 39 * 2, 46 * 2-16);
            Rectangle = new RectangleShape(new Vector2f(39 * 2, 46 * 2-16));
        }

        public override void CollisionWithCharacter(Player player)
        {
            if (player.dy > 0 && player.rect.Top < rect.Top)
            {
                Program.score += SCORE_FOR_KILL;
                life = false;
                if (dy < 0) { dy = -dy; }
                dy *= 3f;
                dx = 0;
                player.dy = -10f;
                sprite.TextureRect = new IntRect(103, 336, 35, 43);
                sprite.Scale = new Vector2f(2, 1.1f);
                rect.Height = rect.Height * 0.4f;
            }
            else
            {
                player.Damage(1);
            }
        }

        public override void Update()
        {
            rect.Left += dx;
            Collision(0);
            rect.Top += dy;
            Collision(1);
            currentFrame += 0.2f;
            if (currentFrame > 3f) currentFrame = 0;
            if (dx > 0) { sprite.TextureRect = new IntRect((39 + 12) * (int)currentFrame, 288, 39, 46); }
            if (dx < 0) { sprite.TextureRect = new IntRect((39 + 12) * (int)currentFrame + 39, 288, -39, 46); }

            sprite.Position = new Vector2f(rect.Left - Player.offsetX, rect.Top - Player.offsetY - 8);
            Rectangle.Position = new Vector2f(rect.Left - Player.offsetX, rect.Top - Player.offsetY);
        }

        void Collision(int dir)
        {
            for (int i = (int)rect.Top / 32; i < (rect.Top + rect.Height) / 32; i++)
                for (int j = (int)rect.Left / 32; j < (rect.Left + rect.Width) / 32; j++)
                {
                    if (Map.tilemap[i][j] == 'B' || Map.tilemap[i][j] == 'Q' || Map.tilemap[i][j] == 'I' || Map.tilemap[i][j] == '0' || Map.tilemap[i][j] == '8')
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

    public class EnemyMario : Enemy
    {
        const int SCORE_FOR_KILL = 3;
        bool OnGround;

        public EnemyMario(int X,int Y,float DX) : base(X, Y)
        {
            dx = DX;
            sprite = new Sprite(Content.textureMario);
            sprite.Scale = new Vector2f(3, 3);
            rect = new FloatRect(X, Y, 48, 48);
        }
        public override void CollisionWithCharacter(Player player)
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

        public override void Update()
        {
            rect.Left += dx;

            if (dx > 0) { direction = 1; }
            if (dx < 0) { direction = -1; }
            Collision(0);

            if (!OnGround) dy += 1f;
            rect.Top += dy;
            OnGround = false;
            Collision(1);

            currentFrame += 0.1f;
            if (currentFrame > 2) currentFrame = 0;
            sprite.TextureRect = new IntRect((int)currentFrame * 18, 0, 16, 16);
            if (!life) sprite.TextureRect = new IntRect(58, 0, 18, 16);

            sprite.Position = new Vector2f(rect.Left - Player.offsetX, rect.Top - Player.offsetY);
        }

        void Collision(int dir)
        {
            for (int i = (int)rect.Top / 32; i < (rect.Top + rect.Height) / 32; i++)
                for (int j = (int)rect.Left / 32; j < (rect.Left + rect.Width) / 32; j++)
                {
                    if (Map.tilemap[i][j] == '0' || Map.tilemap[i][j] == 'I' || Map.tilemap[i][j] == '8' || Map.tilemap[i][j] == 'K' || Map.tilemap[i][j] == 'B')
                    {
                        if(dir == 0)
                        {
                            if (dx > 0) { rect.Left = j * 32 - rect.Width; }
                            if (dx < 0) { rect.Left = j * 32 + 32; }
                            dx = -dx;
                        }
                        if (dir == 1)
                        {
                            rect.Top = i * 32 - rect.Height; dy = 0; OnGround = true;
                        }
                    }
                }
        }
    }
}
