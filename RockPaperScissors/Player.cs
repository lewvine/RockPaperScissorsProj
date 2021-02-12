using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    abstract public class Player
    {

        //Member variables
        public string name;
        public int currentScore;
        public string currentGesture;

        //Member methods
        public Player(string name = "Ding Dong", int currentscore = 0, string currentGesture = "rock")
        {
            this.name = name;
            this.currentScore = currentscore;
            this.currentGesture = currentGesture;
        }

        public void SetName()
        {
            Console.WriteLine("Input your name and press ENTER to continue.");
            this.name = Console.ReadLine();
        }

        public abstract string ChooseGesture();
      

    }
}
