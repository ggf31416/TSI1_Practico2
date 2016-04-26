using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;
using Shared.Entities;
using System.ServiceModel;

namespace PresentationLayerWinform
{
    public partial class EmployeeList : Form
    {
        public EmployeeList()
        {
            InitializeComponent();
        }

        private void EmployeeList_Load(object sender, EventArgs e)
        {
            //BLEmployees businessLayer = new BLEmployees(new DALEmployeesEF());
            ServiceEmployeesClient client = new ServiceEmployeesClient();
            List<Employee> list = new List<Employee>();
            list.AddRange(client.GetAllEmployees());
            //Obtener empleados, recorrerlos y agregarlos
            int i = 0;
            foreach (Employee emp in list)
            {
                ListViewItem item = new ListViewItem(emp.Id.ToString(), i);
                item.SubItems.Add(emp.Name);
                item.SubItems.Add(emp.StartDate.ToString());
                //ListViewItem item = new ListViewItem(new[] { emp.Id.ToString(), emp.Name, emp.StartDate.ToString() });
                if (emp.GetType() == typeof(FullTimeEmployee))
                {
                    item.SubItems.Add("Full time");
                }
                else
                {
                    item.SubItems.Add("Part time");
                }
                listEmp.Items.Add(item);
                i++;
            }
            
        }

        private void listEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            EmployeeAddEdit form = new EmployeeAddEdit();
            ListView.SelectedListViewItemCollection selected = listEmp.SelectedItems;
            foreach (ListViewItem item in selected)
            {
                int id = Int32.Parse(item.SubItems[0].Text);
                form.loadEmployee(id);
            }
            form.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //BLEmployees businessLayer = new BLEmployees(new DALEmployeesEF());
            ServiceEmployeesClient client = new ServiceEmployeesClient();
            ListView.SelectedListViewItemCollection selected = listEmp.SelectedItems;
            foreach (ListViewItem item in selected)
            {
                int id = Int32.Parse(item.SubItems[0].Text);
                client.DeleteEmployee(id);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmployeeAddEdit form = new EmployeeAddEdit();
            form.loadEmployee(-1);
            form.Show();
        }
    }
}
