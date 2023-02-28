namespace CSharp_Console_GOL
{
    internal class EntryPoint
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Util.Maximize(); // Maximizing Console On Startup

            Util.InitMusic();

            while (true)
            {
                Console.Clear();
                Menu.Show(); // Calling All The Menu Functionalities
            }
        }
    }
}