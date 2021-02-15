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
        public Gesture currentGesture;
        public List<Gesture> gestures;

        //Member methods
        public Player(string name = "Ding Dong", int currentscore = 0)
        {
            this.name = name;
            this.currentScore = currentscore;
            this.currentGesture = null;
            this.gestures = new List<Gesture>();

            List<string> rockWins = new List<string>() { "lizard", "scissors" };
            Gesture rock = new Gesture("rock", rockWins);
            gestures.Add(rock);

            List<string> paperWins = new List<string>() { "rock", "spock" };
            Gesture paper = new Gesture("paper", paperWins);
            gestures.Add(paper);

            List<string> scissorsWins = new List<string>() { "paper", "lizard" };
            Gesture scissors = new Gesture("scissors", scissorsWins);
            gestures.Add(scissors);

            List<string> spockWins = new List<string>() { "scissors", "rock" };
            Gesture spock = new Gesture("spock", spockWins);
            gestures.Add(spock);

            List<string> lizardWins = new List<string>() { "spock", "paper" };
            Gesture lizard = new Gesture("lizard", lizardWins);
            gestures.Add(lizard);
        }

        public void SetName()
        {
            Console.WriteLine("Input your name and press ENTER to continue.");
            this.name = Console.ReadLine();
            if (this.name.Length < 3)
            {
                Console.WriteLine("You're name is too short.  Please try again.");
                SetName();
            }
        }

        public abstract Gesture ChooseGesture();
      

    }
}
