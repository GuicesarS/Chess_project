using System;
using board;

namespace Chess_Game
{
    class King : Piece
    {
        private ChessMatch match;

        public King(Board board, Color color, ChessMatch match) : base(board, color) { 
            this.match = match;
        }
        public override string ToString()
        {
            return "K";
        }

        private bool canMove(Position pos)
        {
            Piece p = board.piece(pos);
            return p == null || p.color != this.color;
        }

        private bool testTowerForCastling(Position pos)
        {
            Piece p = board.piece(pos);
            return p != null && p is Tower && p.color == color && p.amountofmovement ==0;
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

            // #Special Move: Castling
            if(amountofmovement ==0 && !match.check)
            {
                // #Special Move: Short Castling
                Position posT1 = new Position(position.lines, position.columns+3);
                if(testTowerForCastling(posT1))
                {
                    Position p1 = new Position(position.lines, position.columns+1);
                    Position p2 = new Position(position.lines, position.columns+2);
                    if(board.piece(p1) == null && board.piece(p2) == null)
                    {
                        mat[position.lines, position.columns +2] = true;
                    }
                }

                 // #Special Move: Long Castling
                Position posT2 = new Position(position.lines, position.columns-4);
                if(testTowerForCastling(posT2))
                {
                    Position p1 = new Position(position.lines, position.columns-1);
                    Position p2 = new Position(position.lines, position.columns-2);
                    Position p3 = new Position(position.lines, position.columns-3);

                    if(board.piece(p1) == null && board.piece(p2) == null && board.piece(p3) == null)
                    {
                        mat[position.lines, position.columns -2] = true;
                    }
                }

            }
            return mat;

        }

    }
}
