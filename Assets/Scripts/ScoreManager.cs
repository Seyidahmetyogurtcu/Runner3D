using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner3D.Game
{
    public static class ScoreManager
    {
        public static int score = 0;
        public static string Score
        {
            get
            { 
                return "Score: " + score; 
            }
            set {}
        }
        public static void ScoreUp()
        {
            score++;
        }
    }
}