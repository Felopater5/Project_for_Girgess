using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_for_Girgess
{
    public partial class Employee : Form
    {
        private Functions con;
        public Employee()
        {

            InitializeComponent();
            con=new Functions();
            ShowEmployess();
            GetDepartment();
        }

        private void ShowEmployess()
        {
            string Query = "Select * from Employee";
            EmpList.DataSource = con.GetData(Query);


        }
        private void GetDepartment()
        {
            string Query = "Select * from Department";
            CbDeptIdEmp.DisplayMember=con.GetData(Query).Columns["DeotName"].ToString();
            CbDeptIdEmp.ValueMember = con.GetData(Query).Columns["DeptId"].ToString();
            CbDeptIdEmp.DataSource = con.GetData(Query);

        }
        private void Employee_Load(object sender, EventArgs e)
        {
            Login log = new Login();
            log . Show();
            this.Hide();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        int Key = 0;
        private void EmpList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EmpName.Text = EmpList.SelectedRows[0].Cells[1].Value.ToString();
            cbEmpGen.Text = EmpList.SelectedRows[0].Cells[2].Value.ToString();
            CbDeptIdEmp.SelectedValue = EmpList.SelectedRows[0].Cells[3].Value.ToString();
            EmpDate.Text= EmpList.SelectedRows[0].Cells[4].Value.ToString();
            JDate.Text = EmpList.SelectedRows[0].Cells[5].Value.ToString();
            EmpSalary.Text= EmpList.SelectedRows[0].Cells[6].Value.ToString();
            if (EmpName.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(EmpList.SelectedRows[0].Cells[0].Value.ToString());
            }

        }
        private void AddBtn_Click(object sender, EventArgs e)
        {

     
            try
            {
                if (EmpName.Text == ""||EmpSalary.Text==""||cbEmpGen.SelectedIndex==-1||CbDeptIdEmp.SelectedIndex==-1)                {
                    MessageBox.Show("Missing Data !!!");
                }
                else
                {
                    string name = EmpName.Text.ToString();
                    int depid = Convert.ToInt32(CbDeptIdEmp.SelectedValue.ToString());
                    string gender=cbEmpGen.SelectedItem.ToString();
                    string date = EmpDate.Value.Date.ToString();
                    string jdate = JDate.Value.Date.ToString();
                    int Salary = Convert.ToInt32(EmpSalary.Text.ToString());

                   
                    string Query = "insert into Employee values('{0}','{1}','{2}','{3}','{4}','{5}')";
                    Query = string.Format(Query,name,gender, depid, date,jdate,Salary);
                    con.SetData(Query);
                    ShowEmployess();
                    MessageBox.Show("Employee Added!!!");
                    EmpName.Text = "";EmpSalary.Text = "";CbDeptIdEmp.SelectedIndex = -1;
                    cbEmpGen.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {


            try
            {
                if (EmpName.Text == "" || EmpSalary.Text == "" || cbEmpGen.SelectedIndex == -1 || CbDeptIdEmp.SelectedIndex == -1)
                {
                    MessageBox.Show("Missing Data !!!");
                }
                else
                {
                    string name = EmpName.Text.ToString();
                    int id = Convert.ToInt32(CbDeptIdEmp.SelectedValue.ToString());
                    string gender = cbEmpGen.SelectedItem.ToString();
                    string date = EmpDate.Value.Date.ToString();
                    string jdate = JDate.Value.Date.ToString();
                    int Salary = Convert.ToInt32(EmpSalary.Text.ToString());


                    string Query = "Update Employee set EmpName='{0}',EmpGen='{1}',EmpDep='{2}',EmpDDB='{3}',EmpDate='{4}',EmpSal='{5}' Where EmpId='{6}'";
                    Query = string.Format(Query, name, gender, id, date, jdate, Salary,Key);
                    con.SetData(Query);
                    ShowEmployess();
                    MessageBox.Show("Employee Updated!!!");
                    EmpName.Text = ""; EmpSalary.Text = ""; CbDeptIdEmp.SelectedIndex = -1;
                    cbEmpGen.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {


            try
            {
                if (Key==0)
                {
                    MessageBox.Show("Missing Data !!!");
                }
                else
                {
                    string name = EmpName.Text.ToString();
                    int depid = Convert.ToInt32(CbDeptIdEmp.SelectedValue.ToString());
                    string gender = cbEmpGen.SelectedItem.ToString();
                    string date = EmpDate.Value.Date.ToString();
                    string jdate = JDate.Value.Date.ToString();
                    int Salary = Convert.ToInt32(EmpSalary.Text.ToString());


                    string Query = "delete Employee where EmpId='{0}'";
                    Query = string.Format(Query, Key);
                    con.SetData(Query);
                    ShowEmployess();
                    MessageBox.Show("Employee Deleted!!!");
                    EmpName.Text = ""; EmpSalary.Text = ""; CbDeptIdEmp.SelectedIndex = -1;
                    cbEmpGen.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Department dp = new Department();
            dp.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Salary sal = new Salary();
            sal.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
    }
}
