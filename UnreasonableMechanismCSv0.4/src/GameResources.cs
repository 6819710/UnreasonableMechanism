using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace UnreasonableMechanismCS
{
    public static class GameResources
    {
        private static Dictionary<string, Font> _fonts = new Dictionary<string, Font>();
        private static Dictionary<string, Bitmap> _images = new Dictionary<string, Bitmap>();
        private static Dictionary<string, Music> _music = new Dictionary<string, Music>();
        private static Dictionary<string, SoundEffect> _sounds = new Dictionary<string, SoundEffect>();

        /// <summary>
        /// Loads the game resources.
        /// </summary>
        public static void LoadResources()
        {
            LoadFonts();
            LoadImages();
            LoadMusic();
            LoadSounds();
        }

        private static void LoadFonts()
        {
        }

        private static void LoadImages()
        {
            NewImage("GameArea", "PlayAreaBlock.png");
            NewImage("GreyoutWindow", "GreyoutWindow.png");

            NewImage("PlayerWideA", "Player.png");
            NewImage("PlayerLeftWideA", "PlayerLeft.png");
            NewImage("PlayerRightWideA", "PlayerRight.png");

            NewImage("PlayerWideB", "Player.png");
            NewImage("PlayerLeftWideB", "PlayerLeft.png");
            NewImage("PlayerRightWideB", "PlayerRight.png");

            NewImage("PlayerNarrowA", "Player.png");
            NewImage("PlayerLeftNarrowA", "PlayerLeft.png");
            NewImage("PlayerRightNarrowA", "PlayerRight.png");

            NewImage("PlayerNarrowB", "Player.png");
            NewImage("PlayerLeftNarrowB", "PlayerLeft.png");
            NewImage("PlayerRightNarrowB", "PlayerRight.png");


            NewImage("YingYang0", "YingYang0.png");
            NewImage("YingYang1", "YingYang1.png");
            NewImage("YingYang2", "YingYang2.png");
            NewImage("YingYang3", "YingYang3.png");
            NewImage("YingYang4", "YingYang4.png");
            NewImage("YingYang5", "YingYang5.png");
            NewImage("YingYang6", "YingYang6.png");
            NewImage("YingYang7", "YingYang7.png");

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

            foreach (string item in items)
            {
                NewImage("Item" + item, "Item" + item + ".png");
                NewImage("Above" + "Item" + item, "Item" + "Above" + item + ".png");
            }

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

            foreach (string bullet in bullets)
            {
                foreach (string colour in colours)
                {
                    NewImage(bullet + colour, "Bullet" + bullet + colour + ".png");
                }
            }
        }

        private static void LoadMusic()
        {
        }

        private static void LoadSounds()
        {
        }

        /// <summary>
        /// Returns the font.
        /// </summary>
        /// <param name="font">Font to search for.</param>
        /// <returns>Font.</returns>
        public static Font GameFont(string font)
        {
            return _fonts[font];
        }

        /// <summary>
        /// Returns the Bitmap.
        /// </summary>
        /// <param name="image">Bitmap to search for.</param>
        /// <returns>Britmap.</returns>
        public static Bitmap GameImage(string image)
        {
            return _images[image];
        }

        /// <summary>
        /// Returns the music.
        /// </summary>
        /// <param name="music">Music to search for.</param>
        /// <returns>Music.</returns>
        public static Music GameMusic(string music)
        {
            return _music[music];
        }

        /// <summary>
        /// Returns the sound effect.
        /// </summary>
        /// <param name="sound">Sound effect to search for.</param>
        /// <returns>Sound effect.</returns>
        public static SoundEffect GameSounds(string sound)
        {
            return _sounds[sound];
        }

        private static void NewFont(string fontName, string filename, int size)
        {
            _fonts.Add(fontName, SwinGame.LoadFont(SwinGame.PathToResource(filename, ResourceKind.FontResource), size));
        }

        private static void NewImage(string imageName, string filename)
        {
            _images.Add(imageName, SwinGame.LoadBitmap(SwinGame.PathToResource(filename, ResourceKind.BitmapResource)));
        }

        private static void NewImageWithAlpha(string imageName, string filename, Color alpha)
        {
            _images.Add(imageName, SwinGame.LoadBitmap(SwinGame.PathToResource(filename, ResourceKind.BitmapResource), true, alpha));
        }

        private static void NewMusic(string musicName, string filename)
        {
            _music.Add(musicName, Audio.LoadMusic(SwinGame.PathToResource(filename, ResourceKind.SoundResource)));
        }

        private static void NewSound(string soundName, string filename)
        {
            _sounds.Add(soundName, Audio.LoadSoundEffect(SwinGame.PathToResource(filename, ResourceKind.SoundResource)));
        }

        private static void FreeFonts()
        {
            foreach (Font obj in _fonts.Values)
            {
                SwinGame.FreeFont(obj);
            }
        }

        private static void FreeImages()
        {
            foreach (Bitmap obj in _images.Values)
            {
                SwinGame.FreeBitmap(obj);
            }
        }

        private static void FreeMusic()
        {
            foreach (Music obj in _music.Values)
            {
                SwinGame.FreeMusic(obj);
            }
        }

        /// <summary>
        /// Frees the loaded resources.
        /// </summary>
        public static void FreeResources()
        {
            FreeFonts();
            FreeImages();
            FreeMusic();
            FreeSounds();
        }

        private static void FreeSounds()
        {
            foreach (SoundEffect obj in _sounds.Values)
            {
                SwinGame.FreeSoundEffect(obj);
            }
        }
    }
}