namespace CSharp_Console_GOL
{
    internal class GameField
    {
        #region BackingFields
        private int height;
        private int width;
        #endregion
        #region Properties
        internal int Height
        {
            get { return height; }
            init
            {
                if (value <= 40 && value >= 5)
                {
                    height = value;
                }
                else if (value < 5)
                {
                    height = 5;
                }
                else
                {
                    height = 40;
                }
            }
        }
        internal int Width
        {
            get { return width; }
            init
            {
                if (value <= 170 && value >= 5)
                {
                    width = value;
                }
                else if (value < 5)
                {
                    width = 5;
                }
                else
                {
                    width = 170;
                }
            }
        }
        #endregion

        #region Constructor
        internal GameField()
        {

        }
        #endregion

        #region Methods
        internal void RenderField()
        {
            Console.Clear();
            HorizontalBorder();

            for (int y = 0; y < Height-2; y++)
            {
                Console.Write('|');
                for (int x = 0; x < Width - 2; x++)
                {
                    if (Game.XPos == x && Game.YPos == y)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    if (Game.cells[y, x].CurrentState)
                    {
                        Console.Write('x');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine('|');
            }

            HorizontalBorder(newLine: false);

            void HorizontalBorder(bool newLine = true)
            {
                Console.Write(new string('-', Width));
                if (newLine)
                {
                    Console.WriteLine();
                }
            }
        }
        #endregion
    }
}
