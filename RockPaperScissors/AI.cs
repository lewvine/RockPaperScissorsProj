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
        public AI()
        {

        }

        //Member methods
        public override string ChooseGesture()
        {
            Random rand = new Random();
            int x = rand.Next(1, 6);

            switch (x)
            {
                case 1:
                    currentGesture = "rock";
                    break;
                case 2:
                    currentGesture = "paper";
                    break;
                case 3:
                    currentGesture = "scissors";
                    break;
                case 4:
                    currentGesture = "spock";
                    break;
                case 5:
                    currentGesture = "lizard";
                    break;
            }
            return currentGesture;
        }
    }
}
