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
        public const int WOLRD_HEIGHT = 24;
        public const int WORLD_WIDTH = 202;
        RectangleShape rect = new RectangleShape();
        RectangleShape rectdecor = new RectangleShape(new Vector2f(74,53));
        RectangleShape rectTree = new RectangleShape();
        RectangleShape rectMarioSet = new RectangleShape();
        public static string[] tilemap;
        public static string[] decorMap;
        Random rnd = new Random();

        List<double> SizeOfTrees = new List<double>()
        {
            1.2,2.3,3.1,2.3,4.0,1.4,1.9,2.5,3.7,1.1,2.2,3.1,4.1,2.8,4.1,2.3,1.24,2.5,1.3,2.1,3.8,4,1,2.2
        };

        public void Draw(RenderTarget target, RenderStates states)
        {
            
            for (int x = 0; x < WOLRD_HEIGHT; x++)
            {
                for (int y = 0; y < WORLD_WIDTH; y++)
                {

                    if (tilemap[x][y] == ' ' || tilemap[x][y] == '0') { rect.TextureRect = new IntRect(128, 160, 32, 32); }
                    rect.Size = new Vector2f(32, 32);
                    rect.Position = new Vector2f(32 * y - Player.offsetX, 32 * x);
                    target.Draw(rect);
                }
            }
            int k = 0;
            for (int x = 0; x < WOLRD_HEIGHT; x++)
            {
                for (int y = 0; y < WORLD_WIDTH; y++)
                {
                    if (decorMap[x][y] == ' ') { continue; }
                    if (decorMap[x][y] == 'G') { rect.TextureRect = new IntRect(64, 0, 32, 32); }
                    if (decorMap[x][y] == 'H') { rect.TextureRect = new IntRect(32, 0, 32, 32); }
                    if (decorMap[x][y] == 'T') { rect.TextureRect = new IntRect(0, 0, 32, 32); }
                    rect.Size = new Vector2f(32, 32);
                    rect.Position = new Vector2f(32 * y - Player.offsetX, 32 * x - Player.offsetY);
                    target.Draw(rect);

                    if (decorMap[x][y] == 'U')
                    {
                        IntitRect(rectTree,0,100,x,y,63,141,(float)SizeOfTrees[k], target);
                        k++;
                        //дерево
                    }
                    if (decorMap[x][y] == 'F')
                    {
                        IntitRect(rectTree,200,15,x,y,45,95,(float)SizeOfTrees[k], target);
                        k++;
                        //йолка
                    }
                    if (decorMap[x][y] == 'M')//ПАЛЬМА
                    {
                        IntitRect(rectTree, 460, 98, x, y, 176, 135, (float)SizeOfTrees[k], target);
                        k++;
                    }
                    if (decorMap[x][y] == 'O')
                    {
                        rectdecor.TextureRect = new IntRect(0, 609, 65, 33);
                        rectdecor.Size = new Vector2f(65, 33);
                        rectdecor.Position = new Vector2f(32 * y - Player.offsetX, 32 * x - Player.offsetY);
                        target.Draw(rectdecor);
                    }
                    if (decorMap[x][y] == 'P')
                    {
                        rectdecor.TextureRect = new IntRect(0, 325, 91, 117);
                        rectdecor.Size = new Vector2f(91, 117);
                        rectdecor.Position = new Vector2f(32 * y - Player.offsetX, 32 * x - 117/2-Player.offsetY);
                        target.Draw(rectdecor);
                    }
                    if (decorMap[x][y] == '1')
                    {
                        rectdecor.TextureRect = new IntRect(84, 609, 44, 34);
                        rectdecor.Size = new Vector2f(44, 34);
                        rectdecor.Position = new Vector2f(32 * y - Player.offsetX, 32 * x - Player.offsetY);
                        target.Draw(rectdecor);
                    }
                    if (decorMap[x][y] == '2')
                    {
                        rectdecor.TextureRect = new IntRect(0, 654, 87, 34);
                        rectdecor.Size = new Vector2f(87, 34);
                        rectdecor.Position = new Vector2f(32 * y - Player.offsetX, 32 * x - Player.offsetY);
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
                    if (tilemap[x][y] == 'S') { rect.TextureRect = new IntRect(160 + 5, 192 + 5, 20, 20);/*rect.Scale = new Vector2f(-1.3f, -1.3f);*/ }
                    if (tilemap[x][y] == 'H') { rect.TextureRect = new IntRect(160, 160, 16, 16); }
                    rect.Size = new Vector2f(32, 32);
                    rect.Position = new Vector2f(32 * y - Player.offsetX, 32 * x - Player.offsetY);
                    target.Draw(rect);
                    rect.Scale = new Vector2f(1, 1);
                }
            }

        }

        public void IntitRect(RectangleShape rect, int left, int top, int x,int y, int width, int height, float scale, RenderTarget target)
        {
            rect.TextureRect = new IntRect(left, top, width, height);
            rect.Size = new Vector2f(width, height);
            rect.Position = new Vector2f(32 * y -Player.offsetX, 32 * x - (int)(height*0.9*scale-x) - Player.offsetY);
            rect.Scale = new Vector2f(scale, scale);
            target.Draw(rect);
        }

        public void GenerateWorld()
        {
            rect.Texture = Content.textureTiles;
            rectdecor.Texture = Content.textureDecor;
            rectMarioSet.Texture = Content.textureMario;
            rectTree.Texture = Content.textureTrees;
             tilemap = new string[WOLRD_HEIGHT]
            {
                "00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000",
                "0                                                                                                                                                                                                         0",
                "0                                                                                                                                                                                                         0",
                "0                                                                                                                                                                                                         0",
                "0                                                                                                                                                                                                         0",
                "0                                                                                                                                                                                                         0",
                "0                                                                                                                                                                                                         0",
                "0                                                                                                                                                                                                         0",
                "0                                                     IIII     H                                           IIIIIIII    I     I                                                                            0",
                "0                                 H                         IIIIIII                                       I           IIIIIIIII                                                                           0",
                "0                                 I     SSS                       I                                       I            I     I                                                                            0",
                "0                                       IIII       I              I                                       I            I  S  I                                                                            0",
                "0                                                                 IIIIIIIII                               I            I     I                                                                            0",
                "0                        S                                         IS               H                     I           IIIIIIIII                                                                           0",
                "0                                                                  IS               I                      IIIIIIII    I     I                                                                            0",
                "0                                                                  I              III                                                                                                                     0",
                "0                        S                      II       S         I         I   IISS                                                                                                                     0",
                "0                        I                            IIII         ISSS      ILLIIISS                                                                                                                     0",
                "0                 I      I                                         IIIIIIIIIIIIIIIISS                                                                                                                     0",
                "0                 I      I                                                        ISS                                                                                                                     0",
                "0                 I      I                                                        III                               SS                                                                                    0",
                "0                 I      I     I                   SI                                  I            I            SSS  SSS                                                                                 0",
                "BBBBBBBBBBBBBBBBBBBBBBBBBBLLLLLBBBBBBBBBBBBBBBBBBBBBBLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB",
                "QQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQ",
            };
            decorMap = new string[WOLRD_HEIGHT]
            {
                "                                               O                                       O                                                            O            2         1             O                ",
                "         2                                                               1                            1               O                  2                                                         2      ",
                "                                      O                O                                                                                                                            O                     ",
                "                 O                                                                                                                                                                         O              ",
                "                                              2                    O                        O                                    1               1                                                        ",
                "                                                                                                          2            1                                                           2                      ",
                "                         1                                                                                                                                                                        1       ",
                "                                                     O                     1          2                                                 O                    2           2                                ",
                "                                       2                                                        O                                                    O                                    1               ",
                "             2                                                                                                  O                                                                                2        ",
                "                       O           1                                                                                                                                                                      ",
                "    O                                                                                                                             O                             O                 O                       ",
                "                                            O            2                  O                 1                 1                                2                                                        ",
                "            1                                                                                                                                                                                 2           ",
                "                                  O                                                                                                                                          O                            ",
                "                                                                                                                                                                                                          ",
                "                                                                                                                                                                                                          ",
                "                                                                                              O                                                                                                           ",
                "                                                                                                                                                                                                          ",
                "                                                                                                                                                                                                          ",
                "                                                                                                                                                                                                          ",
                "UG T H TTTT UT   M M              H   PTTMGTT FH                                       TTTTTTTTTTTGTTTGTTTTGTTTTGTTTGTTTTTTUHFHHUFTUTHTUHTFHGTMTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT",
                "                                                                                                                                                                                                          ",
                "                                                                                                                                                                                                          ",
            };
            
            
        }
    }
}
