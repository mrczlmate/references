using System.Reflection;
using System.Windows.Controls;
using System.Windows.Data;
using System.Linq;

namespace dogMeet_adminSite.DataManage
{
    public class JSonData<T>
    {
        public T[] data { get; set; }
        public void AddToDataGrid(DataGrid grid)
        {
            grid.Columns.Clear();
            grid.Items.Clear();

            foreach (PropertyInfo item in typeof(T).GetProperties())
            {
                grid.Columns.Add(new DataGridTextColumn() { Binding = new Binding(item.Name) });
            }

            int i = 0;
            string[] headers = typeof(T).GetProperties().Select(x => x.Name).ToArray();
            foreach (DataGridColumn column in grid.Columns)
            {
                column.Header = headers[i];
                i++;
            }

            foreach (T classname in data)
            {
                grid.Items.Add(classname);
            }
        }
    }
}
