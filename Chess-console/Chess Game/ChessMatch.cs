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
        public Piece vulnerableEnPassant { get; private set; }

        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            finished = false;
            check = false;
            vulnerableEnPassant = null;
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

            // # Special Move: Short Castling
            if (p is King && destiny.columns == origin.columns + 2)
            {
                Position originTower = new Position(origin.lines, origin.columns + 3);
                Position destinyTower = new Position(origin.lines, origin.columns + 1);
                Piece tower = board.removePiece(originTower);
                tower.increaseMovement();
                board.putPiece(tower, destinyTower);
            }

            // # Special Move: Long Castling
            if (p is King && destiny.columns == origin.columns - 2)
            {
                Position originTower = new Position(origin.lines, origin.columns - 4);
                Position destinyTower = new Position(origin.lines, origin.columns - 1);
                Piece tower = board.removePiece(originTower);
                tower.increaseMovement();
                board.putPiece(tower, destinyTower);
            }

            // Special Move: En Passant
            if (p is Pawn)
            {
                if (origin.columns != destiny.columns && capturedPiece == null)
                {
                    Position posPawn;
                    if (p.color == Color.White)
                    {
                        posPawn = new Position(destiny.lines + 1, destiny.columns);
                    }
                    else
                    {
                        posPawn = new Position(destiny.lines - 1, destiny.columns);
                    }
                    capturedPiece = board.removePiece(posPawn);
                    captured.Add(capturedPiece);
                }
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

            // # Special Move: Short Castling
            if (p is King && destiny.columns == origin.columns + 2)
            {
                Position originTower = new Position(origin.lines, origin.columns + 3);
                Position destinyTower = new Position(origin.lines, origin.columns + 1);
                Piece tower = board.removePiece(destinyTower);
                tower.decrementmovement();
                board.putPiece(tower, originTower);
            }


            // # Special Move: Long Castling
            if (p is King && destiny.columns == origin.columns - 2)
            {
                Position originTower = new Position(origin.lines, origin.columns - 4);
                Position destinyTower = new Position(origin.lines, origin.columns - 1);
                Piece tower = board.removePiece(destinyTower);
                tower.decrementmovement();
                board.putPiece(tower, originTower);
            }

            // Special Move: En Passant
            if (p is Pawn) {
                if (origin.columns != destiny.columns && capturedPiece == vulnerableEnPassant) {
                    Piece pawn = board.removePiece(destiny);
                    Position posP;
                    if (p.color == Color.White) {
                        posP = new Position(3, destiny.columns);
                    }
                    else {
                        posP = new Position(4, destiny.columns);
                    }
                    board.putPiece(pawn, posP);
                }
            }

        }
        public void makeaMovement(Position origin, Position destiny)
        {
            Piece capturedPiece = movementExecute(origin, destiny);
            if (isInCheck(currentPlayer))
            {
                undoMovement(origin, destiny, capturedPiece);
                throw new BoardException("You can't put yourself in Check!");
            }

            if (isInCheck(adversary(currentPlayer)))
            {
                check = true;
            }
            else
            {
                check = false;
            }

            if (checkMateTest(adversary(currentPlayer)))
            {
                finished = true;
            }
            else
            {
                turn++;
                changePlayer();
            }

            Piece p = board.piece(destiny);

            // #Special Move: En Passant
            if (p is Pawn && (destiny.lines == origin.lines - 2 || destiny.lines == origin.lines + 2))
            {
                vulnerableEnPassant = p;
            }
            else
            {
                vulnerableEnPassant = null;
            }


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
            if (!board.piece(origin).movementPossible(destiny))
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

        public bool checkMateTest(Color color)
        {
            if (!isInCheck(color))
            {
                return false;
            }

            foreach (Piece x in piecesInGame(color))
            {
                bool[,] mat = x.possibleMovements();
                for (int i = 0; i < board.lines; i++)
                {
                    for (int j = 0; j < board.columns; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origin = x.position;
                            Position destiny = new Position(i, j);
                            Piece capturedPiece = movementExecute(origin, destiny);
                            bool checkTest = isInCheck(color);
                            undoMovement(origin, destiny, capturedPiece);
                            if (!checkTest)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
        public void putNewPiece(char columns, int lines, Piece piece)
        {
            board.putPiece(piece, new PositionChess(columns, lines).ToPosition());
            pieces.Add(piece);
        }
        private void putPieces()
        {

            putNewPiece('a', 1, new Tower(board, Color.White));
            putNewPiece('b', 1, new Knight(board, Color.White));
            putNewPiece('c', 1, new Bishop(board, Color.White));
            putNewPiece('d', 1, new Queen(board, Color.White));
            putNewPiece('e', 1, new King(board, Color.White, this));
            putNewPiece('f', 1, new Bishop(board, Color.White));
            putNewPiece('g', 1, new Knight(board, Color.White));
            putNewPiece('h', 1, new Tower(board, Color.White));
            putNewPiece('a', 2, new Pawn(board, Color.White, this));
            putNewPiece('b', 2, new Pawn(board, Color.White, this));
            putNewPiece('c', 2, new Pawn(board, Color.White, this));
            putNewPiece('d', 2, new Pawn(board, Color.White, this));
            putNewPiece('e', 2, new Pawn(board, Color.White, this));
            putNewPiece('f', 2, new Pawn(board, Color.White, this));
            putNewPiece('g', 2, new Pawn(board, Color.White, this));
            putNewPiece('h', 2, new Pawn(board, Color.White, this));

            putNewPiece('a', 8, new Tower(board, Color.Black));
            putNewPiece('b', 8, new Knight(board, Color.Black));
            putNewPiece('c', 8, new Bishop(board, Color.Black));
            putNewPiece('d', 8, new Queen(board, Color.Black));
            putNewPiece('e', 8, new King(board, Color.Black, this));
            putNewPiece('f', 8, new Bishop(board, Color.Black));
            putNewPiece('g', 8, new Knight(board, Color.Black));
            putNewPiece('h', 8, new Tower(board, Color.Black));
            putNewPiece('a', 7, new Pawn(board, Color.Black, this));
            putNewPiece('b', 7, new Pawn(board, Color.Black, this));
            putNewPiece('c', 7, new Pawn(board, Color.Black, this));
            putNewPiece('d', 7, new Pawn(board, Color.Black, this));
            putNewPiece('e', 7, new Pawn(board, Color.Black, this));
            putNewPiece('f', 7, new Pawn(board, Color.Black, this));
            putNewPiece('g', 7, new Pawn(board, Color.Black, this));
            putNewPiece('h', 7, new Pawn(board, Color.Black, this));

        }
    }
}
