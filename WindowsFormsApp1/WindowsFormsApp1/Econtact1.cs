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

namespace WindowsFormsApp1
{
    public partial class Econtact1 : Form
    {
        public Econtact1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string str = "server=10.0.103.99\\SQL2008R2;database=SQL_Training1;UID=training;Password=training";
                SqlConnection con = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UpdateTheVisit";
                cmd.Connection = con;

                if(txtboxEmail == null)
                {
                    cmd.Parameters.AddWithValue("@Name", txtboxName.Text);
                    cmd.Parameters.AddWithValue("@ContactNo", txtboxContact.Text);
                    SqlParameter output = new SqlParameter();

                    output.ParameterName = "@ret";
                    output.SqlDbType = SqlDbType.VarChar;
                    output.Direction = ParameterDirection.Output;

                    cmd.Parameters.Add(output);

                    string result = output.Value.ToString();
                    MessageBox.Show(result);
                }

                else
                {
                    cmd.Parameters.AddWithValue("@Name", txtboxName.Text);
                    cmd.Parameters.AddWithValue("@ContactNo", txtboxContact.Text);
                    cmd.Parameters.AddWithValue("@EmailId", txtboxEmail.Text);

                    SqlParameter output = new SqlParameter();

                    output.ParameterName = "@ret";
                    output.SqlDbType = SqlDbType.VarChar;
                    output.Direction = ParameterDirection.Output;

                    cmd.Parameters.Add(output);

                    string result = output.Value.ToString();
                    MessageBox.Show(result);
                }
            }

            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
    }
}
