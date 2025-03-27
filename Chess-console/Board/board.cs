
namespace board
{
    class Board
    {
        public int lines { get; set; }
        public int columns { get; set; }

        private Parts[,] parts;
        public Board(int lines, int columns)
        {
            this.lines = lines;
            this.columns = columns;
            parts = new Parts[lines, columns];
        }
    }
}
