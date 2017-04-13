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

                mutex.ReleaseMutex();
            }
            else
            {
                //MessageBox.Show("Program is already running.");
                NativeMethods.PostMessage((IntPtr)NativeMethods.HWND_BROADCAST, NativeMethods.WM_SHOWME, IntPtr.Zero, IntPtr.Zero);
            }
        }
    }

    /**
     * @see http://stackoverflow.com/questions/19147/what-is-the-correct-way-to-create-a-single-instance-application
     */
    internal class NativeMethods
    {
        public const int HWND_BROADCAST = 0xffff;
        public static readonly int WM_SHOWME = RegisterWindowMessage("WM_SHOWME");
        [DllImport("user32")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);
        [DllImport("user32")]
        public static extern int RegisterWindowMessage(string message);
    }
}
