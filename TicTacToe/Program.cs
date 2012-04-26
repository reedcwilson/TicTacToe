﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
	class Program
	{
		static void Main(string[] args)
		{
			bool stillPlaying = true;

			Console.WriteLine("-----------------------");
			Console.WriteLine("Welcome to Tic Tac Toe!");
			Console.WriteLine("-----------------------\n");

			while (stillPlaying)
			{
				Console.WriteLine("What would you like to do:");
				Console.WriteLine("1. Start a new game");
				Console.WriteLine("2. Quit\n");

				Console.Write("Type a number and hit <enter>: ");

				string choice = Console.ReadLine();

				switch(choice)
				{
					case "1":
						PlayGame();
						break;
					case "2":
						stillPlaying = false;
						break;
					default:
						Console.WriteLine("Please enter a valid number...");
						break;
				}
			}
		}

        private static void DrawBoard(string[] board)
        {
            Console.WriteLine("Board Goes Here");
            Console.Write(" ");
            Console.Write(board[0]);
            Console.Write(" ");
            Console.Write("|");
            Console.Write(" ");
            Console.Write(board[1]);
            Console.Write(" ");
            Console.Write("|");
            Console.Write(" ");
            Console.WriteLine(board[2]);
            Console.WriteLine("--------");
            Console.Write(" ");
            Console.Write(board[3]);
            Console.Write(" ");
            Console.Write("|");
            Console.Write(" ");
            Console.Write(board[4]);
            Console.Write(" ");
            Console.Write("|");
            Console.Write(" ");
            Console.WriteLine(board[5]);
            Console.WriteLine("--------");
            Console.Write(" ");
            Console.Write(board[6]);
            Console.Write(" ");
            Console.Write("|");
            Console.Write(" ");
            Console.Write(board[7]);
            Console.Write(" ");
            Console.Write("|");
            Console.Write(" ");
            Console.WriteLine(board[8]);

            
        }

		private static void PlayGame()
		{
            string[] board = new string[9];

            DrawBoard(board);
			// TODO:
			// 1. create an string array that will store the positions of all 9 spaces on the board
			// 2. create a method that will take the string array as a parameter and return a string
			//    indicating who wins (null = no win, "X" = x wins, "O" = o wins). Use IsBoardFull() as an example
			// 3. make a loop that keeps going until either someone has won or the board is full
			// 4. create a method that takes the string array as a parameter and can output the board
			// 5. ask the user to type a number indicating where they would like to put their x or o
			// 6. make sure that the user typed in a valid option
			// 7. announce the result of the game
		}

		private static bool IsBoardFull(string[] board)
		{
			return board.All(space => space != null);
		}

		private static bool IsBoardFullAlt(string[] board)
		{
			for (int i = 0; i < board.Length; i++)
			{
				if (board[i] == null)
					return false;
			}

			return true;
		}

		private static bool IsBoardFullAlt2(string[] board)
		{
			foreach (string space in board)
			{
				if (space == null)
					return false;
			}

			return true;
		}
	}
}
