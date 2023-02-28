namespace CSharp_Console_GOL
{
    internal class EntryPoint
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
<<<<<<< HEAD

            Util.Maximize(); // Maximizing Console On Startup

            Util.InitMusic();

=======
            Util.Maximize(); // Maximizing Console On Startup

>>>>>>> 0db6a86897d0b23f563856e13c1bfaca705dab67
            while (true)
            {
                Console.Clear();
                Menu.Show(); // Calling All The Menu Functionalities
            }
        }
    }
}