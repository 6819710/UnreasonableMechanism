using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnrealMechanismCS
{
    public static class GameScores
    {
        //attributes
        public static int Bomb;
        public static int Bonus;
        public static int Graze;
        public static int Player;
        public static int Power;
        public static int Score;

        public static int iterator;

        public static int BaseBomb = 3;
        public static int BasePlayer = 5;
        public static List<int> Points = new List<int>();

        //methods
        /// <summary>
        /// Initalises Base Scores for new game.
        /// </summary>
        public static void Initalise()
        {
            Bomb = BaseBomb;
            Player = BasePlayer;

            Bonus = 0;
            Graze = 0;
            Power = 0;
            Score = 0;

            InitalisePoints();
            iterator = 0;
        }

        /// <summary>
        /// Increments power to a maximum of 128;
        /// </summary>
        public static void IncrementPower()
        {
            Power++;
            if (Power > 128)
            {
                Power = 128;
            }
        }

        /// <summary>
        /// Initalises Point Values
        /// </summary>
        public static void InitalisePoints()
        {
            int[] points = new int[]
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
            };

            foreach (int value in points)
            {
                Points.Add(value);
            }
        }
    }
}