
namespace board
{
    class Board
    {
        public int lines { get; set; }
        public int columns { get; set; }

        private Parts[,] parts; // precaution
        public Board(int lines, int columns)
        {
            this.lines = lines;
            this.columns = columns;
            parts = new Parts[lines, columns];
        }

        public Parts part(int lines, int columns)
        {
            return parts[lines, columns];
            // method to access the private matrix
        }
    }
}
