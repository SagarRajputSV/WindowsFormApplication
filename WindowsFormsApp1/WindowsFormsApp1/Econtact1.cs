using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace WindowsFormsApp1
{
    public partial class Econtact1 : Form
    {
        SqlConnection con;
        SqlCommand cmd;

        public Econtact1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string str = ConfigurationManager.ConnectionStrings["CrudOpeartion"].ConnectionString;
                //string str = "server=10.0.103.99\\SQL2008R2;database=SQL_Training1;UID=training;password=training";
                con = new SqlConnection(str);
                con.Open();

                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateTheVisit";
                cmd.Connection = con;

                string Name = txtboxName.Text;
                string ContactNo = txtboxContact.Text;
                string EmailId = txtboxEmail.Text;

                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@ContactNo", ContactNo);
                cmd.Parameters.AddWithValue("@EmailId", EmailId);

                SqlParameter output = new SqlParameter();
                output.ParameterName = "@ret";
                output.SqlDbType = SqlDbType.VarChar;
                output.Size = 50;
                output.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(output);

                cmd.ExecuteNonQuery();

                string result = output.Value.ToString();
                MessageBox.Show(result);
            }

            catch (SqlException er)
            {
                MessageBox.Show(er.Message);
            }

            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
    }
}
