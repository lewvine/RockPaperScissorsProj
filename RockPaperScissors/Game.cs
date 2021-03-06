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
        //public List<string> gestures;
        public Player playerOne;
        public Player playerTwo;
        public bool keepPlaying;
        public string playerNumber;


        //Constructor
        public Game()
        {
            rounds = 0;
            keepPlaying = true;
            playerOne = new Human();
            playerNumber = "";
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
                playerNumber = SelectNumberOfPlayers();
                CreatePlayer(playerNumber);
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
            playerNumber = Console.ReadLine().ToUpper();
            Console.Clear();

            if (playerNumber == "TWO" || playerNumber == "ONE")
            {
                return playerNumber;
            }
            else
            {
                Console.WriteLine("Invalid input.  Please try again.");
                SelectNumberOfPlayers();
                string error = "This is an error";
                return error;
            }
        }

        public void CreatePlayer(string playerNumber)
        {
            playerOne = new Human();
            playerOne.SetName();
            Console.Clear();
            if (playerNumber == "TWO")
            {
                playerTwo = new Human();
                playerTwo.SetName();
                Console.Clear();
            }
            else if (playerNumber == "ONE")
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
                Gesture gestureOne = playerOne.ChooseGesture();
                Console.Clear();
                Gesture gestureTwo = playerTwo.ChooseGesture();
                Console.Clear();
                Console.WriteLine($"{playerOne.name} picked {playerOne.currentGesture.name}.\n" +
                                    $"{playerTwo.name} picked {playerTwo.currentGesture.name}.");

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

        public int WhoWins(Gesture gestureOne, Gesture gestureTwo)
        {
            if (gestureTwo.name == gestureOne.name)
            {
                //3 signifies tie.
                return 3;
            }
            else if (gestureOne.winsAgainstList.Contains(gestureTwo.name) == true)
            {
                //playerOne wins
                return 1;
            }
            else
            {
                return 2;
            }
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
