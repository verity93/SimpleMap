using System.Data;
using System.Windows.Forms;


namespace SimpleMap.SimpleMapDb
{

    public partial class MapDb
    {

        public static BindingSource CreateDataSource(DataTable table)
        {
            var bindingSource = new BindingSource { DataSource = table.DataSet, DataMember = table.TableName };

            return bindingSource;
        }
    }
}
