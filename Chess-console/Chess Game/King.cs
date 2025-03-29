using System;
using board;

namespace Chess_Game
{
    class King : Piece
    {
        public King(Board board, Color color) : base(board, color) { }
        public override string ToString()
        {
            return "K";
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

            // Up
            pos.defineValue(position.lines - 1, position.columns);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.lines, pos.columns] = true;
            }

            // Northeast

            pos.defineValue(position.lines - 1, position.columns + 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.lines, pos.columns] = true;
            }

            // Right

            pos.defineValue(position.lines, position.columns + 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.lines, pos.columns] = true;
            }

            // Southeast

            pos.defineValue(position.lines + 1, position.columns + 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.lines, pos.columns] = true;
            }

            // Down

            pos.defineValue(position.lines + 1, position.columns);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.lines, pos.columns] = true;
            }

            // Southwest

            pos.defineValue(position.lines + 1, position.columns - 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.lines, pos.columns] = true;
            }

            // Left

            pos.defineValue(position.lines, position.columns - 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.lines, pos.columns] = true;
            }

            // Northwest

            pos.defineValue(position.lines - 1, position.columns - 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.lines, pos.columns] = true;
            }
            return mat;

        }

    }
}
