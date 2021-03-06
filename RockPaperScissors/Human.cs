﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{

    public class Human : Player
    {
        public override Gesture ChooseGesture()
        {
            Console.WriteLine($"{name} Please choose your gesture.");

            for (var i = 0; i < gestures.Count; i++)
            {
                Console.WriteLine($"{i+1}  -  {gestures[i].name}");
            }
            int x = Convert.ToInt32(Console.ReadLine());

            for(int i = 1; i <= gestures.Count; i++)
            {
                if(x == i)
                {
                    currentGesture = gestures[i-1];
                }
            };
            return currentGesture;
        }
    }
}
