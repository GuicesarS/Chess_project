using System;
using board;

namespace Chess_Game
{
    class Knight : Piece
    {
        public Knight(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "N";
        }

        private bool canMove(Position pos)
        {
            Piece p = board.piece(pos);
            return p == null || p.color != this.color;
        }

        public override bool[,] possibleMovements()
        {
            bool[,] mat = new bool[board.lines, board.columns];
            Position pos = new Position(0, 0);

            // Up-Left
            pos.defineValue(position.lines - 1, position.columns - 2);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.lines, pos.columns] = true;
            }

            // Up-Right
            pos.defineValue(position.lines - 2, position.columns - 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.lines, pos.columns] = true;
            }

            // Right-Up
            pos.defineValue(position.lines - 2, position.columns + 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.lines, pos.columns] = true;
            }

            // Right-Down
            pos.defineValue(position.lines - 1, position.columns + 2);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.lines, pos.columns] = true;
            }

            // Down-Right
            pos.defineValue(position.lines + 1, position.columns + 2);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.lines, pos.columns] = true;
            }

            // Down-Left
            pos.defineValue(position.lines + 2, position.columns + 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.lines, pos.columns] = true;
            }

            // Left-Down
            pos.defineValue(position.lines + 2, position.columns - 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.lines, pos.columns] = true;
            }

            // Left-Up
            pos.defineValue(position.lines + 1, position.columns - 2);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.lines, pos.columns] = true;
            }

            return mat;
        }
    }
}
