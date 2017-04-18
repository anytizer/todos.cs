using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace todo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static Mutex mutex = new Mutex(true, "C1A6CB3E-3444-46D6-815D-DBE7EF2CBA35");

        [STAThread]
        static void Main()
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new ToDos());
                //Application.Run(new LoginForm());

                mutex.ReleaseMutex();
            }
        }
    }
}
