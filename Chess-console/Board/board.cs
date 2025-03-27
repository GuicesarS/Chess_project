
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

        public void putPiece(Piece p , Position pos)
        {
            pieces[pos.lines, pos.columns] = p; // Places the piece at the desired position
            p.position = pos; // Updates the piece's position  
        }
    }
}
