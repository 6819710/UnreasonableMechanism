using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SwinGameSDK;

namespace UnrealMechanismCS
{
    /// <summary>
    /// GameKeys, defines the keys used for the game
    /// </summary>
    public static class GameKeys
    {
        public const KeyCode UP = KeyCode.vk_UP;
        public const KeyCode DOWN = KeyCode.vk_DOWN;
        public const KeyCode LEFT = KeyCode.vk_LEFT;
        public const KeyCode RIGHT = KeyCode.vk_RIGHT;

        public const KeyCode FOCUS = KeyCode.vk_LSHIFT;
        public const KeyCode SHOOT = KeyCode.vk_z;
        public const KeyCode BOMB = KeyCode.vk_x;
        public const KeyCode PAUSE = KeyCode.vk_ESCAPE;
    }
}
