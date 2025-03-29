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
                while (!match.finished)
                {
                    try
                    {
                        Console.Clear();
                    Screen.printBoard(match.board);
                    Console.WriteLine("\nTurn: " + match.turn);
                    Console.WriteLine($"Waiting for: {match.currentPlayer} player");

                    Console.WriteLine();
                    Console.Write("\nOrigin: ");
                    Position origin = Screen.readChessPosition().ToPosition();
                    match.validationOfOriginPosition(origin);

                    bool[,] possiblePositions = match.board.piece(origin).possibleMovements();

                    Console.Clear();
                    Screen.printBoard(match.board, possiblePositions);

                    Console.WriteLine();
                    Console.Write("Destiny: ");
                    Position destiny = Screen.readChessPosition().ToPosition();
                    match.validationOfDestinyPosition(origin, destiny);

                    match.makeaMovement(origin, destiny);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                    
                }
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}