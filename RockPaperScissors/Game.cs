﻿using System;
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
        public Player playerOne;
        public Player playerTwo;

        //Constructor
        public Game()
        {
            //Initialization and messages
            this.rounds = 0;
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
        //Member methods
        public void WelcomeMessage()
        {
            Console.WriteLine("\n\nWelcome to RPSSL!\n\n" +
                "The rules are pretty simple.  It's just like 'Rock, Paper, Scissors,'\n" +
                "but with two additional gesture options: Spock, and lizard...... more rules.\n" +
                "Hit ENTER to continue.");
            Console.ReadLine();
        }

        public string SelectNumberOfPlayers()
        {
            Console.WriteLine("Are there ONE or TWO players?  Please type 'one' or 'two'");
            string answer = Console.ReadLine().ToUpper();
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
            if (x == "TWO")
            {
                playerTwo = new Human();
                playerTwo.SetName();
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
            switch (rounds)
            {
                case 3:
                    break;
                case 5:
                    break;
                case 7:
                    break;
                default:
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
                string gestureOne = playerOne.ChooseGesture();
                string gestureTwo = playerTwo.ChooseGesture();
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
                Console.ReadLine();
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
                    return 0;
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
                    return 0;
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
                    return 0;
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
                    return 0;
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
                    return 0;
                }
            }
            return 3;
        }

        public void ShowWinner(Player winner)
        {
            Console.WriteLine($"CONGRATULATIONS!  THE GAME IS OVER!  {winner.name.ToUpper()} WINS!");
        }

        public void ThanksForPlaying()
        {
            Console.WriteLine("Thanks for playing a game with us.  Would you like to play another game?" +
                "  Type 'YES' to play another game");
            string answer = Console.ReadLine();
            if (answer == "YES")
            {
                WelcomeMessage();
            }
        }        
    }
}
