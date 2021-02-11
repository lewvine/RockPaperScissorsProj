using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class Player
    {

        //Member variables
        public string name;
        public string type;
        public int currentScore;
        public string currentGesture;

        //Member methods
        public Player(string name = "Ding Dong", int currentscore = 0, string currentGesture = "rock")
        {
            this.name = name;
            this.currentScore = currentscore;
            this.currentGesture = currentGesture;
        }

        public string SetName()
        {
            Console.WriteLine("Input your name and press ENTER to continue.");
            this.name = Console.ReadLine();
            return this.name;
        }

        public virtual string ChooseGesture()
        {
            
                Console.WriteLine($"{name} Please choose your gesture.  \n\n'1'  -  Rock\n'2'  -  Paper\n" +
                    "'3'  -  Scissors\n'4'  -  Spock\n'5'  -  Lizard ");
                int x = Convert.ToInt32(Console.ReadLine());
            
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
