using SFML.Graphics;
using SFML.Window;
using System;
using SFML.System;

namespace Game
{
    //TODO: The parent class for enemies and other enemies
    //      Update map and create GameOver and Restart Game
    //      Create the class bullet and realize skying rockets
    //      Menu maybe - would be nice
    class Program
    {

        public static RenderWindow win;
        static Clock clock = new Clock();
        public static int score;
        static void Main(string[] args)
        {
            float time = 0;

            score=0;
            win = new RenderWindow(new VideoMode(800, 600), "My Game");
            win.SetVerticalSyncEnabled(true);

            win.Closed += Win_Closed;
            win.Resized += Win_Resized;

            Content.Load();

            Text textScore = new Text("", Content.font, 22);
            textScore.Position = new Vector2f(5, 0);
            Text textLifes = new Text("", Content.font, 22);
            textLifes.Position = new Vector2f(5, 32);
            textLifes.Color = Color.Red;

            Player p = new Player();

            IEnemy[] enemies = new MarioEnemy[3];
            enemies[0] = new MarioEnemy(600, 500,1f);
            enemies[1] = new MarioEnemy(32*75, 366,5f);
            enemies[2] = new MarioEnemy(32 * 97, 500,2f);

            SecondEnemy enemy = new SecondEnemy(200,300);

            Map map = new Map();
            map.GenerateWorld();
            RectangleShape rect = new RectangleShape();
            Clock clock = new Clock();

            
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
                enemy.Update();
                win.DispatchEvents();

                win.Clear(Color.Black);
                //drawing

                win.Draw(map);

                win.Draw(enemy);

                for (int i = 0; i < enemies.Length; i++)
                {
                    enemies[i].Update();
                    if (p.rect.Intersects(enemies[i].Rect))
                    {
                        if (enemies[i].Life)
                        {
                            /*if (p.dy > 0) { enemies[i].DX = 0; p.dy -= 24f; enemies[i].Life = false; score+=5; }
                            else if (time + 1 < clock.ElapsedTime.AsSeconds()) { p.Damage(); time = clock.ElapsedTime.AsSeconds(); }*/
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
            win.SetView(new View(new FloatRect(0, 0, e.Width, e.Height)));
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
