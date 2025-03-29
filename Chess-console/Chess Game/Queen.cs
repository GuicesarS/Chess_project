using System;
using board;

namespace Chess_Game
{
    class Queen : Piece
    {
        public Queen(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "Q";
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
            while (board.validPosition(pos) && canMove(pos)) {
                mat[pos.lines, pos.columns] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color) break;
                pos.defineValue(pos.lines - 1, pos.columns);
            }

            // Down
            pos.defineValue(position.lines + 1, position.columns);
            while (board.validPosition(pos) && canMove(pos)) {
                mat[pos.lines, pos.columns] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color) break;
                pos.defineValue(pos.lines + 1, pos.columns);
            }

            // Left
            pos.defineValue(position.lines, position.columns - 1);
            while (board.validPosition(pos) && canMove(pos)) {
                mat[pos.lines, pos.columns] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color) break;
                pos.defineValue(pos.lines, pos.columns - 1);
            }

            // Right
            pos.defineValue(position.lines, position.columns + 1);
            while (board.validPosition(pos) && canMove(pos)) {
                mat[pos.lines, pos.columns] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color) break;
                pos.defineValue(pos.lines, pos.columns + 1);
            }

            // Northwest
            pos.defineValue(position.lines - 1, position.columns - 1);
            while (board.validPosition(pos) && canMove(pos)) {
                mat[pos.lines, pos.columns] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color) break;
                pos.defineValue(pos.lines - 1, pos.columns - 1);
            }

            // Northeast
            pos.defineValue(position.lines - 1, position.columns + 1);
            while (board.validPosition(pos) && canMove(pos)) {
                mat[pos.lines, pos.columns] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color) break;
                pos.defineValue(pos.lines - 1, pos.columns + 1);
            }

            // Southeast
            pos.defineValue(position.lines + 1, position.columns + 1);
            while (board.validPosition(pos) && canMove(pos)) {
                mat[pos.lines, pos.columns] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color) break;
                pos.defineValue(pos.lines + 1, pos.columns + 1);
            }

            // Southwest
            pos.defineValue(position.lines + 1, position.columns - 1);
            while (board.validPosition(pos) && canMove(pos)) {
                mat[pos.lines, pos.columns] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color) break;
                pos.defineValue(pos.lines + 1, pos.columns - 1);
            }

            return mat;
        }
    }
}
