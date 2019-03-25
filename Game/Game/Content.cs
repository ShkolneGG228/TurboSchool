﻿using SFML.Graphics;
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

        public static void Load()
        {
            textureTiles = new Texture(CONTENT_DIR + "TileSet.png");
            texturePlayer = new Texture(CONTENT_DIR + "character.png");
            Player.Load();
        }
    }
}