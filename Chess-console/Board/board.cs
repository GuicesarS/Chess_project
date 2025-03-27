
namespace board
{
    class Board
    {
        public int lines { get; set; }
        public int columns { get; set; }

        private Piece[,] pieces; // precaution
        public Board(int lines, int columns)
        {
            this.lines = lines;
            this.columns = columns;
            this.pieces = new Piece[lines, columns];
        }

        public Piece piece(int lines, int columns)
        {
            return pieces[lines, columns];
            // method to access the private matrix
        }

        public Piece piece(Position pos)
        {
            return pieces[pos.lines, pos.columns];
        }

        public bool existPiece(Position pos)
        {
            validationofposition(pos);
            return piece(pos) != null;
        }

        public void putPiece(Piece p, Position pos)
        {
            if(existPiece(pos))
            {
                throw new BoardException("Already exist a piece on this position!");
            }
            pieces[pos.lines, pos.columns] = p; // Places the piece at the desired position
            p.position = pos; // Updates the piece's position  
        }

        public bool validPosition(Position pos)
        {
            if (pos.lines < 0 || pos.lines >= lines || pos.columns < 0 || pos.columns >= columns)
            {
                return false;
            }
            return true;
        }

        public void validationofposition(Position pos)
        {
            if (!validPosition(pos))
            {
                throw new BoardException("Invalid Position!");
            }
        }
    }
}
