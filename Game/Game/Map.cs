using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Map : Transformable, Drawable
    {
        public const int WOLRD_HEIGHT = 19;
        public const int WORLD_WIDTH = 51;
        RectangleShape rect = new RectangleShape();
        public static string[] tilemap;

        public void Draw(RenderTarget target, RenderStates states)
        {
            for(int x = 0; x < WOLRD_HEIGHT; x++)
            {
                for(int y = 0; y < WORLD_WIDTH;y++)
                {

                    if (tilemap[x][y] == ' ') continue;
                    if (tilemap[x][y] == 'B') rect.FillColor = Color.White;
                    if (tilemap[x][y] == '0') rect.FillColor = Color.Green;
                    rect.Size = new Vector2f(32, 32);
                    rect.Position = new Vector2f(32 * y, 32 * x);

                    target.Draw(rect);
                }
            }
        }

        public void GenerateWorld()
        {
             tilemap = new string[WOLRD_HEIGHT]
            {
                "BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB",
                "B                                                 B",
                "B                                                 B",
                "B                                        B        B",
                "B                                        B        B",
                "B                000000000          BBBB B        B",
                "B                                        B        B",
                "B                                        B        B",
                "B     BBBBBBB                            B        B",
                "B                  BBB                   B        B",
                "BBBB                                     B        B",
                "B                                      BBB        B",
                "B                 BBB                    B        B",
                "B           0000000000000BBBBBB                   B",
                "B                                                 B",
                "B                                  BB             B",
                "B              BB                  BB             B",
                "B                                  BB             B",
                "BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB",
            };
        }
    }
}
