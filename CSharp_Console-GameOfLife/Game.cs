﻿namespace CSharp_Console_GOL
{
    internal static class Game
    {
        #region Attributes
        internal static Cells[,] cells;
        #endregion
        #region Properties
        internal static int XPos { get; set; } = 0;
        internal static int YPos { get; set; } = 0;
        private static GameField GameField { get; set; } = new();
        #endregion
        #region Methods
        internal static void Play()
        {
            Console.Clear();
            InitGame();
            bool exit = false;

            while (true)
            {
                CellsSelection(ref exit);
                GameField.RenderField();
                if (exit)
                {
                    return;
                }
            }
        }
        private static void InitGame()
        {
            Console.Write("Enter Height: ");
            int h = fieldInput();
            Console.Write("\nEnter Width: ");
            int w = fieldInput();

            GameField = new()
            {
                Height = h,
                Width = w
            };

            cells = new Cells[GameField.Height - 2, GameField.Width - 2];

            for (int y = 0; y < cells.GetLength(0); y++)
            {
                for (int x = 0; x < cells.GetLength(1); x++)
                {
                    cells[y, x] = new Cells();
                }
            }

            GameField.RenderField();

            static int fieldInput()
            {
                string? value;
                value = Console.ReadLine();
                if (value != null && value.Length > 3 || string.IsNullOrEmpty(value))
                {
                    value = "0";
                    return value[0] - 48;
                }
                return int.Parse(value);
            }
        }

        internal static void CellsSelection(ref bool exit)
        {
            ConsoleKey key;

            key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.Enter:
                    CheckState();
                    break;
                case ConsoleKey.Escape:
                    exit = true;
                    break;
                case ConsoleKey.Spacebar:
                    cells[YPos, XPos].CurrentState = !cells[YPos, XPos].CurrentState;
                    break;
                case ConsoleKey.LeftArrow:
                    XPos = (--XPos + GameField.Width - 2) % (GameField.Width - 2);
                    break;
                case ConsoleKey.UpArrow:
                    YPos = (--YPos + GameField.Height - 2) % (GameField.Height - 2);
                    break;
                case ConsoleKey.RightArrow:
                    XPos = ++XPos % (GameField.Width - 2);
                    break;
                case ConsoleKey.DownArrow:
                    YPos = ++YPos % (GameField.Height - 2);
                    break;
            }
        }
        private static void CheckState()
        {
            // A Dead "Black" Cell Only Becomes Alive If It Has 3 Live Neighbors
            // A Living "Green" Cell Only Dies When It Has < 2 || > 3 Live Neighbors

            for (int y = 0; y < cells.GetLength(0); y++)
            {
                #region VertiCheck
                bool topValid = y - 1 >= 0;

                bool bottomValid = y + 1 < cells.GetLength(0);
                #endregion

                for (int x = 0; x < cells.GetLength(1); x++)
                {
                    #region HoriCheck
                    bool leftValid = x - 1 >= 0;

                    bool rightValid = x + 1 < cells.GetLength(1);
                    #endregion

                    int neighbourCount = 0;

                    if (topValid) // Top
                    {
                        if (cells[y - 1, x].CurrentState)
                        {
                            neighbourCount++;
                        }

                        if (leftValid && cells[y - 1, x - 1].CurrentState) // Top Left
                        {
                            neighbourCount++;
                        }
                        if (rightValid && cells[y - 1, x + 1].CurrentState) // Top Right
                        {
                            neighbourCount++;
                        }
                    }

                    if (bottomValid) // Bottom
                    {
                        if (cells[y + 1, x].CurrentState)
                        {
                            neighbourCount++;
                        }

                        if (leftValid && cells[y + 1, x - 1].CurrentState) // Bottom Left
                        {
                            neighbourCount++;
                        }
                        if (rightValid && cells[y + 1, x + 1].CurrentState) // Bottom Right
                        {
                            neighbourCount++;
                        }
                    }

                    if (leftValid && cells[y, x - 1].CurrentState) // Left
                    {
                        neighbourCount++;
                    }
                    if (rightValid && cells[y, x + 1].CurrentState) // Right
                    {
                        neighbourCount++;
                    }

                    #region ChangeState
                    if (cells[y, x].CurrentState && (neighbourCount < 2 || neighbourCount > 3))
                    {
                        cells[y, x].NextState = !cells[y, x].CurrentState;
                    }
                    else if (!cells[y, x].CurrentState && neighbourCount == 3)
                    {
                        cells[y, x].NextState = !cells[y, x].CurrentState;
                    }
                    else
                    {
                        cells[y, x].NextState = cells[y, x].CurrentState;
                    }
                    #endregion
                }
            }

            ChangeState();

            static void ChangeState()
            {
                for (int y = 0; y < cells.GetLength(0); y++)
                {
                    for (int x = 0; x < cells.GetLength(1); x++)
                    {
                        if (cells[y, x].CurrentState != cells[y, x].NextState)
                        {
                            cells[y, x].CurrentState = cells[y, x].NextState;
                        }
                    }
                }
            }
        }
        #endregion
    }
}
