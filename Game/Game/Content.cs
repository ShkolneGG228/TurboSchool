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
        public static Texture textureMario;
        public static Texture textureTrees;
        public static Texture MonsterEnemy;
        public static Font font;

        public static void Load()
        {
            textureTiles = new Texture(CONTENT_DIR + "TileSet.png");
            texturePlayer = new Texture(CONTENT_DIR + "character.png");
            textureDecor = new Texture(CONTENT_DIR + "decor.png");
            textureMario = new Texture(CONTENT_DIR + "Mario_tileset.png");
            textureTrees = new Texture(CONTENT_DIR + "Tree.png");
            MonsterEnemy = new Texture(CONTENT_DIR + "EnemyMonstr.png");
            font = new Font(CONTENT_DIR + "Dpix_8pt.ttf");
        }
    }
}
