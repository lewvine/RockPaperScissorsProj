using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class Game
    {
        //Member variables
        public int rounds;
        public List<string> gestures;
        public Player playerOne;
        public Player playerTwo;
        public bool keepPlaying;

        //Constructor
        public Game()
        {
            rounds = 0;
            keepPlaying = true;
            playerOne = new Human();
            gestures = new List<string>();
            
            gestures.Add("rock");
            gestures.Add("paper");
            gestures.Add("scissors");
            gestures.Add("spock");
            gestures.Add("lizard");



        }


        //Member methods
        public void RunGame()
        {
            //keepPlaying is defaulted to true in new Game and then assessed in the ThanksForPlaying().
            while (keepPlaying == true)
            {
                rounds = 0;
                WelcomeMessage();

                //Set options
                string answer = SelectNumberOfPlayers();
                CreatePlayer(answer);
                rounds = NumberOfRounds();

                //Play game
                Player winner = Round();
                ShowWinner(winner);
                ThanksForPlaying();
            }
        }
        public void WelcomeMessage()
        {
            Console.WriteLine("\n\nWelcome to RPSSL!\n\n" +
                "The rules are pretty simple.  It's just like 'Rock, Paper, Scissors,'\n" +
                "but with two additional gesture options: Spock, and lizard...... more rules.\n" +
                "Hit ENTER to continue.");
            Console.ReadLine();
            Console.Clear();
        }

        public string SelectNumberOfPlayers()
        {
            Console.WriteLine("Are there ONE or TWO players?  Please type 'one' or 'two'");
            string answer = Console.ReadLine().ToUpper();
            Console.Clear();
            if (answer != "TWO" && answer != "ONE")
            {
                Console.WriteLine("Invalid input.  Please try again.");
                SelectNumberOfPlayers();
            }
            return answer;
        }

        public void CreatePlayer(string x)
        {
            playerOne = new Human();
            playerOne.SetName();
            Console.Clear();
            if (x == "TWO")
            {
                playerTwo = new Human();
                playerTwo.SetName();
                Console.Clear();
            }
            else if (x == "ONE")
            {
                playerTwo = new AI();
            }
        }

        public int NumberOfRounds()
        {
            Console.WriteLine("How many number of rounds would you like to play?  " +
                "Type '3', '5' or '7'");

            int rounds = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            switch (rounds)
            {
                case 3:
                    break;
                case 5:
                    break;
                case 7:
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("That wasn't a valid entry.  Please try again.");
                    NumberOfRounds();
                    break;
            }
            return rounds;
        }
        public Player Round()
        {
            while (playerOne.currentScore < rounds && playerTwo.currentScore < rounds)
            {
                string gestureOne = playerOne.ChooseGesture(gestures);
                Console.Clear();
                string gestureTwo = playerTwo.ChooseGesture(gestures);
                Console.Clear();
                Console.WriteLine($"{playerOne.name} picked {playerOne.currentGesture}.\n" +
                                    $"{playerTwo.name} picked {playerTwo.currentGesture}.");

                int winner = WhoWins(gestureOne, gestureTwo);

                switch (winner)
                {
                    case 1:
                        playerOne.currentScore++;
                        Console.WriteLine($"{playerOne.name} wins!");
                        break;
                    case 2:
                        playerTwo.currentScore++;
                        Console.WriteLine($"{playerTwo.name} wins!");
                        break;
                    case 3:
                        Console.WriteLine("Tie game.  Hit ENTER to continue.");

                        break;
                    case 0:
                        Console.WriteLine("This is an error.  Hit ENTER to continue.");
                        break;
                }
                Console.WriteLine($"\n\n{playerOne.name} has {playerOne.currentScore}.\n" +
                                    $"{playerTwo.name} has {playerTwo.currentScore}.\n" +
                                    $"Press ENTER to continue");

                Console.ReadLine();
                Console.Clear();
            }
            if (playerOne.currentScore == rounds)
            {
                return playerOne;
            }
            return playerTwo;
        }

        public int WhoWins(string gestureOne, string gestureTwo)
        {
            if (gestureOne == "rock")
            {
                if (gestureTwo == "paper" || gestureTwo == "spock")
                {
                    return 2;
                }
                else if (gestureTwo == "lizard" || gestureTwo == "scissors")
                {
                    return 1;
                }
                else
                {
                    return 3;
                }
            }

            //playerOne is Scissors
            if (gestureOne == "scissors")
            {
                if (gestureTwo == "rock" || gestureTwo == "spock")
                {
                    return 2;
                }
                else if (gestureTwo == "paper" || gestureTwo == "lizard")
                {
                    return 1;
                }
                else
                {
                    return 3;
                }
            }

            //playerOne is Spock
            if (gestureOne == "spock")
            {
                if (gestureTwo == "lizard" || gestureTwo == "paper")
                {
                    return 2;
                }
                else if (gestureTwo == "scissors" || gestureTwo == "rock")
                {
                    return 1;
                }
                else
                {
                    return 3;
                }
            }

            //playerOne is Paper
            if (gestureOne == "paper")
            {
                if (gestureTwo == "scissors" || gestureTwo == "lizard")
                {
                    return 2;
                }
                else if (gestureTwo == "rock" || gestureTwo == "spock")
                {
                    return 1;
                }
                else
                {
                    return 3;
                }
            }

            //playerOne is lizard
            if (gestureOne == "lizard")
            {
                if (gestureTwo == "rock" || gestureTwo == "scissors")
                {
                    return 2;
                }
                else if (gestureTwo == "spock" || gestureTwo == "paper")
                {
                    return 1;
                }
                else
                {
                    return 3;
                }
            }
            return 0;
        }

        public void ShowWinner(Player winner)
        {
            Console.WriteLine($"CONGRATULATIONS!  THE GAME IS OVER!  {winner.name.ToUpper()} WINS!");
        }

        public void ThanksForPlaying()
        {
            Console.WriteLine("Thanks for playing a game with us.  Would you like to play another game?" +
                "  Type 'YES' to play another game");
            string answer = Console.ReadLine().ToUpper();
            Console.Clear();
            if (answer == "YES")
            {
                keepPlaying = true;
            }
            else
            {
                keepPlaying = false;
            }
        }        
    }
}
