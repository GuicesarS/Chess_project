using System;
using board;
using Chess_Game;
using System.Collections.Generic;

namespace chess_console
{
    class Screen
    {

        public static void printMatch(ChessMatch match)
        {
            printBoard(match.board);
            Console.WriteLine();
            printCapturedPieces(match);
            Console.WriteLine("\nTurn: " + match.turn);

            if(!match.finished)
            {
                Console.WriteLine($"Waiting for: {match.currentPlayer} player");
                 if(match.check)
            {
                Console.WriteLine($"{match.currentPlayer.ToString().ToUpper()} PLAYER, YOU ARE IN CHECK!");
            }

            }
            else
            {
                Console.WriteLine("CHECKMATE!");
                Console.WriteLine($"Winner is: {match.currentPlayer}");
            }
            
            
           
        }

        public static void printCapturedPieces(ChessMatch match)
        {
            Console.WriteLine("Captured Pieces: ");
            Console.Write("White: ");
            printCollection(match.capturedPieces(Color.White));

            Console.Write("\nBlack: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            printCollection(match.capturedPieces(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine("");

        }

        public static void printCollection(HashSet<Piece> collection)
        {
            Console.Write("[");
            foreach (Piece x in collection)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }
        public static void printBoard(Board board)
        {
            for (int i = 0; i < board.lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.columns; j++)
                {
                    printPiece(board.piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void printBoard(Board board, bool[,] possibleMovement)
        {
            ConsoleColor originBackground = Console.BackgroundColor;
            ConsoleColor changedBackground = ConsoleColor.DarkGray;

            for (int i = 0; i < board.lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.columns; j++)
                {
                    if (possibleMovement[i, j])
                    {
                        Console.BackgroundColor = changedBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = originBackground;
                    }
                    Screen.printPiece(board.piece(i, j));
                    Console.BackgroundColor = originBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originBackground;
        }


        public static PositionChess readChessPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new PositionChess(column, line);
        }
        public static void printPiece(Piece piece)
        {

            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.color == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}

