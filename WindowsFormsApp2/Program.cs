using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameShark
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var thread = new Thread(new ThreadStart(Constructor.Logger.LoggingAsync));
            thread.Start();
            Constructor.MB = new MainBuyer();
            var autorize = new Autorize();
            autorize.Show();
            Application.Run(Constructor.MB);
            thread.Abort();
        }
    }
}
