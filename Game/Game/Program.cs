using SFML.Graphics;
using SFML.Window;
using System;
using SFML.System;

namespace Game
{
    class Program
    {

        public static RenderWindow win;
        static Clock clock = new Clock();
        public static int score;
        static void Main(string[] args)
        {
            score=0;
            win = new RenderWindow(new VideoMode(800, 600), "My Game");
            win.SetVerticalSyncEnabled(true);
            win.Closed += Win_Closed;
            win.Resized += Win_Resized;
            win.Size = new Vector2u(800, 600);

            Content.Load();

            Text textScore = new Text("", Content.font, 22);
            textScore.Position = new Vector2f(5, 5);
            Text textLifes = new Text("", Content.font, 22);
            textLifes.Position = new Vector2f(5, 34);
            textLifes.Color = Color.Red;

            Player p = new Player();

            Enemy[] enemies = new Enemy[8];
            enemies[0] = new EnemyMario(700,20*32+19,1f);
            enemies[1] = new EnemyMario(32*75, 32*16+16,5f);
            enemies[2] = new EnemyMario(32 * 97, 20*32+19,2f);
            enemies[3] = new Bat(900, 400, 5f, 5f);
            enemies[4] = new Bat(32 * 160, 500, 3f, 3f);
            enemies[5] = new Bat(32 * 155, 300, -3f, 3f);
            enemies[6] = new EnemyMario(32 * 155, 20*32+19, 2f);
            enemies[7] = new EnemyMario(32 * 169, 20*32+19, -2f);

            Map map = new Map();
            map.GenerateWorld();
            RectangleShape rect = new RectangleShape();
            Clock clock = new Clock();

            int k = 0;
            while (win.IsOpen)
            {
                if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
                {
                    p.dx = -5.5f;
                    p.Direction = -1;
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
                {
                    p.dx = 5.5f;
                    p.Direction = 1;
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
                {
                    if (p.OnGround) { p.dy = -20f; p.OnGround = false; }
                }
                if(!Keyboard.IsKeyPressed(Keyboard.Key.Left) && !Keyboard.IsKeyPressed(Keyboard.Key.Right))
                {
                    p.dx = 0;
                }

                p.Update();

                if (p.rect.Left > 155 * 32 && p.rect.Top > 8 * 32)
                {
                    string s = Map.tilemap[7];
                    s = s.Remove(154, 2);
                    s = s.Insert(154, "88");
                   // k++;
                    Map.tilemap[7] = s;
                }

                if (k == 0 && !enemies[4].Life && !enemies[5].Life && !enemies[6].Life && !enemies[7].Life)
                {
                    string s = Map.tilemap[20];
                    s = s.Remove(174, 1);
                    s = s.Insert(174, " ");
                    Map.tilemap[20] = s;
                    s = Map.tilemap[21];
                    s = s.Remove(154, 21);
                    s = s.Insert(154, "SSSSSSSSSSSSSSSSSSSS ");
                    Map.tilemap[21] = s;
                    k++;
                }
                


                win.DispatchEvents();

                win.Clear(Color.Black);

                win.Draw(map);

                for (int i = 0; i < enemies.Length; i++)
                {
                    enemies[i].Update();
                    if (p.rect.Intersects(enemies[i].rect))
                    {
                        if (enemies[i].Life)
                        {
                            enemies[i].CollisionWithCharacter(p);
                        }
                    }
                    win.Draw(enemies[i]);
                }
                win.Draw(p);

                textScore.DisplayedString = "Количество очков: " +score.ToString();
                textLifes.DisplayedString = "Жизни: " + p.lifes.ToString();
                win.Draw(textScore);
                win.Draw(textLifes);
                win.Display();

                FPS();
            }
        }

        private static void Win_Resized(object sender, SizeEventArgs e)
        {
            //win.SetView(new View(new FloatRect(0, 0, e.Width, e.Height)));
            win.Size = new Vector2u(800, 600);
        }

        private static void Win_Closed(object sender, EventArgs e)
        {
            win.Close();
        }
        private static void FPS()
        {
            Time time = clock.ElapsedTime;
            win.SetTitle("FPS : " + (1.0f / time.AsSeconds()).ToString());
            clock.Restart();
        }
    }
}
