using System;
using System.Windows.Forms;

namespace LINQ_To_Entity_Fw
{
    public partial class Form1 : Form
    {
        EmployeeEntity dbContext =  new EmployeeEntity();
        public Form1()
        {
            InitializeComponent();
        }

        public void Clear() 
        {
            txtId.Clear();
            txtDesignation.Clear();
            txtName.Clear();
            txtSalary.Clear();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.Id = Convert.ToInt32(txtId.Text);
            emp.Name = txtName.Text;
            emp.Designation = txtDesignation.Text;
            emp.Salary = Convert.ToDecimal(txtSalary.Text);

            dbContext.Employees.Add(emp);
           int result = dbContext.SaveChanges(); //  reflect changes to the database
            if(result == 1) 
            {
                MessageBox.Show("Record Inserted");
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Employee emp = dbContext.Employees.Find(Convert.ToInt32(txtId.Text));
                if (emp != null)
                {
                    emp.Name = txtName.Text;
                    emp.Designation = txtDesignation.Text;
                    emp.Salary = Convert.ToDecimal(txtSalary.Text);
                    int result = dbContext.SaveChanges();
                    if (result == 1)
                    {
                        MessageBox.Show("Record is updated");
                        Clear();
                    }
                }
                else { MessageBox.Show("Record not found"); Clear(); }
             }catch(Exception ex) { MessageBox.Show(ex.Message);}
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Employee emp = dbContext.Employees.Find(Convert.ToInt32(txtId.Text));

                if (emp != null)
                {
                    txtName.Text = emp.Name;
                    txtDesignation.Text = emp.Designation;  
                    txtSalary.Text = emp.Salary.ToString();
                }
                else { MessageBox.Show("Record not found");Clear(); }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message);}
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Employee emp = dbContext.Employees.Find(Convert.ToInt32(txtId.Text));

                if (emp != null)
                {
                    dbContext.Employees.Remove(emp);
                    int result = dbContext.SaveChanges();//reflect changes to database
                    if (result == 1)
                    {
                        MessageBox.Show("Record deleted"); Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Record not found"); Clear();
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message);}
        }
    }
}
