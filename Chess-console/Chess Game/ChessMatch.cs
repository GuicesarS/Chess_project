using System.Collections.Generic;
using board;

namespace Chess_Game
{
    class ChessMatch
    {
        public Board board { get; private set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool finished { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;
        public bool check { get; private set; }

        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            finished = false;
            check = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            putPieces();
        }

        public Piece movementExecute(Position origin, Position destiny)
        {
            Piece p = board.removePiece(origin);
            p.increaseMovement();
            Piece capturedPiece = board.removePiece(destiny);
            board.putPiece(p, destiny);
            if (capturedPiece != null)
            {
                captured.Add(capturedPiece);
            }
            return capturedPiece;
        }

        public void undoMovement(Position origin, Position destiny, Piece capturedPiece)
        {
            Piece p = board.removePiece(destiny);
            p.decrementmovement();
            if (capturedPiece != null)
            {
                board.putPiece(capturedPiece, destiny);
                captured.Remove(capturedPiece);
            }
            board.putPiece(p, origin);
        }
        public void makeaMovement(Position origin, Position destiny)
        {
            Piece capturedPiece = movementExecute(origin, destiny);
            if (isInCheck(currentPlayer))
            {
                undoMovement(origin, destiny, capturedPiece);
                throw new BoardException("You can't put yourself in Check!");
            }

            if(isInCheck(adversary(currentPlayer)))
            {
                check = true;
            }
            else
            {
                check = false;
            }

            turn++;
            changePlayer();

        }

        public void validationOfOriginPosition(Position pos)
        {
            if (board.piece(pos) == null)
            {
                throw new BoardException("There is no piece on origin position!");
            }
            if (currentPlayer != board.piece(pos).color)
            {
                throw new BoardException("The piece choosed is not yours!");
            }
            if (!board.piece(pos).possibleMovementExist())
            {
                throw new BoardException("There is no possible move for origin piece choosed!");
            }
        }

        public void validationOfDestinyPosition(Position origin, Position destiny)
        {
            if (!board.piece(origin).canMoveFor(destiny))
            {
                throw new BoardException("Invalid destiny position!");
            }
        }

        private void changePlayer()
        {
            if (currentPlayer == Color.White)
            {
                currentPlayer = Color.Black;
            }
            else
            {
                currentPlayer = Color.White;
            }
        }

        public HashSet<Piece> capturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in captured)
            {
                if (x.color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> piecesInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in pieces)
            {
                if (x.color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(capturedPieces(color));
            return aux;
        }


        private Color adversary(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece king(Color color)
        {
            foreach (Piece x in piecesInGame(color))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
        }

        public bool isInCheck(Color color)
        {
            Piece k = king(color);
            if (k == null)
            {
                throw new BoardException($"There is no {color} King on board!");
            }

            foreach (Piece x in piecesInGame(adversary(color)))
            {
                bool[,] mat = x.possibleMovements();
                if (mat[k.position.lines, k.position.columns])
                {
                    return true;
                }
            }
            return false;
        }

        public void putNewPiece(char columns, int lines, Piece piece)
        {
            board.putPiece(piece, new PositionChess(columns, lines).ToPosition());
            pieces.Add(piece);
        }
        private void putPieces()
        {

            putNewPiece('c', 1, new Tower(board, Color.White));
            putNewPiece('c', 2, new Tower(board, Color.White));
            putNewPiece('d', 2, new Tower(board, Color.White));
            putNewPiece('e', 2, new Tower(board, Color.White));
            putNewPiece('e', 1, new Tower(board, Color.White));
            putNewPiece('d', 1, new King(board, Color.White));

            putNewPiece('c', 7, new Tower(board, Color.Black));
            putNewPiece('c', 8, new Tower(board, Color.Black));
            putNewPiece('d', 7, new Tower(board, Color.Black));
            putNewPiece('e', 7, new Tower(board, Color.Black));
            putNewPiece('e', 8, new Tower(board, Color.Black));
            putNewPiece('d', 8, new King(board, Color.Black));








        }
    }
}
