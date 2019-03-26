using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Content
    {
        public const string CONTENT_DIR = "..\\Content\\";
        public static Texture textureTiles;
        public static Texture texturePlayer;
        public static Texture textureDecor;
        public static Texture texttureSpider;

        public static void Load()
        {
            textureTiles = new Texture(CONTENT_DIR + "TileSet.png");
            texturePlayer = new Texture(CONTENT_DIR + "character.png");
            textureDecor = new Texture(CONTENT_DIR + "decor.png");
            texttureSpider = new Texture(CONTENT_DIR + "Mario_tileset.png");
            Player.Load();
            Enemy.Load();
        }
    }
}
