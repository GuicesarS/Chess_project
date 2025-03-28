using System;
using Chess_Game;
using board;

namespace chess_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Board board = new Board(8, 8);

                board.putPiece(new Tower (board,Color.Black), new Position(0, 0));
                board.putPiece(new Tower(board, Color.Black), new Position(3, 0));
                board.putPiece(new King(board, Color.Black), new Position(1, 5));
                board.putPiece(new King(board, Color.White), new Position(1, 3));
                board.putPiece(new Tower(board, Color.White), new Position(2, 5));
                Screen.printBoard(board);

                Console.ReadLine();
            }
            catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }
           
        }
    }
}