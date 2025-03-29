
namespace board
{
    abstract class Piece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }

        public int amountofmovement { get; protected set; }
        public Board board{ get; protected set; }

        public Piece(Board board, Color color)
        {
            this.position = null;
            this.board = board;
            this.color = color;
            this.amountofmovement = 0;
        }

        public void increaseMovement()
        {
            amountofmovement++;
        }

        public bool possibleMovementExist()
        {
            bool[,] mat = possibleMovements();
            for (int i=0;i< board.lines;i++)
            {
                for (int j=0;j< board.columns;j++)
                {
                    if(mat[i,j] == true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool canMoveFor(Position pos)
        {
            return possibleMovements()[pos.lines, pos.columns];
        }
            public abstract bool[,] possibleMovements();
        
    }


}
