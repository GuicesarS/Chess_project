using System;
using board;

namespace Chess_Game
{
    class ChessMatch
    {
        public Board board { get; private set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool finished { get; private set; }

        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            finished = false;
            putPieces();
        }

        public void movementExecute(Position origin, Position destiny)
        {
            Piece p = board.removePiece(origin);
            p.increaseMovement();
            Piece capturedPiece = board.removePiece(destiny);
            board.putPiece(p, destiny);
        }

        public void makeaMovement(Position origin, Position destiny)
        {
            movementExecute(origin,destiny);
            turn ++;
            changePlayer();
        
        }

        public void validationOfOriginPosition(Position pos)
        {
            if(board.piece(pos) == null)
            {
                throw new BoardException("There is no piece on origin position!");
            }
            if(currentPlayer != board.piece(pos).color)
            {
                throw new BoardException("The piece choosed is not yours!");
            }
            if(!board.piece(pos).possibleMovementExist())
            {
                throw new BoardException("There is no possible move for origin piece choosed!");
            }
        }

        public void validationOfDestinyPosition(Position origin, Position destiny)
        {
            if(!board.piece(origin).canMoveFor(destiny))
            {
                throw new BoardException("Invalid destiny position!");
            }
        }

        private void changePlayer()
        {
               if(currentPlayer == Color.White)
               {
                currentPlayer = Color.Black;
               }
               else
               {
                currentPlayer = Color.White;
               }
        }

        private void putPieces()
        {
            board.putPiece(new Tower(board, Color.White), new PositionChess('c', 1).ToPosition());
            board.putPiece(new Tower(board, Color.White), new PositionChess('c', 2).ToPosition());
            board.putPiece(new Tower(board, Color.White), new PositionChess('d', 2).ToPosition());
            board.putPiece(new Tower(board, Color.White), new PositionChess('e', 2).ToPosition());
            board.putPiece(new Tower(board, Color.White), new PositionChess('e', 1).ToPosition());
            board.putPiece(new King(board, Color.White), new PositionChess('d', 1).ToPosition());

            board.putPiece(new Tower(board, Color.Black), new PositionChess('c', 7).ToPosition());
            board.putPiece(new Tower(board, Color.Black), new PositionChess('c', 8).ToPosition());
            board.putPiece(new Tower(board, Color.Black), new PositionChess('d', 7).ToPosition());
            board.putPiece(new Tower(board, Color.Black), new PositionChess('e', 7).ToPosition());
            board.putPiece(new Tower(board, Color.Black), new PositionChess('e', 8).ToPosition());
            board.putPiece(new King(board, Color.Black), new PositionChess('d', 8).ToPosition());






        }
    }
}
