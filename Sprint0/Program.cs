using System;

[assembly: CLSCompliant(true)]
namespace Sprint0
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>

    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = Game1.Instance)
                game.Run();
        }
    }
#endif
}
