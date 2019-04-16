using SFML.Graphics;
using SFML.Window;
using System;
using SFML.System;
using System.Windows.Forms;

namespace Game
{
    class Program
    {
        public static RenderWindow win;
        static Clock clock = new Clock();
        public static int score;
        public static int k;
        static void Main(string[] args)
        {
            Game game = new Game();
            score =0;
            win = new RenderWindow(new VideoMode(800, 600), "My Game");
            win.SetVerticalSyncEnabled(true);
            win.Closed += Win_Closed;
            win.Resized += Win_Resized;
            win.Size = new Vector2u(800, 600);

            Text textScore = new Text("", Content.font, 22);
            textScore.Position = new Vector2f(5, 5);
            Text textLifes = new Text("", Content.font, 22);
            textLifes.Position = new Vector2f(5, 34);
            textLifes.Color = Color.Red;
 
            Clock clock = new Clock();

            k = 0;
            while (win.IsOpen)
            {
                if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
                {
                    game.p.dx = -5.5f;
                    game.p.Direction = -1;
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
                {
                    game.p.dx = 5.5f;
                    game.p.Direction = 1;
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
                {
                    if (game.p.OnGround) { game.p.dy = -20f; game.p.OnGround = false; }
                }
                if(!Keyboard.IsKeyPressed(Keyboard.Key.Left) && !Keyboard.IsKeyPressed(Keyboard.Key.Right))
                {
                    game.p.dx = 0;
                }

                game.p.Update();

                if (game.p.rect.Left > 155 * 32 && game.p.rect.Top > 8 * 32)
                {
                    string s = Map.tilemap[7];
                    s = s.Remove(154, 2);
                    s = s.Insert(154, "88");
                    Map.tilemap[7] = s;
                }

                if (k == 0 && !game.enemies[4].Life && !game.enemies[5].Life && !game.enemies[6].Life && !game.enemies[7].Life)
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

                win.Draw(game.map);

                for (int i = 0; i < game.enemies.Length; i++)
                {
                    game.enemies[i].Update();
                    if (game.p.rect.Intersects(game.enemies[i].rect))
                    {
                        if (game.enemies[i].Life)
                        {
                            game.enemies[i].CollisionWithCharacter(game.p);
                        }
                    }
                    win.Draw(game.enemies[i]);
                }
                win.Draw(game.p);

                textScore.DisplayedString = "Количество очков: " +score.ToString();
                textLifes.DisplayedString = "Жизни: " + game.p.lifes.ToString();
                win.Draw(textScore);
                win.Draw(textLifes);
                win.Display();

                FPS();
            }
        }

        private static void Win_Resized(object sender, SizeEventArgs e)
        {
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
