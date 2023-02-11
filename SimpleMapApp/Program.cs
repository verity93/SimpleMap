using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleMapApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FrmGeoReference GeoReference = new FrmGeoReference();
            Application.Run(GeoReference);

            FrmMapDemo MapDemo = new FrmMapDemo();
            Application.Run(MapDemo);

           

        }
    }
}
