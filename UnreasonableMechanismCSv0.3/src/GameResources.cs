using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace UnrealMechanismCS
{
    public static class GameResources
    {
        private static Dictionary<string, Font> _fonts = new Dictionary<string, Font>();
        private static Dictionary<string, Bitmap> _images = new Dictionary<string, Bitmap>();
        private static Dictionary<string, Music> _music = new Dictionary<string, Music>();
        private static Dictionary<string, SoundEffect> _sounds = new Dictionary<string, SoundEffect>();

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

        public static Font GameFont(string font)
        {
            return _fonts[font];
        }

        public static Bitmap GameImage(string image)
        {
            return _images[image];
        }

        public static Music GameMusic(string music)
        {
            return _music[music];
        }

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

        private static void FreeSounds()
        {
            foreach (SoundEffect obj in _sounds.Values)
            {
                SwinGame.FreeSoundEffect(obj);
            }
        }

        public static void FreeResources()
        {
            FreeFonts();
            FreeImages();
            FreeMusic();
            FreeSounds();
        }
    }
}