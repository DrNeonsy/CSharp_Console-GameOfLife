<<<<<<< HEAD
﻿using CSharp_Console_GOL.Resources;
using System.Runtime.InteropServices;
=======
﻿using System.Runtime.InteropServices;
>>>>>>> 0db6a86897d0b23f563856e13c1bfaca705dab67

namespace CSharp_Console_GOL
{
    internal partial class Util
    {
<<<<<<< HEAD
        static System.Media.SoundPlayer player = new();
=======
>>>>>>> 0db6a86897d0b23f563856e13c1bfaca705dab67
        #region Code To Maximize Console
        [LibraryImport("kernel32.dll")]
        private static partial IntPtr GetConsoleWindow();
        private static readonly IntPtr ThisConsole = GetConsoleWindow();
        [LibraryImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static partial bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int MAXIMIZE = 3;
        #endregion

        /// <summary>
        /// Call To Maximize Console
        /// </summary>
        internal static void Maximize()
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);
        }

        /// <summary>
        /// Prompts The User To Press One Of Two Keys
        /// </summary>
        /// <param name="msg">The Message You Wish To Display</param>
        /// <param name="option1">Key 1</param>
        /// <param name="option2">Key 2</param>
        /// <param name="banner">Optional String Banner</param>
        /// <returns>True If Key 1 Has Been Pressed Otherwise False</returns>
        internal static bool Decision(string msg, ConsoleKey option1 = ConsoleKey.Y, ConsoleKey option2 = ConsoleKey.N)
        {
            ConsoleKey ckey;
            Console.Write(msg + $" ( {option1} | {option2} )");

            do
            {
                ckey = Console.ReadKey(true).Key;
            } while (ckey != option1 && ckey != option2);

            Console.Clear();

            return ckey == option1;
        }
<<<<<<< HEAD

        internal static void InitMusic()
        {
            SongSelecter();
            player.PlayLooping();
        }

        internal static void Music(bool toggle = false)
        {
            if (toggle)
            {
                if (Settings.Default.musicOn)
                {
                    player.Stop();
                    Settings.Default.musicOn = false;
                }
                else
                {
                    player.PlayLooping();
                    Settings.Default.musicOn = true;
                }
            }
            else
            {
                SongSelecter(true);
                player.PlayLooping();
            }
        }

        private static void SongSelecter(bool s = false)
        {
            int input = s ? 2 : 0;
            switch (input)
            {
                case 0:
                    player.Stream = Files.Daydream;
                    break;
                case 1:
                    player.Stream = Files.Space;
                    break;
                case 2:
                    player.Stream = Files.Viking;
                    break;
            }
        }

=======
>>>>>>> 0db6a86897d0b23f563856e13c1bfaca705dab67
    }
}
