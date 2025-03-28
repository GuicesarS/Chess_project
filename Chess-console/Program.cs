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
                ChessMatch match = new ChessMatch();
                while(!match.finished)
                {
                    Console.Clear();
                    Screen.printBoard(match.board);


                    Console.Write("\nOrigin: ");
                    Position origin = Screen.readChessPosition().ToPosition();
                    Console.Write("Destiny: ");
                    Position destiny = Screen.readChessPosition().ToPosition();

                    match.movimentExecute(origin, destiny);
                }
               
                
                Console.ReadLine();
            }
            catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}