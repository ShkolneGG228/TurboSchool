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
        public const int WORLD_WIDTH = 52;
        RectangleShape rect = new RectangleShape();
        RectangleShape rectdecor = new RectangleShape(new Vector2f(74,53));
        RectangleShape rectMarioSet = new RectangleShape();
        public static string[] tilemap;
        public static string[] decorMap;

        public void Draw(RenderTarget target, RenderStates states)
        {
            
            for (int x = 0; x < WOLRD_HEIGHT; x++)
            {
                for (int y = 0; y < WORLD_WIDTH; y++)
                {

                    if (tilemap[x][y] == ' ' || tilemap[x][y] == '0') { rect.TextureRect = new IntRect(128, 160, 32, 32); }
                    /*if (tilemap[x][y] == 'B') rect.TextureRect = new IntRect(32, 32, 32, 32);////grass
                    if (tilemap[x][y] == 'L') { rect.TextureRect = new IntRect(128, 192, 32, 32); }//lava
                    if (tilemap[x][y] == 'Q') rect.TextureRect = new IntRect(32, 64, 32, 32);//underground
                    if (tilemap[x][y] == 'I') { rect.TextureRect = new IntRect(96, 160, 32, 32); }*/
                    rect.Size = new Vector2f(32, 32);
                    rect.Position = new Vector2f(32 * y - Player.offsetX, 32 * x);
                    target.Draw(rect);
                }
            }

            for (int x = 0; x < WOLRD_HEIGHT; x++)
            {
                for (int y = 0; y < WORLD_WIDTH; y++)
                {
                    if (decorMap[x][y] == ' ') { continue; }
                    if (decorMap[x][y] == 'G') { rect.TextureRect = new IntRect(64, 0, 32, 32); }
                    if (decorMap[x][y] == 'H') { rect.TextureRect = new IntRect(32, 0, 32, 32); }
                    if (decorMap[x][y] == 'T') { rect.TextureRect = new IntRect(0, 0, 32, 32); }
                    rect.Size = new Vector2f(32, 32);
                    rect.Position = new Vector2f(32 * y - Player.offsetX, 32 * x);
                    //rectdecor.Position = new Vector2f(32 * y - Player.offsetX, 32 * x);
                    target.Draw(rect);

                    if (decorMap[x][y] == 'U')
                    {
                        rectdecor.TextureRect = new IntRect(0, 0, 119, 86);
                        rectdecor.Size = new Vector2f(119, 86);
                        rectdecor.Position = new Vector2f(32 * y - Player.offsetX, 32 * x - 55);
                        target.Draw(rectdecor);
                    }
                    if (decorMap[x][y] == 'F')
                    {
                        rectdecor.TextureRect = new IntRect(0, 94, 104, 116);
                        rectdecor.Size = new Vector2f(104, 116);
                        rectdecor.Position = new Vector2f(32 * y - Player.offsetX, 32 * x - 80);
                        target.Draw(rectdecor);
                    }
                    if (decorMap[x][y] == 'M')
                    {
                        rectdecor.TextureRect = new IntRect(240, 367, 86, 207);
                        rectdecor.Size = new Vector2f(86, 207);
                        rectdecor.Position = new Vector2f(32 * y - Player.offsetX, 32 * x - 150);
                        target.Draw(rectdecor);
                    }
                    if (decorMap[x][y] == 'O')
                    {
                        rectdecor.TextureRect = new IntRect(0, 609, 65, 33);
                        rectdecor.Size = new Vector2f(65, 33);
                        rectdecor.Position = new Vector2f(32 * y - Player.offsetX, 32 * x);
                        target.Draw(rectdecor);
                    }
                    
                }
            }

            for (int x = 0; x < WOLRD_HEIGHT; x++)
            {
                for (int y = 0; y < WORLD_WIDTH; y++)
                {

                    if (tilemap[x][y] == ' ' || tilemap[x][y] == '0') { continue; }
                    if (tilemap[x][y] == 'B') rect.TextureRect = new IntRect(32, 32, 32, 32);////grass
                    if (tilemap[x][y] == 'L') { rect.TextureRect = new IntRect(128, 192, 32, 32); }//lava
                    if (tilemap[x][y] == 'Q') rect.TextureRect = new IntRect(32, 64, 32, 32);//underground
                    if (tilemap[x][y] == 'I') { rect.TextureRect = new IntRect(96, 160, 32, 32); }
                    rect.Size = new Vector2f(32, 32);
                    rect.Position = new Vector2f(32 * y - Player.offsetX, 32 * x);
                    target.Draw(rect);
                }
            }

        }

        public void GenerateWorld()
        {
            rect.Texture = Content.textureTiles;
            rectdecor.Texture = Content.textureDecor;
            rectMarioSet.Texture = Content.textureMario;
             tilemap = new string[WOLRD_HEIGHT]
            {
                "0000000000000000000000000000000000000000000000000000",
                "0                                                  0",
                "0                                                  0",
                "0                                                  0",
                "0                                                  0",
                "0                                                  0",
                "0                                                  0",
                "0                                                  0",
                "0                                                  0",
                "0                                                  0",
                "0                                                  0",
                "0                                                  0",
                "0               I                                  0",
                "0               I                                  0",
                "0               I                                  0",
                "0               I                                  0",
                "0 I             I        I     I                   0",
                "BBBBBBBBBBBBBBBBBBBBBBBBBBLLLLLBBBBBBBBBBBBBBBBBBBBB",
                "QQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQ",
            };
            decorMap = new string[WOLRD_HEIGHT]
            {
                "                                                    ",
                "                                                    ",
                "           O                                        ",
                "                                      O             ",
                "                                                    ",
                "                       O                            ",
                "                                                    ",
                "                                                    ",
                "                                                    ",
                "                                                    ",
                "                                                    ",
                "                                                    ",
                "                                                    ",
                "                                                    ",
                "                                                    ",
                "                                                    ",
                "TG TT H TTTT UT H   M              H   TTTTGTT FH   T",
                "                                                    ",
                "                                                    ",
            };
            
            
        }
    }
}
