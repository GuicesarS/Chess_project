
namespace board
{
    class Parts
    {
        public Position position { get; set; }
        public Color color { get; protected set; }

        public int amountofmoviment { get; protected set; }
        public Board board{ get; protected set; }

        public Parts(Position position, Board board, Color color)
        {
            this.position = position;
            this.board = board;
            this.color = color;
            this.amountofmoviment = 0;
        }
    }
}
