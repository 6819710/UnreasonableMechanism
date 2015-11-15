using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace UnrealMechanismCS
{
    /// <summary>
    /// GameResources Class, handles loading and unloading of game resources.
    /// </summary>
    public static class GameResources
    {
        //Resource Libraries
        private static Dictionary<string, Font> _fonts = new Dictionary<string, Font>();
        private static Dictionary<string, Bitmap> _images = new Dictionary<string, Bitmap>();
        private static Dictionary<string, Music> _music = new Dictionary<string, Music>();
        private static Dictionary<string, SoundEffect> _sounds = new Dictionary<string, SoundEffect>();

        //Loading Methods
        /// <summary>
        /// LoadResources Method, loads all game resources into libraries for use.
        /// </summary>
        public static void LoadResources()
        {
            LoadFonts();
            LoadImages();
            LoadMusic();
            LoadSounds();
        }

        /// <summary>
        /// LoadFonts, loads all fonts into the _font library.
        /// </summary>
        private static void LoadFonts()
        {

        }

        /// <summary>
        /// LoadImages, loads all images into the _images library.
        /// </summary>
        private static void LoadImages()
        {
            //Assets
            NewImage("GameArea", "PlayAreaBlock.png");

            //Player
            NewImage("Player", "Player.png");
            NewImage("PlayerLeft", "PlayerLeft.png");
            NewImage("PlayerRight", "PlayerRight.png");

            
            NewImage("YingYang0", "YingYang0.png");
            NewImage("YingYang1", "YingYang1.png");
            NewImage("YingYang2", "YingYang2.png");
            NewImage("YingYang3", "YingYang3.png");
            NewImage("YingYang4", "YingYang4.png");
            NewImage("YingYang5", "YingYang5.png");
            NewImage("YingYang6", "YingYang6.png");
            NewImage("YingYang7", "YingYang7.png");

            //Items
            string[] items = new string[]
            {
                "BigPower",
                "Bomb",
                "FullPower",
                "Life",
                "Point",
                "Power",
                "Star"
            };

            foreach(string item in items)
            {
                NewImage("Item" + item, "Item" + item + ".png");
                NewImage("Above" + "Item" + item, "Item" + "Above" + item + ".png");
            }

            //Bullets
            string[] bullets = new string[]
            {
                "Beam",
                "BigStar",
                "Crystal",
                "Dart",
                "HugeSphere",
                "LargeSphere",
                "Palse",
                "Ring",
                "Seed",
                "Shere",
                "SmallRing",
                "SmallSphere",
                "Star"
            };

            string[] colours = new string[]
            {
                "Black",
                "Red",
                "Purple",
                "Blue",
                "Turquoise",
                "Green",
                "Yellow",
                "White"
            };

            foreach(string bullet in bullets)
            {
                foreach(string colour in colours)
                {
                    NewImage(bullet + colour, "Bullet" + bullet + colour + ".png");
                }
            }
        }

        /// <summary>
        /// LoadMusic, loads all music tracks into the _music library.
        /// </summary>
        private static void LoadMusic()
        {

        }

        /// <summary>
        /// LoadSounds, loads sound effects into the _sounds library
        /// </summary>
        private static void LoadSounds()
        {

        }

        /// <summary>
        /// GameFont, Gets a font loaded in the library.
        /// </summary>
        /// <param name="font">Name of the font</param>
        /// <returns>The font with its name</returns>
        public static Font GameFont(string font)
        {
            return _fonts[font];
        }

        /// <summary>
        /// GameImage, Gets an image loaded in the library.
        /// </summary>
        /// <param name="image">Name of the image</param>
        /// <returns>The image with its name</returns>
        public static Bitmap GameImage(string image)
        {
            return _images[image];
        }

        /// <summary>
        /// GameMusic, Gets a music track loaded in the library.
        /// </summary>
        /// <param name="music">Name of the music track</param>
        /// <returns>The music track with its name</returns>
        public static Music GameMusic(string music)
        {
            return _music[music];
        }

        /// <summary>
        /// GameSounds, Gets a sound effect loaded in the library.
        /// </summary>
        /// <param name="sound"></param>
        /// <returns></returns>
        public static SoundEffect GameSounds(string sound)
        {
            return _sounds[sound];
        }

        /// <summary>
        /// NewFont, adds a new font to the library.
        /// </summary>
        /// <param name="fontName">Name of the font</param>
        /// <param name="filename">Filename of the font</param>
        /// <param name="size"></param>
        private static void NewFont(string fontName, string filename, int size)
        {
            _fonts.Add(fontName, SwinGame.LoadFont(SwinGame.PathToResource(filename, ResourceKind.FontResource), size));
        }

        /// <summary>
        /// NewImage, adds a new image to the library.
        /// </summary>
        /// <param name="imageName">Name of the image</param>
        /// <param name="fileName">Filename of the image</param>
        private static void NewImage(string imageName, string filename)
        {
            _images.Add(imageName, SwinGame.LoadBitmap(SwinGame.PathToResource(filename, ResourceKind.BitmapResource)));
        }

        /// <summary>
        /// NewImageWithAlpha, adds a new image with alpha channel to the library.
        /// </summary>
        /// <param name="imageName">Name of the image</param>
        /// <param name="fileName">Filename of the image</param>
        /// <param name="alpha">Alpha of the image</param>
        private static void NewImageWithAlpha(string imageName, string filename, Color alpha)
        {
            _images.Add(imageName, SwinGame.LoadBitmap(SwinGame.PathToResource(filename, ResourceKind.BitmapResource), true, alpha));
        }

        /// <summary>
        /// NewMusic, adds a new music track to the library.
        /// </summary>
        /// <param name="musicName">Name of the music track</param>
        /// <param name="filename">Filename of the music track</param>
        private static void NewMusic(string musicName, string filename)
        {
            _music.Add(musicName, Audio.LoadMusic(SwinGame.PathToResource(filename, ResourceKind.SoundResource)));
        }

        /// <summary>
        /// NewSound, adds new sound effect to the library.
        /// </summary>
        /// <param name="soundName">Name of the sound effect</param>
        /// <param name="filename">Filename of the sound effect</param>
        private static void NewSound(string soundName, string filename)
        {
            _sounds.Add(soundName, Audio.LoadSoundEffect(SwinGame.PathToResource(filename, ResourceKind.SoundResource)));
        }

        /// <summary>
        /// free images
        /// free's all images in the dictionary
        /// </summary>
        private static void FreeImages()
        {
            foreach(Bitmap obj in _images.Values)
            {
                SwinGame.FreeBitmap(obj);
            }
        }

        /// <summary>
        /// free resources
        /// frees all game resources
        /// </summary>
        public static void FreeResources()
        {
            FreeImages();
        }
    }
}
