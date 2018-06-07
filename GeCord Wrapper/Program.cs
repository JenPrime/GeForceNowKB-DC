using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeCord_Wrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting GeCord Wrapper");
            string game = "Error GEW001";
            if (args.Length > 0) { Console.WriteLine("For: " + args[0]); game = args[0]; } else Console.WriteLine("No Game set");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GeWrapper(game));
        }
    }
}
