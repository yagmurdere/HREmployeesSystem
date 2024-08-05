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

namespace HREmployeesSystem
{
    public partial class icerik : Form
    {
        public icerik()
        {
            InitializeComponent();
        }
        void goster()
        {
            SqlConnection baglanti=new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\denemeVT.mdf;Integrated Security=True");
            baglanti.Open();
            SqlDataAdapter vericerik=new SqlDataAdapter("select * from icerik order by ad",baglanti);
            DataSet ds = new DataSet();
            vericerik.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        private void icerik_Load(object sender, EventArgs e)
        {
            goster();
        }
    }
}
