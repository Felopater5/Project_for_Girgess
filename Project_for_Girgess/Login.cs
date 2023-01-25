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
    public partial class Login : Form
    {
        

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Username.Text = "" ;
            pasword.Text = "";
                
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if(Username.Text=="" || pasword.Text == "")
            {
                MessageBox.Show("Missing Data !!");
            }
            else  if(Username.Text=="Admin"&&pasword.Text=="123")
            {
                Employee emp = new Employee();
                emp.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wronng in Username or Password");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
