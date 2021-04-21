using System;
using System.Windows.Forms;
using ProgramMain.ExampleForms;

namespace ProgramMain
{
	static class Program
	{
	    static Program()
	    {
			// MapDemo = null;
			//GeoReference = null;
		}

		//public static FrmMapDemo MapDemo { get; private set; }
		//public static FrmGeoReference GeoReference { get; private set; }

		[STAThread]
        static void Main()
		{
            Application.EnableVisualStyles();

            FrmMapDemo MapDemo = new FrmMapDemo();
            Application.Run(MapDemo);

            FrmWorldMap GeoReference = new FrmWorldMap();
            Application.Run(GeoReference);

            //GeoReference = null;
        }
	}
}
