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
        static void Main(string[] args)
        {
            const int HMap = 25;
            const int WMap = 51;
            string[] tilemap = new string[HMap]
            {
                "BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB",
                "B                                                 B",
                "B                                                 B",
                "B                                        B        B",
                "B                                        B        B",
                "B                                        B        B",
                "B                                        B        B",
                "B                                        B        B",
                "B                                        B        B",
                "B                                   BBBB B        B",
                "B                                        B        B",
                "B                                        B        B",
                "B                                        B        B",
                "B                                        B        B",
                "BBBB                                     B        B",
                "B                                        B        B",
                "B                                        B        B",
                "B           0000000000000000000                   B",
                "B                                                 B",
                "B                                                 B",
                "B                                                 B",
                "B                                  BB             B",
                "B                                  BB             B",
                "B                                  BB             B",
                "BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB",
            };

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

                /*for(int i = 0; i < HMap; i++)
                {
                    for(int j = 0; j < WMap; j++)
                    {
                        if (tilemap[i][j] == ' ') continue;
                        if (tilemap[i][j] == 'B') rect.FillColor = Color.White;
                        if (tilemap[i][j] == '0') rect.FillColor = Color.Green;
                        rect.Size = new Vector2f(32, 32);
                        rect.Position = new Vector2f(32 * j, 32 * i);
                        
                        win.Draw(rect);
                    }
                }*/
                win.Draw(map);

                win.Draw(p);

                win.Display();
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
    }
}
