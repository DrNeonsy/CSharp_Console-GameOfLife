﻿using CSharp_Console_GOL.Resources;

namespace CSharp_Console_GOL
{
    internal static class Menu
    {
        #region MenuOptions
        private static readonly List<Option> options = new()
        {
                new Option("Start", () => Game.Play()),
<<<<<<< HEAD
                new Option("How To Play", () => Environment.Exit(0)),
                new Option("Toggle Music", () => Util.Music(toggle: true)),
                new Option("Change Music", () => Util.Music()),
=======
                new Option("How To Play", () => Game.Play()),
                new Option("Toggle Music", () => Environment.Exit(0)),
                new Option("Change Music", () => Environment.Exit(0)),
>>>>>>> 0db6a86897d0b23f563856e13c1bfaca705dab67
                new Option("Change Color", () => Environment.Exit(0)),
                new Option("Leave", () => Environment.Exit(0)),
        };
        #endregion

        #region Select Arrow Array
        private static readonly int[] arrowPos = new int[options.Count];
        #endregion

        #region Properties
        private static int FirstMenuLine { get; } = 9;
        #endregion

        #region Methods
        internal static void Show()
        {
            Console.WriteLine(Files.MenuBanner);
            RenderOptions();
            MenuSelection();

            static void RenderOptions()
            {
                int line = FirstMenuLine; // The Line To Post Add Closing |
                Console.SetCursorPosition(0, line - 1); // Prepare Closing Position
                Console.WriteLine(new string('-', 36)); // Top Border

                int index = 0;

                foreach (Option option in options) // Output For Each Option Added Into The Options List
                {
                    arrowPos[index] = 34 / 2 + (option.OptionName.Length / 2);
                    Console.WriteLine("{0}{1," + arrowPos[index++] + "}", '|', option.OptionName); // Somewhat Centering The Name
                    Console.SetCursorPosition(35, line); // Prepare Closing Position
                    Console.Write('|'); // Closing Menu On Right Side
                    Console.SetCursorPosition(0, ++line); // NL
                }
                Console.WriteLine(new string('-', 36)); // Bottom Border
            }
            static void MenuSelection()
            {
                ConsoleKey key; // Variable For The Condition And ReadKey
                int index = 0; // Index For Array And List
                int firstLine = FirstMenuLine; // Copy Value From Constant Field
                do
                {
                    Console.SetCursorPosition(arrowPos[index] - (3 + options[index].OptionName.Length), firstLine); // Setting Position For Menu Arrow
                    Console.Write("-->"); // Printing Menu Arrow

                    key = Console.ReadKey(true).Key; // Reading Input Key

                    /*
                     * Because We Either Enter A Method, Exit Or Move In The Menu We Can Always Execute The Arrow Deletion
                     */

                    Console.SetCursorPosition(arrowPos[index] - (3 + options[index].OptionName.Length), firstLine); // Preparing Arrow Deletion
                    Console.Write("   "); // Delete Arrow (The 🧀 Way)

                    firstLine = FirstMenuLine; // Resetting The Line Position So We Can Math The Index With It

                    switch (key)
                    {
                        case ConsoleKey.DownArrow:
                            index = (++index + arrowPos.Length) % arrowPos.Length; // Index Rollover
                            firstLine += index; // To Align Y / TOP Position Based On The Index To Allow Dynamic Changes

                            break;
                        case ConsoleKey.UpArrow:
                            index = (--index + arrowPos.Length) % arrowPos.Length; // Index Rollover
                            firstLine += index; // To Align Y / TOP Position Based On The Index To Allow Dynamic Changes
                            break;
                        case ConsoleKey.Escape:
                            Environment.Exit(0); // To Avoid Weird Escape Key Behavior
                            break;
                    }
                } while (key != ConsoleKey.Enter);
                options[index].Selected();
            }
        }

        internal class Option // Custom Option DataType For The Menu List
        {
            internal string OptionName { get; }
            internal Action Selected { get; } // For Methods With No Parameters And Return Types () => CODE

            internal Option(string OptionName, Action Selected)
            {
                this.OptionName = OptionName; // Sign Name
                this.Selected = Selected; // And Function
            }
        }
        #endregion
    }
}
