using System;
using board;

namespace Chess_Game
{
    class Bishop : Piece
    {
        public Bishop(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "B";
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

            // Northwest
            pos.defineValue(position.lines - 1, position.columns - 1);
            while (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.lines, pos.columns] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color)
                {
                    break;
                }
                pos.defineValue(pos.lines - 1, pos.columns - 1);
            }

            // Northeast
            pos.defineValue(position.lines - 1, position.columns + 1);
            while (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.lines, pos.columns] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color)
                {
                    break;
                }
                pos.defineValue(pos.lines - 1, pos.columns + 1);
            }

            // Southeast
            pos.defineValue(position.lines + 1, position.columns + 1);
            while (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.lines, pos.columns] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color)
                {
                    break;
                }
                pos.defineValue(pos.lines + 1, pos.columns + 1);
            }

            // Southwest
            pos.defineValue(position.lines + 1, position.columns - 1);
            while (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.lines, pos.columns] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color)
                {
                    break;
                }
                pos.defineValue(pos.lines + 1, pos.columns - 1);
            }

            return mat;
        }
    }
}
