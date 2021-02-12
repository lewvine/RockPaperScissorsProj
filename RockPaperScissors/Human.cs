using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{

    public class Human : Player
    {
        public override string ChooseGesture(List<string> gestures)
        {
            Console.WriteLine($"{name} Please choose your gesture.  \n\n'1'  -  Rock\n'2'  -  Paper\n" +
                "'3'  -  Scissors\n'4'  -  Spock\n'5'  -  Lizard ");
            int x = Convert.ToInt32(Console.ReadLine()) + 1;

            for(int i = 0; i <= gestures.Count; i++)
            {
                if(x == i)
                {
                    currentGesture = gestures[i];
                }
            };
            return currentGesture;
        }
    }
}
