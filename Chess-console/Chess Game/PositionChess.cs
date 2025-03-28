using System;
using board;

namespace Chess_Game
{
    class PositionChess
    {
        public char columns { get; set; }
        public int lines { get; set; }

        public PositionChess(char columns, int lines)
        {
            this.columns = columns;
            this.lines = lines;
        }

        public Position convertToPosition()
        {
            return new Position(8 - lines, columns - 'a');

            // Converts the column ('a' to 'h') into an index (0 to 7)
            // 'a' has an ASCII value of 97, 'b' is 98, ..., 'h' is 104.
            // Subtracting 'a' from any column turns 'a' into 0, 'b' into 1, ..., 'h' into 7.

        }
        public override string ToString()
        {
            return "" + columns + lines;
        }
    }
}
