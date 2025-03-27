using System;
using board;

namespace Chess_Game
{
    class King : Piece
    {
        public King (Board board, Color color) : base (board, color) {}
        public override string ToString()
        {
            return "K";
        }
    }
}
