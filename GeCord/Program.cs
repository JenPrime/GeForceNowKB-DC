using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeCord
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        

        [STAThread]
        static void Main()
        {
            if (File.Exists(GeCord.DLL))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new GeCord());
            }
        }
    }
}
