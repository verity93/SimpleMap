using System.Windows.Forms;

namespace SimpleMap
{
    public static class Miscellaneous
    {
        public static System.Drawing.Icon DefaultIcon()
        {
            return System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        public static string GetAssemblyTitle()
        {
            var aTitle = @"Simple Map - GeoReference";
            //var thisAssembly = Program.GeoReference.GetType().Assembly;
            //var attributes = thisAssembly.GetCustomAttributes(typeof(System.Reflection.AssemblyTitleAttribute), false);
            //if (attributes.Length == 1)
            //{
            //    aTitle = ((System.Reflection.AssemblyTitleAttribute)attributes[0]).Title;
            //}
            return aTitle;
        }
    }
}
