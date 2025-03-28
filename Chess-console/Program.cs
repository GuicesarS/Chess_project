using System;
using Chess_Game;
using board;

namespace chess_console
{
    class Program
    {
        static void Main(string[] args)
        {
            PositionChess pos = new PositionChess('c', 7);
            Console.WriteLine(pos);
            Console.WriteLine(pos.convertToPosition());

            Console.ReadLine();
           
        }
    }
}