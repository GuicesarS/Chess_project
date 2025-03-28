using System;
using board;

namespace Chess_Game
{
    class ChessMatch
    {
        public Board board { get; private set; }
        private int turn { get; set; }
        private Color currentPlayer;
        public bool finished { get; private set; }

        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            finished = false;
            putPieces();
        }

        public void movimentExecute(Position origin, Position destiny)
        {
            Piece p = board.removePiece(origin);
            p.increaseMoviment();
            Piece capturedPiece = board.removePiece(destiny);
            board.putPiece(p, destiny);
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
