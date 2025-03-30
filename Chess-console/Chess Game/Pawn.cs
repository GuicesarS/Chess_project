using board;

namespace Chess_Game
{
    class Pawn : Piece
    {
        private ChessMatch match;
        public Pawn(Board board, Color color, ChessMatch match) : base(board, color)
        {
            this.match = match;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool hasEnemy(Position pos)
        {
            Piece p = board.piece(pos);
            return p != null && p.color != this.color;
        }

        private bool isFree(Position pos)
        {
            return board.piece(pos) == null;
        }

        public override bool[,] possibleMovements()
        {
            bool[,] mat = new bool[board.lines, board.columns];

            Position pos = new Position(0, 0);

            if (color == Color.White)
            {
                pos.defineValue(position.lines - 1, position.columns);
                if (board.validPosition(pos) && isFree(pos))
                {
                    mat[pos.lines, pos.columns] = true;
                }
                pos.defineValue(position.lines - 2, position.columns);
                Position p2 = new Position(position.lines - 1, position.columns);
                if (board.validPosition(p2) && isFree(p2) && board.validPosition(pos) && isFree(pos) && amountofmovement == 0)
                {
                    mat[pos.lines, pos.columns] = true;
                }
                pos.defineValue(position.lines - 1, position.columns - 1);
                if (board.validPosition(pos) && hasEnemy(pos))
                {
                    mat[pos.lines, pos.columns] = true;
                }
                pos.defineValue(position.lines - 1, position.columns + 1);
                if (board.validPosition(pos) && hasEnemy(pos))
                {
                    mat[pos.lines, pos.columns] = true;
                }

                // Special Move: En Passant
                if (position.lines == 3)
                {
                    Position left = new Position(position.lines, position.columns - 1);
                    if (board.validPosition(left) && hasEnemy(left) && board.piece(left) == match.vulnerableEnPassant)
                        mat[left.lines -1, left.columns] = true;

                    Position right = new Position(position.lines, position.columns + 1);
                    if (board.validPosition(right) && hasEnemy(right) && board.piece(right) == match.vulnerableEnPassant)
                        mat[right.lines -1, right.columns] = true;
                }


            }
            else
            {
                pos.defineValue(position.lines + 1, position.columns);
                if (board.validPosition(pos) && isFree(pos))
                {
                    mat[pos.lines, pos.columns] = true;
                }
                pos.defineValue(position.lines + 2, position.columns);
                Position p2 = new Position(position.lines + 1, position.columns);
                if (board.validPosition(p2) && isFree(p2) && board.validPosition(pos) && isFree(pos) && amountofmovement == 0)
                {
                    mat[pos.lines, pos.columns] = true;
                }
                pos.defineValue(position.lines + 1, position.columns - 1);
                if (board.validPosition(pos) && hasEnemy(pos))
                {
                    mat[pos.lines, pos.columns] = true;
                }
                pos.defineValue(position.lines + 1, position.columns + 1);
                if (board.validPosition(pos) && hasEnemy(pos))
                {
                    mat[pos.lines, pos.columns] = true;
                }

                // Special Move: En Passant
                if (position.lines == 4)
                {
                    Position left = new Position(position.lines, position.columns - 1);
                    if (board.validPosition(left) && hasEnemy(left) && board.piece(left) == match.vulnerableEnPassant)
                    {
                          mat[left.lines + 1, left.columns] = true;
                    }
                    Position right = new Position(position.lines, position.columns + 1);
                    if (board.validPosition(right) && hasEnemy(right) && board.piece(right) == match.vulnerableEnPassant)
                    {
                        mat[right.lines + 1, right.columns] = true;
                    }
                        
                }

            }

            return mat;
        }
    }
}
