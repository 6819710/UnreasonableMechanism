using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnreasonableMechanismCS
{
    public static class GameScores
    {
        public static int BOMB;
        public static int BONUS;
        public static int GRAZE;
        public static int PLAYER;
        public static int POWER;
        public static int SCORE;

        public static int ITERATOR;

        public static List<int> POINTS = new List<int>(new int[]
        {
            10,
            20,
            30,
            40,
            50,
            60,
            70,
            80,
            90,
            100,
            200,
            300,
            400,
            500,
            600,
            700,
            800,
            900,
            1000,
            2000,
            3000,
            4000,
            5000,
            6000,
            7000,
            8000,
            9000,
            10000,
            11000,
            12000,
            51200
        });

        /// <summary>
        /// Initalises Scores for new game.
        /// </summary>
        public static void InitForNewGame()
        {
            BOMB = Settings.BOMBSCR;
            PLAYER = Settings.PLAYERSCR;

            BONUS = 0;
            GRAZE = 0;
            POWER = 0;
            SCORE = 0;

            ITERATOR = 0;
        }

        /// <summary>
        /// Initalises for next level.
        /// </summary>
        public static void InitForNextLevel()
        {
            BONUS = 0;
            GRAZE = 0;
        }

        public static void IncrementPower(int value)
        {
            for(int i = 0; i < value; i++)
            {
                if (POWER >= 128)
                {
                    if (ITERATOR < 30)
                    {
                        ITERATOR++;
                    }
                }
                else
                {
                    POWER++;
                    ITERATOR = 0;
                }
            }
        }
    }
}