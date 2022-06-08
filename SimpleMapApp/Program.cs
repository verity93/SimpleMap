﻿using System;
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

            FrmWorldMap Wor = new FrmWorldMap();
            Application.Run(Wor);


           // FrmMapDemo MapDemo = new FrmMapDemo();
            //Application.Run(MapDemo);

           
        }
    }
}
