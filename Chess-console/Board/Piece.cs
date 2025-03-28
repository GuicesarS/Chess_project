
namespace board
{
    abstract class Piece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }

        public int amountofmoviment { get; protected set; }
        public Board board{ get; protected set; }

        public Piece(Board board, Color color)
        {
            this.position = null;
            this.board = board;
            this.color = color;
            this.amountofmoviment = 0;
        }

        public void increaseMoviment()
        {
            amountofmoviment++;
        }

        public abstract bool[,] possibleMoviments();
        
    }


}
