using DataAccessLayer;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;

namespace PresentationLayerWinform
{
    public partial class EmployeeAddEdit : Form
    {
        private Employee emp = new Employee();
        public EmployeeAddEdit()
        {
            InitializeComponent();
        }

        private void EmployeeAddEdit_Load(object sender, EventArgs e)
        {

        }
        
        public void loadEmployee(Int32 id)
        {
            if (id != -1) {
                btnNuevo.Text = "Clonar";
                //BLEmployees businessLayer = new BLEmployees(new DALEmployeesEF());
                ServiceEmployeesClient client = new ServiceEmployeesClient();
                emp = client.GetEmployee(id);
                if(emp.GetType() == typeof(PartTimeEmployee))
                {
                    textBox4.Dispose();
                    label4.Dispose();
                    textBox3.Text = ((PartTimeEmployee)emp).HourlyRate.ToString();
                    radioButton1.Checked = true;
                }
                else
                {
                    textBox3.Dispose();
                    label3.Dispose();
                    textBox4.Text = ((FullTimeEmployee)emp).Salary.ToString();
                    radioButton2.Checked = true;
                }
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                textBox1.Text = emp.Name;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //BLEmployees businessLayer = new BLEmployees(new DALEmployeesEF());
            ServiceEmployeesClient client = new ServiceEmployeesClient();
            
            if (emp.GetType() == typeof(PartTimeEmployee))
            {
                PartTimeEmployee pte = new PartTimeEmployee();
                pte.Name = textBox1.Text;
                pte.StartDate = DateTime.Now;
                pte.HourlyRate = Double.Parse(textBox3.Text);
                client.UpdateEmployee(pte);
            }
            else
            {
                FullTimeEmployee fte = new FullTimeEmployee();
                fte.Name = textBox1.Text;
                fte.StartDate = DateTime.Now;
                fte.Salary = Int32.Parse(textBox4.Text);
                client.UpdateEmployee(fte);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //BLEmployees businessLayer = new BLEmployees(new DALEmployeesEF());
            ServiceEmployeesClient client = new ServiceEmployeesClient();
            if (radioButton1.Checked)
            {
                PartTimeEmployee employee = new PartTimeEmployee();
                employee.Name = textBox1.Text;
                employee.StartDate = DateTime.Now;
                employee.Id = client.GetAllEmployees().Count() + 1;
                employee.HourlyRate = Int32.Parse(textBox3.Text);
                client.AddEmployee(employee);
            }
            else
            {
                FullTimeEmployee employee = new FullTimeEmployee();
                employee.Name = textBox1.Text;
                employee.StartDate = DateTime.Now;
                employee.Id = client.GetAllEmployees().Count() + 1;
                employee.Salary = Int32.Parse(textBox4.Text);
                client.AddEmployee(employee);
            }
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
