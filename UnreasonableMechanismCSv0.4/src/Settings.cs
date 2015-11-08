using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UM = UnreasonableMechanismEngineCS;
using UnreasonableMechanismEngineCS;
using SwinGameSDK;

namespace UnreasonableMechanismCS
{
    public static class Settings
    {
        public static bool SHOWHITBOX;

        public static KeyCode UP;
        public static KeyCode DOWN;
        public static KeyCode LEFT;
        public static KeyCode RIGHT;

        public static KeyCode FOCUS;
        public static KeyCode SHOOT;
        public static KeyCode BOMB;
        public static KeyCode PAUSE;

        public static void InitSettings()
        {
            SHOWHITBOX = true;

            UP = KeyCode.vk_UP;
            DOWN = KeyCode.vk_DOWN;
            LEFT = KeyCode.vk_LEFT;
            RIGHT = KeyCode.vk_RIGHT;

            FOCUS = KeyCode.vk_LSHIFT;
            SHOOT = KeyCode.vk_z;
            BOMB = KeyCode.vk_x;
            PAUSE = KeyCode.vk_ESCAPE;
        }
    }
}