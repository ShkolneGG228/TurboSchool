using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;

namespace Game
{
    class Program
    {
        static RenderWindow win;
        static Clock clock = new Clock();
        static void Main(string[] args)
        {
            win = new RenderWindow(new VideoMode(800, 600), "My Game");
            win.SetVerticalSyncEnabled(true);

            win.Closed += Win_Closed;
            win.Resized += Win_Resized;

            Content.Load();

            Player p = new Player();
            Map map = new Map();
            map.GenerateWorld();
            RectangleShape rect = new RectangleShape();

            
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

                win.DispatchEvents();

                win.Clear(Color.Black);

                win.Draw(map);

                win.Draw(p);

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
        public static void FPS()
        {
            win.Display();
            Time time = clock.ElapsedTime;
            win.SetTitle("FPS : " + (1.0f / time.AsSeconds()).ToString());
            clock.Restart();
        }
    }
}
