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
			var stillPlaying = true;

			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.WriteLine("-----------------------");
			Console.WriteLine("Welcome to Tic Tac Toe!");
			Console.WriteLine("-----------------------\n");
			Console.ResetColor();

			while (stillPlaying)
			{
				Console.WriteLine("What would you like to do:");
				Console.WriteLine("1. Start a new game");
				Console.WriteLine("2. Quit\n");

				Console.Write("Type a number and hit <enter>: ");

				var choice = GetUserInput("[12]");

				switch(choice)
				{
					case "1":
						PlayGame();
						Console.Clear();
						break;
					case "2":
						stillPlaying = false;
						break;
				}
			}
		}

		private static string GetUserInput(string validPattern = null)
		{
			var input = Console.ReadLine();
			input = input.Trim();

			if (validPattern != null && !System.Text.RegularExpressions.Regex.IsMatch(input, validPattern))
			{
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.WriteLine("\"" + input + "\" is not valid.\n");
				Console.ResetColor();
				return null;
			}

			return input;
		}

		private static void PlayGame()
		{
			string numRowsChoice = null;
			while (numRowsChoice == null)
			{
				Console.Write("How many rows do you want to have? (3, 4, or 5) ");
				numRowsChoice = GetUserInput("[345]");
			}
			var boardSize = (int)Math.Pow(int.Parse(numRowsChoice), 2);
			var board = new string[boardSize];

			var turn = "X";
			while (true)
			{
				Console.Clear();

				DrawBoard(board);

				var winner = WhoWins(board);
				if (winner != null)
				{
					AnnounceResult(winner + " WINS!!!");
					break;
				}
				if (IsBoardFull(board))
				{
					AnnounceResult("It's a tie!!!");
					break;
				}

				Console.WriteLine("\nUse the arrow keys and press enter to place your " + turn + ".");

				var xoLoc = GetXOLocation(board);
				board[xoLoc] = turn;

				turn = turn == "X" ? "O" : "X";
			}
		}

		private static void AnnounceResult(string message)
		{
			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.WriteLine("\n" + message);
			Console.ResetColor();

			Console.Write("\nPress any key to continue...");
			Console.CursorVisible = false;
			Console.ReadKey();
			Console.CursorVisible = true;
		}

		private static int GetXOLocation(string[] board)
		{
			int numRows = (int)Math.Sqrt(board.Length);

			int curRow = 0, curCol = 0;
			
			for (int i = 0; i < board.Length; i++)
			{
				if (board[i] == null)
				{
					curRow = i / numRows;
					curCol = i % numRows;
					break;
				}
			}

			while (true)
			{
				Console.SetCursorPosition(curCol * 4 + 1, curRow * 4 + 1);
				var keyInfo = Console.ReadKey();
				Console.SetCursorPosition(curCol * 4 + 1, curRow * 4 + 1);
				Console.Write(board[curRow * numRows + curCol] ?? " ");

				switch (keyInfo.Key)
				{
					case ConsoleKey.LeftArrow:
						if (curCol > 0)
							curCol--;
						break;
					case ConsoleKey.RightArrow:
						if (curCol + 1 < numRows)
							curCol++;
						break;
					case ConsoleKey.UpArrow:
						if (curRow > 0)
							curRow--;
						break;
					case ConsoleKey.DownArrow:
						if (curRow + 1 < numRows)
							curRow++;
						break;
					case ConsoleKey.Spacebar:
					case ConsoleKey.Enter:
						if (board[curRow * numRows + curCol] == null)
							return curRow * numRows + curCol;
						break;
				}
			}
		}

		private static void DrawBoard(string[] board)
		{
			var numRows = (int)Math.Sqrt(board.Length);

			for (int row = 0; row < numRows; row++)
			{
				if (row != 0)
					Console.WriteLine(string.Join("|", Enumerable.Repeat("---", numRows)));

				Console.WriteLine(string.Join("|", Enumerable.Repeat("   ", numRows)));

				for (int col = 0; col < numRows; col++)
				{
					if (col != 0)
						Console.Write("|");

					Console.Write(" " + (board[row * numRows + col] ?? " ") + " ");
				}

				Console.WriteLine("\n" + string.Join("|", Enumerable.Repeat("   ", numRows)));
			}
		}

		private static bool IsBoardFull(string[] board)
		{
			return board.All(space => space != null);
		}

		private static string WhoWins(string[] board)
		{
			var numRows = (int)Math.Sqrt(board.Length);
			var hasTicTacToe = true;

			// Check rows
			for (int row = 0; row < numRows; row++)
			{
				if (board[row * numRows] != null)
				{
					hasTicTacToe = true;
					for (int col = 1; col < numRows && hasTicTacToe; col++)
					{
						if (board[row * numRows + col] != board[row * numRows])
							hasTicTacToe = false;
					}
					if (hasTicTacToe)
						return board[row * numRows];
				}
			}

			// Check columns
			for (int col = 0; col < numRows; col++)
			{
				if (board[col] != null)
				{
					hasTicTacToe = true;
					for (int row = 1; row < numRows && hasTicTacToe; row++)
					{
						if (board[row * numRows + col] != board[col])
							hasTicTacToe = false;
					}
					if (hasTicTacToe)
						return board[col];
				}
			}

			// Check diagonals
			if (board[0] != null)
			{
				hasTicTacToe = true;
				for (int row = 1; row < numRows && hasTicTacToe; row++)
				{
					if (board[row * numRows + row] != board[0])
						hasTicTacToe = false;
				}
				if (hasTicTacToe)
					return board[0];
			}
			if (board[numRows - 1] != null)
			{
				hasTicTacToe = true;
				for (int row = 1; row < numRows && hasTicTacToe; row++)
				{
					if (board[row * numRows + (numRows - 1 - row)] != board[numRows - 1])
						hasTicTacToe = false;
				}
				if (hasTicTacToe)
					return board[numRows - 1];
			}

			return null;
		}
	}
}
