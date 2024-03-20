using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Adodotnet
{
    public partial class Form2 : Form
    {
        public Form2(){
            InitializeComponent();
        }
        String g = "";
        SqlConnection con = new SqlConnection(@"data source=(localdb)\v11.0;initial catalog=aim;integrated security=true;");
        private void radioButton2_CheckedChanged(object sender, EventArgs e){
            g = radioButton2.Text; 
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e){
            g = radioButton1.Text;
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e){
            g = radioButton3.Text;
        }
        private void Form2_Load(object sender, EventArgs e){

        }
        private void button1_Click(object sender, EventArgs e){
           if (radioButton1.Checked){
                g = "Male";
            }
            else if(radioButton2.Checked){
               g = "Female";
            }else{
                g="Other";
            }
            con.Open();
SqlCommand cmd = new SqlCommand("insert into emp(ename,age,uname,dept,doj,esal,gender,mob)values('" + textBox2.Text + "'," + textBox3.Text + ",'" + textBox4.Text + "','" + comboBox1.Text + "','" + textBox5.Text + "'," + textBox6.Text + ",'" + g + "'," + textBox7.Text + ")", con);
                MessageBox.Show((cmd.ExecuteNonQuery() > 0)?"Record Added Successfully...":"Not Added!!");
            con.Close();
        }
        private void button2_Click(object sender, EventArgs e){
            con.Open();
            SqlCommand cmd = new SqlCommand("update emp set esal="+textBox6.Text+",dept='"+comboBox1.Text+"'where eid="+textBox1.Text+"", con);
            MessageBox.Show((cmd.ExecuteNonQuery() > 0) ? "Record Updated Successfully..." : "Not Update!!");
            con.Close();
        }
        private void button3_Click(object sender, EventArgs e){
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from emp where eid=" + textBox1.Text + "", con);
            MessageBox.Show((cmd.ExecuteNonQuery() > 0) ? "Record Deleted.." : "Not Deleted!!");
            con.Close();
        }
        private void button4_Click(object sender, EventArgs e){
            SqlDataAdapter sda = new SqlDataAdapter("select*from emp", con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void button5_Click(object sender, EventArgs e){
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }
    }
}
