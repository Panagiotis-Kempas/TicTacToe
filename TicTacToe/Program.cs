using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            int gameStatus = 0;
            int currentPlayer = -1;
            char[] gameMarker = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            do
            {
                Console.Clear();
                currentPlayer = GetNextPlayer(currentPlayer);

                HeadsUpDisplay(currentPlayer);
                DrawGameBoard(gameMarker);

                GameEngine(gameMarker, currentPlayer);
                gameStatus = CheckWinner(gameMarker);
                
            } while (gameStatus.Equals(0));

            Console.Clear();
            HeadsUpDisplay(currentPlayer);
            DrawGameBoard(gameMarker);

            if (gameStatus.Equals(1)){               
                Console.WriteLine($"Player {currentPlayer} is the winner");
            }

            if (gameStatus.Equals(2))
            {              
                Console.WriteLine("The game is a draw!");
            }
        }


        private static int CheckWinner(char[] gameMarkers)
        {
            if (isGameDraw(gameMarkers))
            {
                return 2;
            }
            


            if (isGameWinner(gameMarkers))
            {
                return 1;
            }
            return 0;

        }

        private static bool isGameDraw(char[] gameMarkers)
        {
            return gameMarkers[0] != '1' &&
                   gameMarkers[1] != '2' &&
                   gameMarkers[2] != '3' &&
                   gameMarkers[3] != '4' &&
                   gameMarkers[4] != '5' &&
                   gameMarkers[5] != '6' &&
                   gameMarkers[6] != '7' &&
                   gameMarkers[7] != '8' &&
                   gameMarkers[8] != '9';
                   
        }

        private static bool isGameWinner(char[] gameMarkers)
        {
            if (isGameMarkersTheSame(gameMarkers, 0, 1, 2))
            {
                return true;
            }
            if (isGameMarkersTheSame(gameMarkers, 3, 4, 5))
            {
                return true;
            }
            if (isGameMarkersTheSame(gameMarkers, 6, 7, 8))
            {
                return true;
            }
            if (isGameMarkersTheSame(gameMarkers, 0, 3, 6))
            {
                return true;
            }
            if (isGameMarkersTheSame(gameMarkers, 1, 4, 7))
            {
                return true;
            }
            if (isGameMarkersTheSame(gameMarkers, 2, 5, 8))
            {
                return true;
            }
            return false;


        }
        private static bool isGameMarkersTheSame(char[] testGameMarkers, int pos1, int pos2, int pos3)
        {
            return testGameMarkers[pos1].Equals(testGameMarkers[pos2]) && testGameMarkers[pos2].Equals(testGameMarkers[pos3]);
        }

        private static void GameEngine(char[] gameMarkers, int currentPlayer)
        {
            bool notValidMove = true;

            do
            {
                string userIput = Console.ReadLine();

                if (!string.IsNullOrEmpty(userIput) &&
                  (userIput.Equals("1") ||
                  userIput.Equals("2") ||
                  userIput.Equals("3") ||
                  userIput.Equals("4") ||
                  userIput.Equals("5") ||
                  userIput.Equals("6") ||
                  userIput.Equals("7") ||
                  userIput.Equals("8") ||
                  userIput.Equals("9")))
                {
                    Console.Clear();
                    int.TryParse(userIput, out var gamePlacementMarker);

                    char currentMarker = gameMarkers[gamePlacementMarker - 1];

                    if (currentMarker.Equals('X') || currentMarker.Equals('O'))
                    {
                        Console.WriteLine("Placement has already a marker please select another placement");
                    }
                    else
                    {
                        gameMarkers[gamePlacementMarker - 1] = GetPlayerMarker(currentPlayer);
                        notValidMove = false;
                    }

                }
                else
                {
                    Console.WriteLine("Invalid value. Please select another placement");
                }
            } while (notValidMove);
            
        }
        private static char GetPlayerMarker(int player)
        {
            if(player % 2 == 0)
            {
                return 'O';
            }
            return 'X';
        }
        static void HeadsUpDisplay(int PlayerNumber)
        {

            Console.WriteLine("Welcone to the Super Duper Tic Tac Toe Game");
            Console.WriteLine("Player 1: X");
            Console.WriteLine("Player 2: O");
            Console.WriteLine();
            Console.WriteLine($"Player {PlayerNumber} to move, select 1 through 9 from the game board");
            Console.WriteLine();
        }

        static void DrawGameBoard(char[] gameMarker)
        {
            Console.WriteLine($" {gameMarker[0]} | {gameMarker[1]} | {gameMarker[2]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {gameMarker[3]} | {gameMarker[4]} | {gameMarker[5]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {gameMarker[6]} | {gameMarker[7]} | {gameMarker[8]} ");
        }

        static int GetNextPlayer(int player)
        {
            if (player.Equals(1))
            {
                return 2;
            }
            return 1;
        }
    }
}
