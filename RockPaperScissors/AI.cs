using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    public class AI : Player
    {

        //Member variables


        //Member constructor


        //Member methods
        public override string ChooseGesture(List<string> gestures)
        {
            Random rand = new Random();
            int x = rand.Next(0, 5);

            for (int i = 0; i < gestures.Count; i++)
            {
                if (x == i)
                {
                    currentGesture = gestures[i];
                }
            };
            return currentGesture;
        }
    }
}
